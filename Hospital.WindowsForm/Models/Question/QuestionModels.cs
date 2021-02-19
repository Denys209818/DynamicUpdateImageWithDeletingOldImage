using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.WindowsForm.Models.Question
{
    /// <summary>
    /// Питання
    /// </summary>
    public class QuestionModel
    {
        public string Text { get; set; }
        public List<QuestionAnswerModel> Answers { get; set; }
    }

    /// <summary>
    /// Варіанти відповіді
    /// </summary>
    public class QuestionAnswerModel
    {
        public string Text { get; set; }
        public bool IsTrue { get; set; }
    }
}
