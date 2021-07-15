using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPersonasBackEnd.Data
{
    /*
     * Each question can be linked to a specific test, each test can be linked to a specific user
     */
    public class TestQuestion: PersonalityProfilerDTO.Questions
    {
        public int TestId { get; set; }

        public Test Test { get; set; }

        public int QuestionId { get; set; }

        public Questions Questions { get; set; }


    }
}
