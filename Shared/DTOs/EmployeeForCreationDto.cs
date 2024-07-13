using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public record EmployeeForCreationDto : EmployeeForManipulationDto;
}

//public record EmployeeForCreationDto(string Name, int Age, string Position)

/*
 This is a positional record. The reason we used init setters instead of this structure is because
positional records can lose their readability once we add the validation rules. 
 */
