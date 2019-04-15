using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GeographyWebScraper
{
    partial class Form1
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
            this.GenerateFile = new System.Windows.Forms.Button();
            this.InputHtmlBox = new System.Windows.Forms.MaskedTextBox();
            this.inputHTMLLabel = new System.Windows.Forms.Label();
            this.saveFileLabel = new System.Windows.Forms.Label();
            this.saveFileBox = new System.Windows.Forms.MaskedTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.LoadQuiz = new System.Windows.Forms.Button();
            this.Q1 = new System.Windows.Forms.Label();
            this.Q2 = new System.Windows.Forms.Label();
            this.Q4 = new System.Windows.Forms.Label();
            this.Q3 = new System.Windows.Forms.Label();
            this.Q8 = new System.Windows.Forms.Label();
            this.Q7 = new System.Windows.Forms.Label();
            this.Q6 = new System.Windows.Forms.Label();
            this.Q5 = new System.Windows.Forms.Label();
            this.Q10 = new System.Windows.Forms.Label();
            this.Q9 = new System.Windows.Forms.Label();
            this.IQ5 = new System.Windows.Forms.Label();
            this.IQ4 = new System.Windows.Forms.Label();
            this.IQ3 = new System.Windows.Forms.Label();
            this.IQ2 = new System.Windows.Forms.Label();
            this.IQ1 = new System.Windows.Forms.Label();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.QuestionLabel = new System.Windows.Forms.Label();
            this.numQuestions = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // GenerateFile
            // 
            this.GenerateFile.Location = new System.Drawing.Point(46, 193);
            this.GenerateFile.Name = "GenerateFile";
            this.GenerateFile.Size = new System.Drawing.Size(75, 23);
            this.GenerateFile.TabIndex = 0;
            this.GenerateFile.Text = "GenerateFile";
            this.GenerateFile.UseVisualStyleBackColor = true;
            this.GenerateFile.Click += new System.EventHandler(this.generateFileClick);
            // 
            // InputHtmlBox
            // 
            this.InputHtmlBox.Location = new System.Drawing.Point(12, 28);
            this.InputHtmlBox.Name = "InputHtmlBox";
            this.InputHtmlBox.Size = new System.Drawing.Size(289, 20);
            this.InputHtmlBox.TabIndex = 1;
            this.InputHtmlBox.Text = "Quiz1";
            //this.InputHtmlBox.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox1_MaskInputRejected);
            // 
            // label1
            // 
            this.inputHTMLLabel.AutoSize = true;
            this.inputHTMLLabel.Location = new System.Drawing.Point(12, 9);
            this.inputHTMLLabel.Name = "label1";
            this.inputHTMLLabel.Size = new System.Drawing.Size(52, 13);
            this.inputHTMLLabel.TabIndex = 2;
            this.inputHTMLLabel.Text = "InputHtml";
            // 
            // label2
            // 
            this.saveFileLabel.AutoSize = true;
            this.saveFileLabel.Location = new System.Drawing.Point(12, 71);
            this.saveFileLabel.Name = "label2";
            this.saveFileLabel.Size = new System.Drawing.Size(48, 13);
            this.saveFileLabel.TabIndex = 4;
            this.saveFileLabel.Text = "SaveFile";
            
            // 
            // saveFileBox
            // 
            this.saveFileBox.Location = new System.Drawing.Point(12, 90);
            this.saveFileBox.Name = "saveFileBox";
            this.saveFileBox.Size = new System.Drawing.Size(289, 20);
            this.saveFileBox.TabIndex = 3;
            this.saveFileBox.Text = "SaveFile1";
            
            // 
            // backgroundWorker1
            // 
            //this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // LoadQuiz
            // 
            this.LoadQuiz.Location = new System.Drawing.Point(165, 193);
            this.LoadQuiz.Name = "LoadQuiz";
            this.LoadQuiz.Size = new System.Drawing.Size(75, 23);
            this.LoadQuiz.TabIndex = 5;
            this.LoadQuiz.Text = "LoadQuiz";
            this.LoadQuiz.UseVisualStyleBackColor = true;
            this.LoadQuiz.Click += new System.EventHandler(this.loadQuiz_Click);
            // 
            // Q1
            // 
            this.Q1.AutoSize = true;
            this.Q1.Location = new System.Drawing.Point(450, 28);
            this.Q1.Name = "Q1";
            this.Q1.Size = new System.Drawing.Size(97, 13);
            this.Q1.TabIndex = 6;
            this.Q1.Text = "1: Example Answer";
            this.Q1.Click += new System.EventHandler(this.Q1_Click);
            // 
            // Q2
            // 
            this.Q2.AutoSize = true;
            this.Q2.Location = new System.Drawing.Point(450, 41);
            this.Q2.Name = "Q2";
            this.Q2.Size = new System.Drawing.Size(97, 13);
            this.Q2.TabIndex = 7;
            this.Q2.Text = "2: Example Answer";
            this.Q2.Click += new System.EventHandler(this.Q2_Click);
            // 
            // Q4
            // 
            this.Q4.AutoSize = true;
            this.Q4.Location = new System.Drawing.Point(450, 67);
            this.Q4.Name = "Q4";
            this.Q4.Size = new System.Drawing.Size(97, 13);
            this.Q4.TabIndex = 9;
            this.Q4.Text = "4: Example Answer";
            this.Q4.Click += new System.EventHandler(this.Q4_Click);
            // 
            // Q3
            // 
            this.Q3.AutoSize = true;
            this.Q3.Location = new System.Drawing.Point(450, 54);
            this.Q3.Name = "Q3";
            this.Q3.Size = new System.Drawing.Size(97, 13);
            this.Q3.TabIndex = 8;
            this.Q3.Text = "3: Example Answer";
            this.Q3.Click += new System.EventHandler(this.Q3_Click);
            // 
            // Q8
            // 
            this.Q8.AutoSize = true;
            this.Q8.Location = new System.Drawing.Point(450, 119);
            this.Q8.Name = "Q8";
            this.Q8.Size = new System.Drawing.Size(97, 13);
            this.Q8.TabIndex = 13;
            this.Q8.Text = "8: Example Answer";
            this.Q8.Click += new System.EventHandler(this.Q8_Click);
            // 
            // Q7
            // 
            this.Q7.AutoSize = true;
            this.Q7.Location = new System.Drawing.Point(450, 106);
            this.Q7.Name = "Q7";
            this.Q7.Size = new System.Drawing.Size(97, 13);
            this.Q7.TabIndex = 12;
            this.Q7.Text = "7: Example Answer";
            this.Q7.Click += new System.EventHandler(this.Q7_Click);
            // 
            // Q6
            // 
            this.Q6.AutoSize = true;
            this.Q6.Location = new System.Drawing.Point(450, 93);
            this.Q6.Name = "Q6";
            this.Q6.Size = new System.Drawing.Size(97, 13);
            this.Q6.TabIndex = 11;
            this.Q6.Text = "6: Example Answer";
            this.Q6.Click += new System.EventHandler(this.Q6_Click);
            // 
            // Q5
            // 
            this.Q5.AutoSize = true;
            this.Q5.Location = new System.Drawing.Point(450, 80);
            this.Q5.Name = "Q5";
            this.Q5.Size = new System.Drawing.Size(97, 13);
            this.Q5.TabIndex = 10;
            this.Q5.Text = "5: Example Answer";
            this.Q5.Click += new System.EventHandler(this.Q5_Click);
            // 
            // Q10
            // 
            this.Q10.AutoEllipsis = true;
            this.Q10.AutoSize = true;
            this.Q10.Location = new System.Drawing.Point(450, 145);
            this.Q10.Name = "Q10";
            this.Q10.Size = new System.Drawing.Size(103, 13);
            this.Q10.TabIndex = 15;
            this.Q10.Text = "10: Example Answer";
            this.Q10.Click += new System.EventHandler(this.Q10_Click);
            // 
            // Q9
            // 
            this.Q9.AutoSize = true;
            this.Q9.Location = new System.Drawing.Point(450, 132);
            this.Q9.Name = "Q9";
            this.Q9.Size = new System.Drawing.Size(97, 13);
            this.Q9.TabIndex = 14;
            this.Q9.Text = "9: Example Answer";
            this.Q9.Click += new System.EventHandler(this.Q9_Click);
            // 
            // IQ5
            // 
            this.IQ5.AutoSize = true;
            this.IQ5.Location = new System.Drawing.Point(450, 359);
            this.IQ5.Name = "IQ5";
            this.IQ5.Size = new System.Drawing.Size(97, 13);
            this.IQ5.TabIndex = 21;
            this.IQ5.Text = "5: Example Answer";
            // 
            // IQ4
            // 
            this.IQ4.AutoSize = true;
            this.IQ4.Location = new System.Drawing.Point(450, 346);
            this.IQ4.Name = "IQ4";
            this.IQ4.Size = new System.Drawing.Size(97, 13);
            this.IQ4.TabIndex = 20;
            this.IQ4.Text = "4: Example Answer";
            // 
            // IQ3
            // 
            this.IQ3.AutoSize = true;
            this.IQ3.Location = new System.Drawing.Point(450, 333);
            this.IQ3.Name = "IQ3";
            this.IQ3.Size = new System.Drawing.Size(97, 13);
            this.IQ3.TabIndex = 19;
            this.IQ3.Text = "3: Example Answer";
            // 
            // IQ2
            // 
            this.IQ2.AutoSize = true;
            this.IQ2.Location = new System.Drawing.Point(450, 320);
            this.IQ2.Name = "IQ2";
            this.IQ2.Size = new System.Drawing.Size(97, 13);
            this.IQ2.TabIndex = 18;
            this.IQ2.Text = "2: Example Answer";
            // 
            // IQ1
            // 
            this.IQ1.AutoSize = true;
            this.IQ1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.IQ1.Location = new System.Drawing.Point(450, 307);
            this.IQ1.Name = "IQ1";
            this.IQ1.Size = new System.Drawing.Size(97, 13);
            this.IQ1.TabIndex = 17;
            this.IQ1.Text = "1: Example Answer";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.Path = "D:\\GeographyPageDownloads";
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
            // 
            // QuestionLabel
            // 
            this.QuestionLabel.AutoSize = true;
            this.QuestionLabel.Location = new System.Drawing.Point(427, 277);
            this.QuestionLabel.Name = "QuestionLabel";
            this.QuestionLabel.Size = new System.Drawing.Size(104, 13);
            this.QuestionLabel.TabIndex = 22;
            this.QuestionLabel.Text = "What is the ...";
            // 
            // numQuestions
            // 
            this.numQuestions.AutoSize = true;
            this.numQuestions.Location = new System.Drawing.Point(12, 425);
            this.numQuestions.Name = "numQuestions";
            this.numQuestions.Size = new System.Drawing.Size(35, 13);
            this.numQuestions.TabIndex = 23;
            this.numQuestions.Text = "label3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.numQuestions);
            this.Controls.Add(this.QuestionLabel);
            this.Controls.Add(this.IQ5);
            this.Controls.Add(this.IQ4);
            this.Controls.Add(this.IQ3);
            this.Controls.Add(this.IQ2);
            this.Controls.Add(this.IQ1);
            this.Controls.Add(this.Q10);
            this.Controls.Add(this.Q9);
            this.Controls.Add(this.Q8);
            this.Controls.Add(this.Q7);
            this.Controls.Add(this.Q6);
            this.Controls.Add(this.Q5);
            this.Controls.Add(this.Q4);
            this.Controls.Add(this.Q3);
            this.Controls.Add(this.Q2);
            this.Controls.Add(this.Q1);
            this.Controls.Add(this.LoadQuiz);
            this.Controls.Add(this.saveFileLabel);
            this.Controls.Add(this.saveFileBox);
            this.Controls.Add(this.inputHTMLLabel);
            this.Controls.Add(this.InputHtmlBox);
            this.Controls.Add(this.GenerateFile);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        public int curQuestionView = 0;

        public List<Question> questions = new List<Question>();
        public List<Question> curQuestions = new List<Question>();
        


        public System.Windows.Forms.Button GenerateFile;
        public System.Windows.Forms.MaskedTextBox InputHtmlBox;
        public System.Windows.Forms.Label inputHTMLLabel;
        public System.Windows.Forms.Label saveFileLabel;
        public System.Windows.Forms.MaskedTextBox saveFileBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button LoadQuiz;
        private System.Windows.Forms.Label Q1;
        private System.Windows.Forms.Label Q2;
        private System.Windows.Forms.Label Q4;
        private System.Windows.Forms.Label Q3;
        private System.Windows.Forms.Label Q8;
        private System.Windows.Forms.Label Q7;
        private System.Windows.Forms.Label Q6;
        private System.Windows.Forms.Label Q5;
        private System.Windows.Forms.Label Q10;
        private System.Windows.Forms.Label Q9;
        private System.Windows.Forms.Label IQ5;
        private System.Windows.Forms.Label IQ4;
        private System.Windows.Forms.Label IQ3;
        private System.Windows.Forms.Label IQ2;
        private System.Windows.Forms.Label IQ1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private Label QuestionLabel;
        private Label numQuestions;
    }
}

