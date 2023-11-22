using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AadhaarVerification.Models
{
    public class Data
    {
        [Key]
        public int id { get; set; }
        [Required]

        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Phone]
        [MinLength(10)]
        [MaxLength(10)]
        public string Phone { get; set; }
        [Required]
        [MinLength(12)]
        [MaxLength(12)]
        public string Aadhar { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string DocumnetPath { get; set; }

    }
}
