 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PersonalityProfilerDTO
{
    public class Test
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public String Type { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DateTaken { get; set; }

        [StringLength(200)]
        public String TestState { get; set; }



    }
}
