namespace JapaneseLearningApp
{
    partial class LectureMenu
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
            this.lTitle = new System.Windows.Forms.Label();
            this.bLectures = new System.Windows.Forms.Button();
            this.bPrevious = new System.Windows.Forms.Button();
            this.bNext = new System.Windows.Forms.Button();
            this.bStory = new System.Windows.Forms.Button();
            this.bVocabulary = new System.Windows.Forms.Button();
            this.bGrammar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Font = new System.Drawing.Font("Berlin Sans FB", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitle.ForeColor = System.Drawing.Color.White;
            this.lTitle.Location = new System.Drawing.Point(139, 37);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(106, 32);
            this.lTitle.TabIndex = 1;
            this.lTitle.Text = "Lecture";
            // 
            // bLectures
            // 
            this.bLectures.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(202)))), ((int)(((byte)(241)))));
            this.bLectures.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bLectures.Font = new System.Drawing.Font("Berlin Sans FB", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bLectures.ForeColor = System.Drawing.Color.White;
            this.bLectures.Location = new System.Drawing.Point(132, 511);
            this.bLectures.Name = "bLectures";
            this.bLectures.Size = new System.Drawing.Size(128, 75);
            this.bLectures.TabIndex = 18;
            this.bLectures.Text = "Lectures";
            this.bLectures.UseVisualStyleBackColor = false;
            this.bLectures.Click += new System.EventHandler(this.bLectures_Click);
            // 
            // bPrevious
            // 
            this.bPrevious.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(202)))), ((int)(((byte)(241)))));
            this.bPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bPrevious.Font = new System.Drawing.Font("Berlin Sans FB", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPrevious.ForeColor = System.Drawing.Color.White;
            this.bPrevious.Location = new System.Drawing.Point(44, 511);
            this.bPrevious.Name = "bPrevious";
            this.bPrevious.Size = new System.Drawing.Size(82, 75);
            this.bPrevious.TabIndex = 19;
            this.bPrevious.Text = "<";
            this.bPrevious.UseVisualStyleBackColor = false;
            this.bPrevious.Click += new System.EventHandler(this.bPrevious_Click);
            // 
            // bNext
            // 
            this.bNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(202)))), ((int)(((byte)(241)))));
            this.bNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bNext.Font = new System.Drawing.Font("Berlin Sans FB", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bNext.ForeColor = System.Drawing.Color.White;
            this.bNext.Location = new System.Drawing.Point(266, 511);
            this.bNext.Name = "bNext";
            this.bNext.Size = new System.Drawing.Size(82, 75);
            this.bNext.TabIndex = 20;
            this.bNext.Text = ">";
            this.bNext.UseVisualStyleBackColor = false;
            this.bNext.Click += new System.EventHandler(this.bNext_Click);
            // 
            // bStory
            // 
            this.bStory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(202)))), ((int)(((byte)(241)))));
            this.bStory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bStory.Font = new System.Drawing.Font("Berlin Sans FB", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bStory.ForeColor = System.Drawing.Color.White;
            this.bStory.Location = new System.Drawing.Point(86, 136);
            this.bStory.Name = "bStory";
            this.bStory.Size = new System.Drawing.Size(225, 75);
            this.bStory.TabIndex = 21;
            this.bStory.Text = "Story";
            this.bStory.UseVisualStyleBackColor = false;
            this.bStory.Click += new System.EventHandler(this.bStory_Click);
            // 
            // bVocabulary
            // 
            this.bVocabulary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(202)))), ((int)(((byte)(241)))));
            this.bVocabulary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bVocabulary.Font = new System.Drawing.Font("Berlin Sans FB", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bVocabulary.ForeColor = System.Drawing.Color.White;
            this.bVocabulary.Location = new System.Drawing.Point(86, 236);
            this.bVocabulary.Name = "bVocabulary";
            this.bVocabulary.Size = new System.Drawing.Size(225, 75);
            this.bVocabulary.TabIndex = 22;
            this.bVocabulary.Text = "Vocabulary";
            this.bVocabulary.UseVisualStyleBackColor = false;
            this.bVocabulary.Click += new System.EventHandler(this.bVocabulary_Click);
            // 
            // bGrammar
            // 
            this.bGrammar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(202)))), ((int)(((byte)(241)))));
            this.bGrammar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bGrammar.Font = new System.Drawing.Font("Berlin Sans FB", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bGrammar.ForeColor = System.Drawing.Color.White;
            this.bGrammar.Location = new System.Drawing.Point(86, 339);
            this.bGrammar.Name = "bGrammar";
            this.bGrammar.Size = new System.Drawing.Size(225, 75);
            this.bGrammar.TabIndex = 23;
            this.bGrammar.Text = "Grammar";
            this.bGrammar.UseVisualStyleBackColor = false;
            this.bGrammar.Click += new System.EventHandler(this.bGrammar_Click);
            // 
            // LectureMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(202)))), ((int)(((byte)(241)))));
            this.Controls.Add(this.bGrammar);
            this.Controls.Add(this.bVocabulary);
            this.Controls.Add(this.bStory);
            this.Controls.Add(this.bNext);
            this.Controls.Add(this.bPrevious);
            this.Controls.Add(this.bLectures);
            this.Controls.Add(this.lTitle);
            this.Name = "LectureMenu";
            this.Size = new System.Drawing.Size(400, 600);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.Button bLectures;
        private System.Windows.Forms.Button bPrevious;
        private System.Windows.Forms.Button bNext;
        private System.Windows.Forms.Button bStory;
        private System.Windows.Forms.Button bVocabulary;
        private System.Windows.Forms.Button bGrammar;
    }
}
