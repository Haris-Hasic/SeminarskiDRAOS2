namespace JapaneseLearningApp
{
    partial class StoryPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lJapaneseTitle = new System.Windows.Forms.Label();
            this.bPreviousLecture = new System.Windows.Forms.Button();
            this.bLectures = new System.Windows.Forms.Button();
            this.bVocabulary = new System.Windows.Forms.Button();
            this.pJapanese = new System.Windows.Forms.Panel();
            this.lJapaneseText = new System.Windows.Forms.Label();
            this.pEnglish = new System.Windows.Forms.Panel();
            this.lEnglishText = new System.Windows.Forms.Label();
            this.lEnglishTitle = new System.Windows.Forms.Label();
            this.pJapanese.SuspendLayout();
            this.pEnglish.SuspendLayout();
            this.SuspendLayout();
            // 
            // lJapaneseTitle
            // 
            this.lJapaneseTitle.AutoSize = true;
            this.lJapaneseTitle.Font = new System.Drawing.Font("Berlin Sans FB", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lJapaneseTitle.ForeColor = System.Drawing.Color.White;
            this.lJapaneseTitle.Location = new System.Drawing.Point(78, 39);
            this.lJapaneseTitle.Name = "lJapaneseTitle";
            this.lJapaneseTitle.Size = new System.Drawing.Size(269, 32);
            this.lJapaneseTitle.TabIndex = 2;
            this.lJapaneseTitle.Text = "Story Title - Japanese";
            // 
            // bPreviousLecture
            // 
            this.bPreviousLecture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.bPreviousLecture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bPreviousLecture.Font = new System.Drawing.Font("Berlin Sans FB", 18.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPreviousLecture.ForeColor = System.Drawing.Color.White;
            this.bPreviousLecture.Location = new System.Drawing.Point(4, 522);
            this.bPreviousLecture.Name = "bPreviousLecture";
            this.bPreviousLecture.Size = new System.Drawing.Size(128, 75);
            this.bPreviousLecture.TabIndex = 19;
            this.bPreviousLecture.Text = "Previous Lecture";
            this.bPreviousLecture.UseVisualStyleBackColor = false;
            // 
            // bLectures
            // 
            this.bLectures.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.bLectures.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bLectures.Font = new System.Drawing.Font("Berlin Sans FB", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bLectures.ForeColor = System.Drawing.Color.White;
            this.bLectures.Location = new System.Drawing.Point(136, 522);
            this.bLectures.Name = "bLectures";
            this.bLectures.Size = new System.Drawing.Size(129, 75);
            this.bLectures.TabIndex = 20;
            this.bLectures.Text = "Lectures";
            this.bLectures.UseVisualStyleBackColor = false;
            this.bLectures.Click += new System.EventHandler(this.bLectures_Click);
            // 
            // bVocabulary
            // 
            this.bVocabulary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.bVocabulary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bVocabulary.Font = new System.Drawing.Font("Berlin Sans FB", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bVocabulary.ForeColor = System.Drawing.Color.White;
            this.bVocabulary.Location = new System.Drawing.Point(269, 522);
            this.bVocabulary.Name = "bVocabulary";
            this.bVocabulary.Size = new System.Drawing.Size(128, 75);
            this.bVocabulary.TabIndex = 21;
            this.bVocabulary.Text = "Vocab";
            this.bVocabulary.UseVisualStyleBackColor = false;
            this.bVocabulary.Click += new System.EventHandler(this.bVocabulary_Click);
            // 
            // pJapanese
            // 
            this.pJapanese.AutoScroll = true;
            this.pJapanese.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pJapanese.Controls.Add(this.lJapaneseText);
            this.pJapanese.Location = new System.Drawing.Point(4, 128);
            this.pJapanese.Name = "pJapanese";
            this.pJapanese.Size = new System.Drawing.Size(393, 182);
            this.pJapanese.TabIndex = 22;
            // 
            // lJapaneseText
            // 
            this.lJapaneseText.AutoSize = true;
            this.lJapaneseText.Font = new System.Drawing.Font("Berlin Sans FB", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lJapaneseText.ForeColor = System.Drawing.Color.White;
            this.lJapaneseText.Location = new System.Drawing.Point(9, 12);
            this.lJapaneseText.MaximumSize = new System.Drawing.Size(360, 0);
            this.lJapaneseText.Name = "lJapaneseText";
            this.lJapaneseText.Size = new System.Drawing.Size(179, 21);
            this.lJapaneseText.TabIndex = 24;
            this.lJapaneseText.Text = "Story Text - Japanese";
            // 
            // pEnglish
            // 
            this.pEnglish.AutoScroll = true;
            this.pEnglish.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pEnglish.Controls.Add(this.lEnglishText);
            this.pEnglish.Location = new System.Drawing.Point(4, 319);
            this.pEnglish.Name = "pEnglish";
            this.pEnglish.Size = new System.Drawing.Size(393, 182);
            this.pEnglish.TabIndex = 23;
            // 
            // lEnglishText
            // 
            this.lEnglishText.AutoSize = true;
            this.lEnglishText.Font = new System.Drawing.Font("Berlin Sans FB", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lEnglishText.ForeColor = System.Drawing.Color.White;
            this.lEnglishText.Location = new System.Drawing.Point(9, 15);
            this.lEnglishText.MaximumSize = new System.Drawing.Size(360, 0);
            this.lEnglishText.Name = "lEnglishText";
            this.lEnglishText.Size = new System.Drawing.Size(161, 21);
            this.lEnglishText.TabIndex = 25;
            this.lEnglishText.Text = "Story Text - English";
            // 
            // lEnglishTitle
            // 
            this.lEnglishTitle.AutoSize = true;
            this.lEnglishTitle.Font = new System.Drawing.Font("Berlin Sans FB", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lEnglishTitle.ForeColor = System.Drawing.Color.White;
            this.lEnglishTitle.Location = new System.Drawing.Point(89, 84);
            this.lEnglishTitle.Name = "lEnglishTitle";
            this.lEnglishTitle.Size = new System.Drawing.Size(243, 32);
            this.lEnglishTitle.TabIndex = 24;
            this.lEnglishTitle.Text = "Story Title - English";
            this.lEnglishTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StoryPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.Controls.Add(this.lEnglishTitle);
            this.Controls.Add(this.pEnglish);
            this.Controls.Add(this.pJapanese);
            this.Controls.Add(this.bVocabulary);
            this.Controls.Add(this.bLectures);
            this.Controls.Add(this.bPreviousLecture);
            this.Controls.Add(this.lJapaneseTitle);
            this.Name = "StoryPanel";
            this.Size = new System.Drawing.Size(400, 600);
            this.pJapanese.ResumeLayout(false);
            this.pJapanese.PerformLayout();
            this.pEnglish.ResumeLayout(false);
            this.pEnglish.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lJapaneseTitle;
        private System.Windows.Forms.Button bPreviousLecture;
        private System.Windows.Forms.Button bLectures;
        private System.Windows.Forms.Button bVocabulary;
        private System.Windows.Forms.Panel pJapanese;
        private System.Windows.Forms.Panel pEnglish;
        private System.Windows.Forms.Label lJapaneseText;
        private System.Windows.Forms.Label lEnglishText;
        private System.Windows.Forms.Label lEnglishTitle;
    }
}
