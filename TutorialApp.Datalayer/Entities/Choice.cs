using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialApp.Datalayer.Entities
{
    public class Choice
    {
        [Key]
        public long ChoiceId { get; set; }

        [Display(Name = "content of choice")]
        [Required(ErrorMessage = "The {0} must not be empty.")]
        public string Content { get; set; }

        public bool IsCorrect { get; set; }



        #region Relations
        //Foreign key with Question
        public virtual long QuestionId { get; set; }
        public virtual Question Question { get; set; }
        #endregion
    }
}
