using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hospital.DAL
{
    [Table ("tblAnswers")]
    public class Answer
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(1000)]
        public string Text { get; set; }

        public bool IsTrue { get; set; }

        [ForeignKey ("Question")]
        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }

        public virtual ICollection<Result> Results { get; set; }
    }
}
