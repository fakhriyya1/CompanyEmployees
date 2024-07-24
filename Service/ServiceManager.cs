using AutoMapper;
using Contracts;
using Service.Contracts;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICompanyService> _companyService;
        private readonly Lazy<IEmployeeService> _employeeService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper, IDataShaper<EmployeeDto> dataShaper)
        {
            _companyService=new Lazy<ICompanyService>(()=>new CompanyService(repositoryManager, loggerManager, mapper));
            _employeeService = new Lazy<IEmployeeService>(()=>new EmployeeService(repositoryManager, loggerManager, mapper, dataShaper)); 
        }

        public ICompanyService CompanyService => _companyService.Value;  // as long as we don't call the value of the instance, it won't be initialized

        public IEmployeeService EmployeeService => _employeeService.Value;
    }
}
