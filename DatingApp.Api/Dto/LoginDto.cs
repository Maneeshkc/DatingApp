using System.ComponentModel.DataAnnotations;

namespace DatingApp.Api.Dto
{
    public class LoginDto
    {
        [Required]
        [StringLength(10,MinimumLength=4,ErrorMessage="limit")]
        public string UserName { get; set; }

        [Required]
        [StringLength(10,MinimumLength=4,ErrorMessage="limit")]
        public string Password { get; set; }
    }
}