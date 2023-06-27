using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vmmsolutions.School.Domain.Entities.Enums;

namespace Vmmsolutions.School.Application.Dto.Acceptances
{
    public class AcceptancePostDto
    {
        public required string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool Agreed { get; set; }
        public AcceptanceEnumDto Type { get; set; }
    }
}
