using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData(
                new Company
                {
                    Id = new Guid("67618A77-5871-4AED-B49C-324810B4FA4B"),
                    Name = "IT_Solutions Ltd",
                    Address = "583 Wall Dr. Gwynn Oak, MD 21207",
                    Country = "USA"
                },
                new Company
                {
                    Id = new Guid("6113AA17-B2B3-49E1-A14D-A9BF787A7954"),
                    Name = "Admin_Solutions Ltd",
                    Address = "312 Forest Avenue, BF 923",
                    Country = "USA"
                }
            );
        }
    }
}
