using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Repository.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
                new Employee
                {
                    Id = new Guid("E8A67A84-F29D-41A6-93E0-897005C28825"),
                    Name = "Sam Raiden",
                    Age = 26,
                    Position = "Software developer",
                    CompanyId = new Guid("67618A77-5871-4AED-B49C-324810B4FA4B")
                },
                new Employee
                {
                    Id = new Guid("894B46DB-3B0F-43F4-A279-5F1F8F0343B6"),
                    Name = "Jana McLeaf",
                    Age = 30,
                    Position = "Software developer",
                    CompanyId = new Guid("67618A77-5871-4AED-B49C-324810B4FA4B")
                },
                new Employee
                {
                    Id = new Guid("B0699811-6BEF-4F8A-8002-0E913CA4AA6B"),
                    Name = "Kane Miller",
                    Age = 35,
                    Position = "Administrator",
                    CompanyId = new Guid("6113AA17-B2B3-49E1-A14D-A9BF787A7954")
                }
            );
        }
    }
}
