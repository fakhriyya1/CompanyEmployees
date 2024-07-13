using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public record CompanyForUpdateDto(IEnumerable<EmployeeForCreationDto>? Employees) : CompanyForManipulationDto;

    //the last is for inserting resources while updating one

}
