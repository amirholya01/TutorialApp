using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialApp.Datalayer.Entities
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        [Display(Name = "question content")]
        public string Content { get; set; }




        #region Relations
        public virtual ICollection<Choice> Choices { get; set; }
        //Foreign key with Quiz
        public virtual long QuizId { get; set; }
        public virtual Quiz Quiz  { get; set; }
        #endregion
    }
}
