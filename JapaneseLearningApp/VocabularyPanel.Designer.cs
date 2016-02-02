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
            this.lTitle = new System.Windows.Forms.Label();
            this.bHome = new System.Windows.Forms.Button();
            this.bStory = new System.Windows.Forms.Button();
            this.bGrammar = new System.Windows.Forms.Button();
            this.flpVocabulary = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Font = new System.Drawing.Font("Berlin Sans FB", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitle.ForeColor = System.Drawing.Color.White;
            this.lTitle.Location = new System.Drawing.Point(118, 38);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(154, 32);
            this.lTitle.TabIndex = 2;
            this.lTitle.Text = "Vocabulary";
            // 
            // bHome
            // 
            this.bHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(200)))), ((int)(((byte)(180)))));
            this.bHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bHome.Font = new System.Drawing.Font("Berlin Sans FB", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bHome.ForeColor = System.Drawing.Color.White;
            this.bHome.Location = new System.Drawing.Point(136, 522);
            this.bHome.Name = "bHome";
            this.bHome.Size = new System.Drawing.Size(128, 75);
            this.bHome.TabIndex = 19;
            this.bHome.Text = "Home";
            this.bHome.UseVisualStyleBackColor = false;
            // 
            // bStory
            // 
            this.bStory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(200)))), ((int)(((byte)(180)))));
            this.bStory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bStory.Font = new System.Drawing.Font("Berlin Sans FB", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bStory.ForeColor = System.Drawing.Color.White;
            this.bStory.Location = new System.Drawing.Point(3, 522);
            this.bStory.Name = "bStory";
            this.bStory.Size = new System.Drawing.Size(128, 75);
            this.bStory.TabIndex = 20;
            this.bStory.Text = "Story";
            this.bStory.UseVisualStyleBackColor = false;
            this.bStory.Click += new System.EventHandler(this.bStory_Click);
            // 
            // bGrammar
            // 
            this.bGrammar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(200)))), ((int)(((byte)(180)))));
            this.bGrammar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bGrammar.Font = new System.Drawing.Font("Berlin Sans FB", 18.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bGrammar.ForeColor = System.Drawing.Color.White;
            this.bGrammar.Location = new System.Drawing.Point(269, 522);
            this.bGrammar.Name = "bGrammar";
            this.bGrammar.Size = new System.Drawing.Size(128, 75);
            this.bGrammar.TabIndex = 21;
            this.bGrammar.Text = "Grammar";
            this.bGrammar.UseVisualStyleBackColor = false;
            this.bGrammar.Click += new System.EventHandler(this.bGrammar_Click);
            // 
            // flpVocabulary
            // 
            this.flpVocabulary.AutoScroll = true;
            this.flpVocabulary.Location = new System.Drawing.Point(18, 102);
            this.flpVocabulary.Name = "flpVocabulary";
            this.flpVocabulary.Size = new System.Drawing.Size(367, 393);
            this.flpVocabulary.TabIndex = 22;
            // 
            // VocabularyPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(200)))), ((int)(((byte)(180)))));
            this.Controls.Add(this.flpVocabulary);
            this.Controls.Add(this.bGrammar);
            this.Controls.Add(this.bStory);
            this.Controls.Add(this.bHome);
            this.Controls.Add(this.lTitle);
            this.Name = "VocabularyPanel";
            this.Size = new System.Drawing.Size(400, 600);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.Button bHome;
        private System.Windows.Forms.Button bStory;
        private System.Windows.Forms.Button bGrammar;
        private System.Windows.Forms.FlowLayoutPanel flpVocabulary;
    }
}
