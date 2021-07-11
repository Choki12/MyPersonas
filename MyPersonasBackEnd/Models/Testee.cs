using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyPersonasBackEnd.Models
{
    /*Class representing the test taker*/
    public class Testee
    {
        [Key] //Object Relational Mapping in Entity Framework infers by the attribute name Id that this will be the PK in Testee
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public String Name { get; set; }

        [StringLength(200)]
        public String Surname { get; set; }

        [StringLength(400)]
        public String Email { get; set; }

        [StringLength(400)]
        public String DOB { get; set; }

        [StringLength(400)]
        public String UserName { get; set; }






    }
}
