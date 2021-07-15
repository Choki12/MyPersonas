using System;
using System.ComponentModel.DataAnnotations;

namespace MyPersonasBackEnd.Data
{
    public class TesteeTest: PersonalityProfilerDTO.Testee
    {
        public int TesteeId { get; set; }

        public Testee Testee { get; set; }

        public int TestId { get; set; }

        public Test Test { get; set; }

        public int Attempts { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? LastDateTaken { get; set; }

    }
}
