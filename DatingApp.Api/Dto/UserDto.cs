using System;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.Api.Dto
{
    public class UserDto
    {
        [Required]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "atleast 4 and upto 10 charcters")]
        public string UserName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "atleast 4 and upto 10 charcters")]

        public string Password { get; set; }
    }

    public class ProfileDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string KnownAs { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? LastActive { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public string ProfileUrl { get; set; }

    }
}