
namespace Hospital.WindowsForm
{
    partial class ResultForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCountQuestions = new System.Windows.Forms.Label();
            this.lblRightAnswers = new System.Windows.Forms.Label();
            this.lblWrongAnswers = new System.Windows.Forms.Label();
            this.lblMark = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(124, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(164, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Тест завершено!";
            // 
            // lblCountQuestions
            // 
            this.lblCountQuestions.AutoSize = true;
            this.lblCountQuestions.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCountQuestions.Location = new System.Drawing.Point(25, 75);
            this.lblCountQuestions.Name = "lblCountQuestions";
            this.lblCountQuestions.Size = new System.Drawing.Size(216, 21);
            this.lblCountQuestions.TabIndex = 1;
            this.lblCountQuestions.Text = "Всього пройдено запитань:";
            // 
            // lblRightAnswers
            // 
            this.lblRightAnswers.AutoSize = true;
            this.lblRightAnswers.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRightAnswers.Location = new System.Drawing.Point(25, 107);
            this.lblRightAnswers.Name = "lblRightAnswers";
            this.lblRightAnswers.Size = new System.Drawing.Size(200, 21);
            this.lblRightAnswers.TabIndex = 1;
            this.lblRightAnswers.Text = "Правильних відповідень:";
            // 
            // lblWrongAnswers
            // 
            this.lblWrongAnswers.AutoSize = true;
            this.lblWrongAnswers.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWrongAnswers.Location = new System.Drawing.Point(25, 142);
            this.lblWrongAnswers.Name = "lblWrongAnswers";
            this.lblWrongAnswers.Size = new System.Drawing.Size(218, 21);
            this.lblWrongAnswers.TabIndex = 1;
            this.lblWrongAnswers.Text = "Неправильних відповідень:";
            // 
            // lblMark
            // 
            this.lblMark.AutoSize = true;
            this.lblMark.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMark.ForeColor = System.Drawing.Color.Blue;
            this.lblMark.Location = new System.Drawing.Point(25, 190);
            this.lblMark.Name = "lblMark";
            this.lblMark.Size = new System.Drawing.Size(119, 21);
            this.lblMark.TabIndex = 1;
            this.lblMark.Text = "Оцінка за тест:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "(за 12-бальною шкалою)";
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 259);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMark);
            this.Controls.Add(this.lblWrongAnswers);
            this.Controls.Add(this.lblRightAnswers);
            this.Controls.Add(this.lblCountQuestions);
            this.Controls.Add(this.lblTitle);
            this.Name = "ResultForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ResultForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCountQuestions;
        private System.Windows.Forms.Label lblRightAnswers;
        private System.Windows.Forms.Label lblWrongAnswers;
        private System.Windows.Forms.Label lblMark;
        private System.Windows.Forms.Label label1;
    }
}