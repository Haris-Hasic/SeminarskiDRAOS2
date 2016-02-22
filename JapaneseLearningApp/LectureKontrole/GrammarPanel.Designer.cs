namespace JapaneseLearningApp
{
    partial class GrammarPanel
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
            this.bNextLecture = new System.Windows.Forms.Button();
            this.bVocabulary = new System.Windows.Forms.Button();
            this.bLectures = new System.Windows.Forms.Button();
            this.pGrammar = new System.Windows.Forms.Panel();
            this.lGrammarText = new System.Windows.Forms.Label();
            this.lProgress = new System.Windows.Forms.Label();
            this.bPrevious = new System.Windows.Forms.Button();
            this.bNext = new System.Windows.Forms.Button();
            this.lGrammarTitle = new System.Windows.Forms.Label();
            this.pGrammar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Font = new System.Drawing.Font("Berlin Sans FB", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitle.ForeColor = System.Drawing.Color.White;
            this.lTitle.Location = new System.Drawing.Point(129, 41);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(135, 32);
            this.lTitle.TabIndex = 3;
            this.lTitle.Text = "Grammar";
            // 
            // bNextLecture
            // 
            this.bNextLecture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(120)))), ((int)(((byte)(100)))));
            this.bNextLecture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bNextLecture.Font = new System.Drawing.Font("Berlin Sans FB", 18.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bNextLecture.ForeColor = System.Drawing.Color.White;
            this.bNextLecture.Location = new System.Drawing.Point(269, 522);
            this.bNextLecture.Name = "bNextLecture";
            this.bNextLecture.Size = new System.Drawing.Size(128, 75);
            this.bNextLecture.TabIndex = 25;
            this.bNextLecture.Text = "Next Lecture";
            this.bNextLecture.UseVisualStyleBackColor = false;
            this.bNextLecture.Click += new System.EventHandler(this.bNextLecture_Click);
            // 
            // bVocabulary
            // 
            this.bVocabulary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(120)))), ((int)(((byte)(100)))));
            this.bVocabulary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bVocabulary.Font = new System.Drawing.Font("Berlin Sans FB", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bVocabulary.ForeColor = System.Drawing.Color.White;
            this.bVocabulary.Location = new System.Drawing.Point(3, 522);
            this.bVocabulary.Name = "bVocabulary";
            this.bVocabulary.Size = new System.Drawing.Size(128, 75);
            this.bVocabulary.TabIndex = 24;
            this.bVocabulary.Text = "Vocab";
            this.bVocabulary.UseVisualStyleBackColor = false;
            this.bVocabulary.Click += new System.EventHandler(this.bVocabulary_Click);
            // 
            // bLectures
            // 
            this.bLectures.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(120)))), ((int)(((byte)(100)))));
            this.bLectures.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bLectures.Font = new System.Drawing.Font("Berlin Sans FB", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bLectures.ForeColor = System.Drawing.Color.White;
            this.bLectures.Location = new System.Drawing.Point(136, 522);
            this.bLectures.Name = "bLectures";
            this.bLectures.Size = new System.Drawing.Size(128, 75);
            this.bLectures.TabIndex = 23;
            this.bLectures.Text = "Lectures";
            this.bLectures.UseVisualStyleBackColor = false;
            this.bLectures.Click += new System.EventHandler(this.bLectures_Click);
            // 
            // pGrammar
            // 
            this.pGrammar.AutoScroll = true;
            this.pGrammar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pGrammar.Controls.Add(this.lGrammarTitle);
            this.pGrammar.Controls.Add(this.lGrammarText);
            this.pGrammar.ForeColor = System.Drawing.SystemColors.Control;
            this.pGrammar.Location = new System.Drawing.Point(19, 90);
            this.pGrammar.Name = "pGrammar";
            this.pGrammar.Size = new System.Drawing.Size(358, 363);
            this.pGrammar.TabIndex = 26;
            // 
            // lGrammarText
            // 
            this.lGrammarText.AutoSize = true;
            this.lGrammarText.Font = new System.Drawing.Font("Berlin Sans FB", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lGrammarText.ForeColor = System.Drawing.Color.White;
            this.lGrammarText.Location = new System.Drawing.Point(12, 50);
            this.lGrammarText.MaximumSize = new System.Drawing.Size(325, 0);
            this.lGrammarText.Name = "lGrammarText";
            this.lGrammarText.Size = new System.Drawing.Size(128, 21);
            this.lGrammarText.TabIndex = 25;
            this.lGrammarText.Text = "Grammar Text";
            // 
            // lProgress
            // 
            this.lProgress.AutoSize = true;
            this.lProgress.Font = new System.Drawing.Font("Berlin Sans FB", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lProgress.ForeColor = System.Drawing.Color.White;
            this.lProgress.Location = new System.Drawing.Point(180, 468);
            this.lProgress.Name = "lProgress";
            this.lProgress.Size = new System.Drawing.Size(43, 30);
            this.lProgress.TabIndex = 27;
            this.lProgress.Text = "1/4";
            // 
            // bPrevious
            // 
            this.bPrevious.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(120)))), ((int)(((byte)(100)))));
            this.bPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bPrevious.Font = new System.Drawing.Font("Berlin Sans FB", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPrevious.ForeColor = System.Drawing.Color.White;
            this.bPrevious.Location = new System.Drawing.Point(136, 465);
            this.bPrevious.Margin = new System.Windows.Forms.Padding(0);
            this.bPrevious.Name = "bPrevious";
            this.bPrevious.Size = new System.Drawing.Size(33, 38);
            this.bPrevious.TabIndex = 28;
            this.bPrevious.Text = "<";
            this.bPrevious.UseCompatibleTextRendering = true;
            this.bPrevious.UseVisualStyleBackColor = false;
            this.bPrevious.Click += new System.EventHandler(this.bPrevious_Click);
            // 
            // bNext
            // 
            this.bNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(120)))), ((int)(((byte)(100)))));
            this.bNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bNext.Font = new System.Drawing.Font("Berlin Sans FB", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bNext.ForeColor = System.Drawing.Color.White;
            this.bNext.Location = new System.Drawing.Point(231, 465);
            this.bNext.Margin = new System.Windows.Forms.Padding(0);
            this.bNext.Name = "bNext";
            this.bNext.Size = new System.Drawing.Size(33, 38);
            this.bNext.TabIndex = 29;
            this.bNext.Text = ">";
            this.bNext.UseCompatibleTextRendering = true;
            this.bNext.UseVisualStyleBackColor = false;
            this.bNext.Click += new System.EventHandler(this.bNext_Click);
            // 
            // lGrammarTitle
            // 
            this.lGrammarTitle.AutoSize = true;
            this.lGrammarTitle.Font = new System.Drawing.Font("Berlin Sans FB", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lGrammarTitle.ForeColor = System.Drawing.Color.White;
            this.lGrammarTitle.Location = new System.Drawing.Point(111, 14);
            this.lGrammarTitle.MaximumSize = new System.Drawing.Size(320, 0);
            this.lGrammarTitle.Name = "lGrammarTitle";
            this.lGrammarTitle.Size = new System.Drawing.Size(128, 21);
            this.lGrammarTitle.TabIndex = 26;
            this.lGrammarTitle.Text = "Grammar Title";
            // 
            // GrammarPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(120)))), ((int)(((byte)(100)))));
            this.Controls.Add(this.bNext);
            this.Controls.Add(this.bPrevious);
            this.Controls.Add(this.lProgress);
            this.Controls.Add(this.pGrammar);
            this.Controls.Add(this.bNextLecture);
            this.Controls.Add(this.bVocabulary);
            this.Controls.Add(this.bLectures);
            this.Controls.Add(this.lTitle);
            this.Name = "GrammarPanel";
            this.Size = new System.Drawing.Size(400, 600);
            this.pGrammar.ResumeLayout(false);
            this.pGrammar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.Button bNextLecture;
        private System.Windows.Forms.Button bVocabulary;
        private System.Windows.Forms.Button bLectures;
        private System.Windows.Forms.Panel pGrammar;
        private System.Windows.Forms.Label lProgress;
        private System.Windows.Forms.Button bPrevious;
        private System.Windows.Forms.Button bNext;
        private System.Windows.Forms.Label lGrammarText;
        private System.Windows.Forms.Label lGrammarTitle;
    }
}
