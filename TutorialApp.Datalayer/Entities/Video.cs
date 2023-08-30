using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialApp.Datalayer.Entities
{
    public class Video
    {
        [Key]
        public long VideoId { get; set; }

        [Display(Name = "title")]
        [Required(ErrorMessage = "The {0} must not be empty.")]
        [MaxLength(255, ErrorMessage = "The {0} can not be more than {1} characters.")]
        public string Title { get; set; }
        [Display(Name = "video-url")]
        public string Url { get; set; }


        #region Relations
        //Foreign key for Course
        public virtual long CourseId { get; set;}
        public virtual Course Course { get; set;}
        #endregion

    }
}
