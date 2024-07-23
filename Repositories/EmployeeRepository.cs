using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId, EmployeeParameters employeeParametrs, bool trackChanges)
        {
            var employees = await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
                .FilterEmployees(employeeParametrs.MinAge, employeeParametrs.MaxAge)
                .Search(employeeParametrs.SearchTerm)
                .Sort(employeeParametrs.OrderBy)
                .ToListAsync();

            #region Modified version for better performance for much bigger datas

            //var employees = FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
            //    .FilterEmployees(employeeParametrs.MinAge, employeeParametrs.MaxAge)
            //    .Search(employeeParametrs.SearchTerm);


            //var employeesList = await employees
            //    .OrderBy(e => e.Name)
            //    .Skip((employeeParametrs.PageNumber - 1) * employeeParametrs.PageSize)
            //    .Take(employeeParametrs.PageSize)
            //    .ToListAsync();

            //var count = await employees.CountAsync();

            //return new PagedList<Employee>(employeesList, count, employeeParametrs.PageNumber, employeeParametrs.PageSize);
            #endregion

            return PagedList<Employee>
                .ToPagedList(employees, employeeParametrs.PageNumber, employeeParametrs.PageSize);
        }  
        //here even though we don't provide min or max age, our default values will handle it
        //for minAge = 0
        //for maxAge = int.MaxValue

        public async Task<Employee> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges) =>
            await FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateEmployeeForCompany(Guid companyId, Employee employee)
        {
            employee.CompanyId = companyId;
            Create(employee);
        }

        public void DeleteEmployee(Employee employee) =>
            Delete(employee);
    }
}
