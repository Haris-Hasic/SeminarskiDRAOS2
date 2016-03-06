namespace JapaneseLearningApp.LectureKontrole
{
    partial class WritingMenu
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
            this.label5 = new System.Windows.Forms.Label();
            this.bKanji = new System.Windows.Forms.Button();
            this.bKatakana = new System.Windows.Forms.Button();
            this.bHiragana = new System.Windows.Forms.Button();
            this.bHome = new System.Windows.Forms.Button();
            this.lTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(100, 577);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(206, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Copyright 2015. All rights reserved.";
            // 
            // bKanji
            // 
            this.bKanji.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(202)))), ((int)(((byte)(241)))));
            this.bKanji.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bKanji.Font = new System.Drawing.Font("Berlin Sans FB", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bKanji.ForeColor = System.Drawing.Color.White;
            this.bKanji.Location = new System.Drawing.Point(25, 265);
            this.bKanji.Name = "bKanji";
            this.bKanji.Size = new System.Drawing.Size(350, 68);
            this.bKanji.TabIndex = 32;
            this.bKanji.Text = "Kanji";
            this.bKanji.UseVisualStyleBackColor = false;
            // 
            // bKatakana
            // 
            this.bKatakana.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(202)))), ((int)(((byte)(241)))));
            this.bKatakana.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bKatakana.Font = new System.Drawing.Font("Berlin Sans FB", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bKatakana.ForeColor = System.Drawing.Color.White;
            this.bKatakana.Location = new System.Drawing.Point(25, 191);
            this.bKatakana.Name = "bKatakana";
            this.bKatakana.Size = new System.Drawing.Size(350, 68);
            this.bKatakana.TabIndex = 31;
            this.bKatakana.Text = "Katakana";
            this.bKatakana.UseVisualStyleBackColor = false;
            this.bKatakana.Click += new System.EventHandler(this.bKatakana_Click);
            // 
            // bHiragana
            // 
            this.bHiragana.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(202)))), ((int)(((byte)(241)))));
            this.bHiragana.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bHiragana.Font = new System.Drawing.Font("Berlin Sans FB", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bHiragana.ForeColor = System.Drawing.Color.White;
            this.bHiragana.Location = new System.Drawing.Point(25, 117);
            this.bHiragana.Name = "bHiragana";
            this.bHiragana.Size = new System.Drawing.Size(350, 68);
            this.bHiragana.TabIndex = 30;
            this.bHiragana.Text = "Hiragana";
            this.bHiragana.UseVisualStyleBackColor = false;
            this.bHiragana.Click += new System.EventHandler(this.bHiragana_Click);
            // 
            // bHome
            // 
            this.bHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(202)))), ((int)(((byte)(241)))));
            this.bHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bHome.Font = new System.Drawing.Font("Berlin Sans FB", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bHome.ForeColor = System.Drawing.Color.White;
            this.bHome.Location = new System.Drawing.Point(113, 489);
            this.bHome.Name = "bHome";
            this.bHome.Size = new System.Drawing.Size(174, 68);
            this.bHome.TabIndex = 27;
            this.bHome.Text = "Home";
            this.bHome.UseVisualStyleBackColor = false;
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Font = new System.Drawing.Font("Berlin Sans FB", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitle.ForeColor = System.Drawing.Color.White;
            this.lTitle.Location = new System.Drawing.Point(114, 60);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(177, 32);
            this.lTitle.TabIndex = 26;
            this.lTitle.Text = "Writing Menu";
            // 
            // WritingMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(202)))), ((int)(((byte)(241)))));
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bKanji);
            this.Controls.Add(this.bKatakana);
            this.Controls.Add(this.bHiragana);
            this.Controls.Add(this.bHome);
            this.Controls.Add(this.lTitle);
            this.Name = "WritingMenu";
            this.Size = new System.Drawing.Size(400, 600);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bKanji;
        private System.Windows.Forms.Button bKatakana;
        private System.Windows.Forms.Button bHiragana;
        private System.Windows.Forms.Button bHome;
        private System.Windows.Forms.Label lTitle;
    }
}
