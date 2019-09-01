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
}