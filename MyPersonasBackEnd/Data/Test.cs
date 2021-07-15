using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPersonasBackEnd.Data
{
    public class Test: PersonalityProfilerDTO.Test
    {
        public virtual ICollection<TesteeTest> TesteeTest { get; set; }
        public virtual ICollection<TestQuestion> TestQuestion { get; set; }
    }
}
