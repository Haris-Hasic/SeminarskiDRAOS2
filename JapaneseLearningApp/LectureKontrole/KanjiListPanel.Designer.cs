namespace JapaneseLearningApp.LectureKontrole
{
    partial class KanjiListPanel
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
            this.pKanji = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bWriting = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pKanji
            // 
            this.pKanji.AutoScroll = true;
            this.pKanji.Location = new System.Drawing.Point(21, 156);
            this.pKanji.Name = "pKanji";
            this.pKanji.Size = new System.Drawing.Size(357, 387);
            this.pKanji.TabIndex = 44;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(100, 577);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(206, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "Copyright 2015. All rights reserved.";
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Font = new System.Drawing.Font("Berlin Sans FB", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitle.ForeColor = System.Drawing.Color.White;
            this.lTitle.Location = new System.Drawing.Point(165, 107);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(75, 32);
            this.lTitle.TabIndex = 41;
            this.lTitle.Text = "Kanji";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.bWriting);
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(25, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(355, 46);
            this.panel2.TabIndex = 143;
            // 
            // bWriting
            // 
            this.bWriting.BackColor = System.Drawing.Color.Transparent;
            this.bWriting.BackgroundImage = global::JapaneseLearningApp.Properties.Resources._1459355941_back;
            this.bWriting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bWriting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bWriting.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bWriting.ForeColor = System.Drawing.Color.White;
            this.bWriting.Location = new System.Drawing.Point(3, 4);
            this.bWriting.Name = "bWriting";
            this.bWriting.Size = new System.Drawing.Size(38, 34);
            this.bWriting.TabIndex = 42;
            this.bWriting.UseVisualStyleBackColor = false;
            this.bWriting.Click += new System.EventHandler(this.bWriting_Click);
            // 
            // KanjiListPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pKanji);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lTitle);
            this.Name = "KanjiListPanel";
            this.Size = new System.Drawing.Size(400, 600);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pKanji;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bWriting;
    }
}
