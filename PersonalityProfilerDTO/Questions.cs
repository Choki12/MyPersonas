using System;
using System.ComponentModel.DataAnnotations;


namespace PersonalityProfilerDTO
{
    public class Questions
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public String Question { get; set; }

        [StringLength(500)]
        public String State { get; set; }

        public int Number { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(500)]
        public String Answer { get; set; }




    }
}
