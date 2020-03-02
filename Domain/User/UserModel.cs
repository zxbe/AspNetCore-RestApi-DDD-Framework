using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using Domain.Base;

namespace Domain.User
{
    public class UserModel : BaseModel
    {
        /// <summary>
        /// User first name
        /// </summary>
        [Required]
        [MaxLength(20)]
        [MinLength(1)]
        public string NameFirst { get; set; }
        /// <summary>
        /// User second name
        /// </summary>
        [Required]
        [MaxLength(20)]
        [MinLength(1)]
        public string NameSecond { get; set; }
        /// <summary>
        /// User patronymic name
        /// </summary>
        [MaxLength(20)]
        public string NamePatronymic { get; set; }
        /// <summary>
        /// User phone
        /// </summary>
        [MaxLength(20)]
        [MinLength(10)]
        [Phone]
        public string Phone { get; set; }
        /// <summary>
        /// User Email
        /// </summary>
        [Required]
        [MinLength(6)]
        [MaxLength(20)]
        [EmailAddress]
        public string Email { get; set; }
        /// <summary>
        /// User Password
        /// </summary>
        [Required]
        [MinLength(6)]
        [MaxLength(50)]
        [JsonIgnore]
        public string Password { get; set; }
    }
    
}