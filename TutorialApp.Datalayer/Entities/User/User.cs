using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialApp.Datalayer.Entities.User
{
    public class User
    {
        public User()
        {
            
        }


        [Key]
        public long UserId { get; set; }

        [Display(Name = "username")]
        [Required(ErrorMessage = "The {0} must not be empty.")]
        [MaxLength(30, ErrorMessage = "The {0} can not be more than {1} characters.")]
        public string Username { get; set; }


        [Display(Name = "email")]
        [Required(ErrorMessage = "The {0} must not be empty.")]
        [MaxLength(100, ErrorMessage = "The {0} can not be more than {1} characters.")]
        [EmailAddress(ErrorMessage = "Email address is not valid.")]
        public string Email { get; set; }

        [Display(Name = "password")]
        [Required(ErrorMessage = "The {0} must not be empty.")]
        [MaxLength(100, ErrorMessage = "The {0} can not be more than {1} characters.")]
        public string Password { get; set; }

        [Display(Name = "status")]
        public bool IsActive { get; set; }

        [Display(Name = "activation code")]
        public string ActiveCode { get; set; }

        [Display(Name = "user avatar")]
        public string UserAvatar { get; set; }

        [Display(Name = "date of registration")]
        public DateTime RegisterDate { get; set; }



        #region Relations

        public virtual ICollection<UserRole> UserRole { get; set; }
        #endregion
    }
}
