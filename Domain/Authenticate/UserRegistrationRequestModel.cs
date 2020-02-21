using System.ComponentModel.DataAnnotations;
using Domain.User;

namespace Domain.Authenticate
{
    public class UserRegistrationRequestModel : UserModel
    {
        [Required]
        public string PasswordConfirm { get; set; }
    }
}