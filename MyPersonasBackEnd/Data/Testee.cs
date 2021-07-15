using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyPersonasBackEnd.Data
{
    /*Class representing the test taker*/
    public class Testee : PersonalityProfilerDTO.Testee
    {
        public virtual ICollection<TesteeTest> TesteeTest { get; set; }
        public virtual ICollection<TesteeHistory> TesteeHistory { get; set; }

    }
}
