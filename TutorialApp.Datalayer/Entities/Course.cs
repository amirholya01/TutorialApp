using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialApp.Datalayer.Entities
{
    public class Course
    {
        //id title description publishDate
        [Key]
        public long CourseId { get; set; }


        [Display(Name = "title")]
        [Required(ErrorMessage = "The {0} must not be empty.")]
        [MaxLength(100, ErrorMessage = "The {0} can not be more than {1} characters.")]
        public string Title { get; set; }


        [Display(Name = "description")]
        [Required(ErrorMessage = "The {0} must not be empty.")]
        [MinLength(10, ErrorMessage = "The {0} can not be less than {1} characters.")]
        public string Description { get; set; }


        [Display(Name = "date of publish")]
        public DateTime PublishDate { get; set; }


        #region Relations
        //Relation with video
        public virtual ICollection<Video> Videos { get; set; }

        //Relation with text
        public virtual ICollection<Text> Texts { get; set; }

        //Relation with quiz
        public virtual ICollection<Quiz>Quizzes { get; set; }
        #endregion

    }
}
