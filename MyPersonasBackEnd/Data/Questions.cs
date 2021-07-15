using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPersonasBackEnd.Data
{
    public class Questions: PersonalityProfilerDTO.Questions
    {
        public virtual ICollection<TestQuestion> TestQuestion { get; set; }
    }
}
