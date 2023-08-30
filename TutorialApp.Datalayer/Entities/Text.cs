using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialApp.Datalayer.Entities
{
    public class Text
    {
        [Key]
        public long TextId { get; set; }


        [Display(Name = "title")]
        [Required(ErrorMessage = "The {0} must not be empty.")]
        [MaxLength(100, ErrorMessage = "The {0} can not be more than {1} characters.")]
        public string Title { get; set; }


        [Display(Name = "content of text")]
        [Required(ErrorMessage = "The {0} must not be empty.")]
        [MinLength(10, ErrorMessage = "The {0} can not be less than {1} characters")]
        public string Content { get; set; }


        #region Relations
        //Foreign key with Course
        public virtual long CourseId {get; set; }
        public virtual Course Course { get; set; }
        #endregion
    }
}
