using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalityProfilerDTO
{
    /*
     * API Controller should only interact with the DB
     */
    public class TesteeResponse : Testee
    {
        public ICollection<Test> Test { get; set; } = new List<Test>();
    }
}
