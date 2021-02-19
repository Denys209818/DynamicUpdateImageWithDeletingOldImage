using Hospital.DAL;
using Hospital.WindowsForm.Models.Question;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hospital.WindowsForm
{
    public partial class QuestionForm : Form
    {
        //Список питань
        private List<QuestionModel> _listQuestions;
        //Поточне питання
        private int indexQuestion = 0;
        private bool[] result;
        

        public QuestionForm(MyContext context)
        {
            _listQuestions = new List<QuestionModel>();
                ///context.Questions
                ///.Select(x => new QuestionModel
                ///{
                ///    Text = x.Text,
                ///    Answers = x.Answers.Select(y => new QuestionAnswerModel
                ///    {
                ///        Text=y.Text,
                ///        IsTrue=y.IsTrue
                ///    }).ToList()
                ///}).ToList();
            foreach(var item in context.Questions.ToList())
            {
                QuestionModel question = new QuestionModel
                {
                    Text = item.Text,
                    Answers = new List<QuestionAnswerModel>()
                };
                foreach(var answer in context.Answers
                    .Where(x=>x.QuestionId==item.Id))
                {
                    var answerModel = new QuestionAnswerModel
                    {
                        Text = answer.Text,
                        IsTrue = answer.IsTrue
                    };
                    question.Answers.Add(answerModel);
                }
                _listQuestions.Add(question);
            }

            ///_listQuestions = new List<QuestionModel>
            ///{
            ///    new QuestionModel
            ///    {
            ///        Text = "Коли Гагарін призимлився перший раз?",
            ///        Answers = new List<QuestionAnswerModel>
            ///        {
            ///           new QuestionAnswerModel
            ///           {
            ///               Text = "23 жовтня 2003р.",
            ///               IsTrue = false
            ///           },
            ///           new QuestionAnswerModel
            ///           {
            ///               Text = "1 вересня 1973р.",
            ///               IsTrue = false
            ///           },
            ///           new QuestionAnswerModel
            ///           {
            ///               Text = "30 лютого 1961р.",
            ///               IsTrue = false
            ///           },
            ///           new QuestionAnswerModel
            ///           {
            ///               Text = "12 квітня 1961р.",
            ///               IsTrue = true
            ///           },
            ///        }
            ///    },
            ///    new QuestionModel
            ///    {
            ///        Text = "Коли родився Шевченко?",
            ///        Answers = new List<QuestionAnswerModel>
            ///        {
            ///           new QuestionAnswerModel
            ///           {
            ///               Text = "23 жовтня 1894р.",
            ///               IsTrue = false
            ///           },
            ///           new QuestionAnswerModel
            ///           {
            ///               Text = "1 вересня 1973р.",
            ///               IsTrue = false
            ///           },
            ///           new QuestionAnswerModel
            ///           {
            ///               Text = "9 березня 1814р.",
            ///               IsTrue = true
            ///           },
            ///           new QuestionAnswerModel
            ///           {
            ///               Text = "12 квітня 1961р.",
            ///               IsTrue = false
            ///           },
            ///        }
            ///    }
            ///};
            InitializeComponent();
            result = new bool[_listQuestions.Count];
            
        }

        /// <summary>
        /// Початкова загрузка
        /// </summary>
        private void LoadQuestion()
        {
            lblQuestion.Text = _listQuestions[indexQuestion].Text;
            var answers = _listQuestions[indexQuestion].Answers;
            int dy = 25;
            int startPosition = 30;
            gbAnswers.Controls.Clear();
            for (int i=0;i<answers.Count;i++)
            {
                RadioButton gbOneItem;
                gbOneItem = new System.Windows.Forms.RadioButton();
                gbOneItem.AutoSize = true;
                gbOneItem.Location = new System.Drawing.Point(25, startPosition);
                gbOneItem.Name = $"gbItem{i}";
                gbOneItem.Tag = answers[i];
                gbOneItem.Size = new System.Drawing.Size(67, 19);
                gbOneItem.TabIndex = 1;
                gbOneItem.TabStop = true;
                gbOneItem.Text = answers[i].Text;
                gbOneItem.UseVisualStyleBackColor = true;
                gbAnswers.Controls.Add(gbOneItem);
                startPosition += dy;
            }
            lblNumberQuestion.Text = $"Питання {indexQuestion + 1} з {_listQuestions.Count}";
            
        }

        private void QuestionForm_Load(object sender, EventArgs e)
        {
            LoadQuestion();
            
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            
            var radioButtons = gbAnswers.Controls.OfType<RadioButton>();
            foreach (RadioButton rb in radioButtons)
            {

                if(rb.Checked)
                {
                    var answer = rb.Tag as QuestionAnswerModel;
                    result[indexQuestion] = answer.IsTrue;
                }
                //bool state = rb.Checked;
                //string name = rb.Name;
            }

            //Чи правильно ми відповіли на 1 перше питання.
            //MessageBox.Show("Ви відповіли? ", result[indexQuestion].ToString());

            indexQuestion++;

            if(indexQuestion<_listQuestions.Count)
            {
                LoadQuestion();
            }
            else
            {
                this.Close();
                ResultForm rf = new ResultForm(result);
                rf.ShowDialog();
            }
            
        }
    }
}


//if (indexQuestion > 5)
//{
//    this.Close();
//}