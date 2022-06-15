using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRegistration.Contract.DataContract
{
    public class UserResponseModel
    {
        public int UserName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public int PersonalNumber { get; set; }
        [Required]
        public DateOnly DateOfBirth { get; set; }
        public string Password { get; set; }
        public bool HasValue { get; set; }
    }
}
