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
            this.lTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bHome = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
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
            this.bKanji.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.bKanji.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bKanji.Font = new System.Drawing.Font("Berlin Sans FB", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bKanji.ForeColor = System.Drawing.Color.White;
            this.bKanji.Location = new System.Drawing.Point(25, 285);
            this.bKanji.Name = "bKanji";
            this.bKanji.Size = new System.Drawing.Size(350, 68);
            this.bKanji.TabIndex = 32;
            this.bKanji.Text = "Kanji";
            this.bKanji.UseVisualStyleBackColor = false;
            this.bKanji.Click += new System.EventHandler(this.bKanji_Click);
            // 
            // bKatakana
            // 
            this.bKatakana.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.bKatakana.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bKatakana.Font = new System.Drawing.Font("Berlin Sans FB", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bKatakana.ForeColor = System.Drawing.Color.White;
            this.bKatakana.Location = new System.Drawing.Point(25, 211);
            this.bKatakana.Name = "bKatakana";
            this.bKatakana.Size = new System.Drawing.Size(350, 68);
            this.bKatakana.TabIndex = 31;
            this.bKatakana.Text = "Katakana";
            this.bKatakana.UseVisualStyleBackColor = false;
            this.bKatakana.Click += new System.EventHandler(this.bKatakana_Click);
            // 
            // bHiragana
            // 
            this.bHiragana.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.bHiragana.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bHiragana.Font = new System.Drawing.Font("Berlin Sans FB", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bHiragana.ForeColor = System.Drawing.Color.White;
            this.bHiragana.Location = new System.Drawing.Point(25, 137);
            this.bHiragana.Name = "bHiragana";
            this.bHiragana.Size = new System.Drawing.Size(350, 68);
            this.bHiragana.TabIndex = 30;
            this.bHiragana.Text = "Hiragana";
            this.bHiragana.UseVisualStyleBackColor = false;
            this.bHiragana.Click += new System.EventHandler(this.bHiragana_Click);
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Font = new System.Drawing.Font("Berlin Sans FB", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitle.ForeColor = System.Drawing.Color.White;
            this.lTitle.Location = new System.Drawing.Point(114, 77);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(177, 32);
            this.lTitle.TabIndex = 26;
            this.lTitle.Text = "Writing Menu";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.bHome);
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(25, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 46);
            this.panel1.TabIndex = 141;
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
            // WritingMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bKanji);
            this.Controls.Add(this.bKatakana);
            this.Controls.Add(this.bHiragana);
            this.Controls.Add(this.lTitle);
            this.Name = "WritingMenu";
            this.Size = new System.Drawing.Size(400, 600);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bKanji;
        private System.Windows.Forms.Button bKatakana;
        private System.Windows.Forms.Button bHiragana;
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bHome;
    }
}
