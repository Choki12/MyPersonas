using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalityProfilerDTO
{
    /*Class representing the test taker*/
    public class Testee
    {
        [Key] //Object Relational Mapping in Entity Framework infers by the attribute name Id that this will be the PK in Testee
        public int Id { get; set; }

        /// <summary>
        /// Name of Personality Assessment Taker
        /// </summary>
        [Required]
        [StringLength(200)]
        public String Name { get; set; }

        /// <summary>
        /// Surname of Personality Assessment Taker
        /// </summary>
        [StringLength(200)]
        public String Surname { get; set; }

        /// <summary>
        /// Email of assessment taker
        /// </summary>
        [StringLength(400)]
        public String Email { get; set; }


        /// <summary>
        /// Date of Birth of the assessment taker
        /// </summary>
        [StringLength(400)]
        public String DOB { get; set; }


        /// <summary>
        /// Username of the assessment taker
        /// </summary>
        [StringLength(400)]
        public String UserName { get; set; }






    }
}
