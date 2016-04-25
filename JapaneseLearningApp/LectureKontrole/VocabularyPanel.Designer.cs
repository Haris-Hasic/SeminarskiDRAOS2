namespace JapaneseLearningApp
{
    partial class VocabularyPanel
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
            this.flpVocabulary = new System.Windows.Forms.FlowLayoutPanel();
            this.bNext = new System.Windows.Forms.Button();
            this.bPrevious = new System.Windows.Forms.Button();
            this.lProgress = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bBack = new System.Windows.Forms.Button();
            this.bHome = new System.Windows.Forms.Button();
            this.bGrammar = new System.Windows.Forms.Button();
            this.bVocabulary = new System.Windows.Forms.Button();
            this.bStory = new System.Windows.Forms.Button();
            this.bNextLecture = new System.Windows.Forms.Button();
            this.bPreviousLecture = new System.Windows.Forms.Button();
            this.lLecture = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpVocabulary
            // 
            this.flpVocabulary.AutoScroll = true;
            this.flpVocabulary.Location = new System.Drawing.Point(19, 135);
            this.flpVocabulary.Name = "flpVocabulary";
            this.flpVocabulary.Size = new System.Drawing.Size(358, 330);
            this.flpVocabulary.TabIndex = 22;
            // 
            // bNext
            // 
            this.bNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(200)))), ((int)(((byte)(180)))));
            this.bNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bNext.Font = new System.Drawing.Font("Berlin Sans FB", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bNext.ForeColor = System.Drawing.Color.White;
            this.bNext.Location = new System.Drawing.Point(230, 476);
            this.bNext.Margin = new System.Windows.Forms.Padding(0);
            this.bNext.Name = "bNext";
            this.bNext.Size = new System.Drawing.Size(33, 38);
            this.bNext.TabIndex = 32;
            this.bNext.Text = ">";
            this.bNext.UseCompatibleTextRendering = true;
            this.bNext.UseVisualStyleBackColor = false;
            this.bNext.Click += new System.EventHandler(this.bNext_Click);
            // 
            // bPrevious
            // 
            this.bPrevious.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(200)))), ((int)(((byte)(180)))));
            this.bPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bPrevious.Font = new System.Drawing.Font("Berlin Sans FB", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPrevious.ForeColor = System.Drawing.Color.White;
            this.bPrevious.Location = new System.Drawing.Point(136, 476);
            this.bPrevious.Margin = new System.Windows.Forms.Padding(0);
            this.bPrevious.Name = "bPrevious";
            this.bPrevious.Size = new System.Drawing.Size(33, 38);
            this.bPrevious.TabIndex = 31;
            this.bPrevious.Text = "<";
            this.bPrevious.UseCompatibleTextRendering = true;
            this.bPrevious.UseVisualStyleBackColor = false;
            this.bPrevious.Click += new System.EventHandler(this.bPrevious_Click);
            // 
            // lProgress
            // 
            this.lProgress.AutoSize = true;
            this.lProgress.Font = new System.Drawing.Font("Berlin Sans FB", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lProgress.ForeColor = System.Drawing.Color.White;
            this.lProgress.Location = new System.Drawing.Point(180, 479);
            this.lProgress.Name = "lProgress";
            this.lProgress.Size = new System.Drawing.Size(43, 30);
            this.lProgress.TabIndex = 30;
            this.lProgress.Text = "1/4";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.bBack);
            this.panel1.Controls.Add(this.bHome);
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(25, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 46);
            this.panel1.TabIndex = 151;
            // 
            // bBack
            // 
            this.bBack.BackColor = System.Drawing.Color.Transparent;
            this.bBack.BackgroundImage = global::JapaneseLearningApp.Properties.Resources._1459355941_back;
            this.bBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bBack.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBack.ForeColor = System.Drawing.Color.White;
            this.bBack.Location = new System.Drawing.Point(3, 3);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(38, 34);
            this.bBack.TabIndex = 44;
            this.bBack.UseVisualStyleBackColor = false;
            this.bBack.Click += new System.EventHandler(this.bBack_Click);
            // 
            // bHome
            // 
            this.bHome.BackColor = System.Drawing.Color.Transparent;
            this.bHome.BackgroundImage = global::JapaneseLearningApp.Properties.Resources._1459356039_013_myhouse;
            this.bHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bHome.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bHome.ForeColor = System.Drawing.Color.White;
            this.bHome.Location = new System.Drawing.Point(157, 3);
            this.bHome.Name = "bHome";
            this.bHome.Size = new System.Drawing.Size(38, 34);
            this.bHome.TabIndex = 43;
            this.bHome.UseVisualStyleBackColor = false;
            this.bHome.Click += new System.EventHandler(this.bHome_Click);
            // 
            // bGrammar
            // 
            this.bGrammar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(200)))), ((int)(((byte)(180)))));
            this.bGrammar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bGrammar.Font = new System.Drawing.Font("Berlin Sans FB", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bGrammar.ForeColor = System.Drawing.Color.White;
            this.bGrammar.Location = new System.Drawing.Point(269, 65);
            this.bGrammar.Name = "bGrammar";
            this.bGrammar.Size = new System.Drawing.Size(115, 50);
            this.bGrammar.TabIndex = 150;
            this.bGrammar.Text = "Grammar";
            this.bGrammar.UseVisualStyleBackColor = false;
            this.bGrammar.Click += new System.EventHandler(this.bGrammar_Click);
            // 
            // bVocabulary
            // 
            this.bVocabulary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(230)))), ((int)(((byte)(210)))));
            this.bVocabulary.Enabled = false;
            this.bVocabulary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bVocabulary.Font = new System.Drawing.Font("Berlin Sans FB", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bVocabulary.ForeColor = System.Drawing.Color.White;
            this.bVocabulary.Location = new System.Drawing.Point(137, 65);
            this.bVocabulary.Name = "bVocabulary";
            this.bVocabulary.Size = new System.Drawing.Size(128, 50);
            this.bVocabulary.TabIndex = 149;
            this.bVocabulary.Text = "Vocabulary";
            this.bVocabulary.UseVisualStyleBackColor = false;
            // 
            // bStory
            // 
            this.bStory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(200)))), ((int)(((byte)(180)))));
            this.bStory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bStory.Font = new System.Drawing.Font("Berlin Sans FB", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bStory.ForeColor = System.Drawing.Color.White;
            this.bStory.Location = new System.Drawing.Point(17, 65);
            this.bStory.Name = "bStory";
            this.bStory.Size = new System.Drawing.Size(115, 50);
            this.bStory.TabIndex = 148;
            this.bStory.Text = "Story";
            this.bStory.UseVisualStyleBackColor = false;
            this.bStory.Click += new System.EventHandler(this.bStory_Click);
            // 
            // bNextLecture
            // 
            this.bNextLecture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(200)))), ((int)(((byte)(180)))));
            this.bNextLecture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bNextLecture.Font = new System.Drawing.Font("Berlin Sans FB", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bNextLecture.ForeColor = System.Drawing.Color.White;
            this.bNextLecture.Location = new System.Drawing.Point(314, 546);
            this.bNextLecture.Margin = new System.Windows.Forms.Padding(0);
            this.bNextLecture.Name = "bNextLecture";
            this.bNextLecture.Size = new System.Drawing.Size(70, 50);
            this.bNextLecture.TabIndex = 154;
            this.bNextLecture.Text = ">";
            this.bNextLecture.UseCompatibleTextRendering = true;
            this.bNextLecture.UseVisualStyleBackColor = false;
            this.bNextLecture.Click += new System.EventHandler(this.bNextLecture_Click);
            // 
            // bPreviousLecture
            // 
            this.bPreviousLecture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(200)))), ((int)(((byte)(180)))));
            this.bPreviousLecture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bPreviousLecture.Font = new System.Drawing.Font("Berlin Sans FB", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPreviousLecture.ForeColor = System.Drawing.Color.White;
            this.bPreviousLecture.Location = new System.Drawing.Point(17, 546);
            this.bPreviousLecture.Margin = new System.Windows.Forms.Padding(0);
            this.bPreviousLecture.Name = "bPreviousLecture";
            this.bPreviousLecture.Size = new System.Drawing.Size(70, 50);
            this.bPreviousLecture.TabIndex = 153;
            this.bPreviousLecture.Text = "<";
            this.bPreviousLecture.UseCompatibleTextRendering = true;
            this.bPreviousLecture.UseVisualStyleBackColor = false;
            this.bPreviousLecture.Click += new System.EventHandler(this.bPreviousLecture_Click);
            // 
            // lLecture
            // 
            this.lLecture.AutoSize = true;
            this.lLecture.Font = new System.Drawing.Font("Berlin Sans FB", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lLecture.ForeColor = System.Drawing.Color.White;
            this.lLecture.Location = new System.Drawing.Point(154, 554);
            this.lLecture.Name = "lLecture";
            this.lLecture.Size = new System.Drawing.Size(108, 33);
            this.lLecture.TabIndex = 152;
            this.lLecture.Text = "Lecture";
            // 
            // VocabularyPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(200)))), ((int)(((byte)(180)))));
            this.Controls.Add(this.bNextLecture);
            this.Controls.Add(this.bPreviousLecture);
            this.Controls.Add(this.lLecture);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bGrammar);
            this.Controls.Add(this.bVocabulary);
            this.Controls.Add(this.bStory);
            this.Controls.Add(this.bNext);
            this.Controls.Add(this.bPrevious);
            this.Controls.Add(this.lProgress);
            this.Controls.Add(this.flpVocabulary);
            this.Name = "VocabularyPanel";
            this.Size = new System.Drawing.Size(400, 600);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpVocabulary;
        private System.Windows.Forms.Button bNext;
        private System.Windows.Forms.Button bPrevious;
        private System.Windows.Forms.Label lProgress;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bBack;
        private System.Windows.Forms.Button bHome;
        private System.Windows.Forms.Button bGrammar;
        private System.Windows.Forms.Button bVocabulary;
        private System.Windows.Forms.Button bStory;
        private System.Windows.Forms.Button bNextLecture;
        private System.Windows.Forms.Button bPreviousLecture;
        private System.Windows.Forms.Label lLecture;
    }
}
