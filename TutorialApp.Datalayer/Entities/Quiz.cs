using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialApp.Datalayer.Entities
{
    public class Quiz
    {
        [Key]
        public long QuizId { get; set; }
        [Display(Name = "title of quiz")]
        [Required(ErrorMessage = "The {0} must not be empty.")]
        [MaxLength(100, ErrorMessage = "The {0} can not be more than {1} characters.")]
        public string Title { get; set; }




        #region Relations
        //Relation Question
        public virtual ICollection<Question> Questions { get; set; }
        //Foreign key with Course
        public virtual long CourseId { get; set; }
        public virtual Course Course { get; set; }
        #endregion
    }
}
