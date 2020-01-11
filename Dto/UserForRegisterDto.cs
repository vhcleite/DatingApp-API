using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dto
{
    public class UserForRegisterDto
    {
        [Required]
        public string username { get; set; }

        [Required]
        [StringLength(12, 
                    MinimumLength = 4, 
                    ErrorMessage="You password must have between 4 and 12 characters.")]
        public string password { get; set; }
    }
}