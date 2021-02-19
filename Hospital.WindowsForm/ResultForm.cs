using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hospital.WindowsForm
{
    public partial class ResultForm : Form
    {
        private int rightAnswer = 0;
        private int wrongAnswer = 0;
        public ResultForm(bool[] result)
        {
            InitializeComponent();
            for (int i = 0; i < result.Length; i++)
            {
                if(result[i])
                {
                    rightAnswer++;
                }
                else
                {
                    wrongAnswer++;
                }
            }
            lblCountQuestions.Text = $"Всього пройдено запитань: {result.Length}";
            lblRightAnswers.Text = $"Кількість правильних відповідей: {rightAnswer}";
            lblWrongAnswers.Text = $"Кількість неправильних відповідей: {wrongAnswer}";
            int mark = (rightAnswer * 12) / result.Length;
            lblMark.Text = $"Оцінка за проходження тесту: {mark}";



        }

        
    }
}
