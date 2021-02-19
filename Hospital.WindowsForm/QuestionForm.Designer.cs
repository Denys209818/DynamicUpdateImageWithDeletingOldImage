
namespace Hospital.WindowsForm
{
    partial class QuestionForm
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
            this.lblQuestion = new System.Windows.Forms.Label();
            this.gbAnswers = new System.Windows.Forms.GroupBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblNumberQuestion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblQuestion.ForeColor = System.Drawing.Color.Blue;
            this.lblQuestion.Location = new System.Drawing.Point(23, 59);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(77, 21);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.Text = "Питання";
            // 
            // gbAnswers
            // 
            this.gbAnswers.Location = new System.Drawing.Point(23, 94);
            this.gbAnswers.Name = "gbAnswers";
            this.gbAnswers.Size = new System.Drawing.Size(567, 166);
            this.gbAnswers.TabIndex = 2;
            this.gbAnswers.TabStop = false;
            this.gbAnswers.Text = "Варіанти відповіді";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(23, 280);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(97, 35);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Далі >>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblNumberQuestion
            // 
            this.lblNumberQuestion.AutoSize = true;
            this.lblNumberQuestion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNumberQuestion.ForeColor = System.Drawing.Color.Crimson;
            this.lblNumberQuestion.Location = new System.Drawing.Point(23, 9);
            this.lblNumberQuestion.Name = "lblNumberQuestion";
            this.lblNumberQuestion.Size = new System.Drawing.Size(106, 21);
            this.lblNumberQuestion.TabIndex = 0;
            this.lblNumberQuestion.Text = "Питання 1/5";
            // 
            // QuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 337);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.gbAnswers);
            this.Controls.Add(this.lblNumberQuestion);
            this.Controls.Add(this.lblQuestion);
            this.Name = "QuestionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Пройти тест";
            this.Load += new System.EventHandler(this.QuestionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.GroupBox gbAnswers;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblNumberQuestion;
    }
}