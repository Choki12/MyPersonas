using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalityProfilerDTO
{
    public class TestResponse : Test
    {
        public List<Questions> Questions { get; set; } = new List<Questions>();
        public List<Testee> Testees { get; set; } = new List<Testee>();
    }
}
