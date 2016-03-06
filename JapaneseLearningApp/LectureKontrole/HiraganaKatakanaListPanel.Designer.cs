namespace JapaneseLearningApp.LectureKontrole
{
    partial class HiraganaKatakanaListPanel
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
            this.bHome = new System.Windows.Forms.Button();
            this.lTitle = new System.Windows.Forms.Label();
            this.pHiragana = new System.Windows.Forms.Panel();
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
            this.label5.TabIndex = 39;
            this.label5.Text = "Copyright 2015. All rights reserved.";
            // 
            // bHome
            // 
            this.bHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(202)))), ((int)(((byte)(241)))));
            this.bHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bHome.Font = new System.Drawing.Font("Berlin Sans FB", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bHome.ForeColor = System.Drawing.Color.White;
            this.bHome.Location = new System.Drawing.Point(113, 502);
            this.bHome.Name = "bHome";
            this.bHome.Size = new System.Drawing.Size(174, 68);
            this.bHome.TabIndex = 35;
            this.bHome.Text = "Home";
            this.bHome.UseVisualStyleBackColor = false;
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Font = new System.Drawing.Font("Berlin Sans FB", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitle.ForeColor = System.Drawing.Color.White;
            this.lTitle.Location = new System.Drawing.Point(136, 60);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(130, 32);
            this.lTitle.TabIndex = 34;
            this.lTitle.Text = "Hiragana";
            // 
            // pHiragana
            // 
            this.pHiragana.AutoScroll = true;
            this.pHiragana.Location = new System.Drawing.Point(21, 109);
            this.pHiragana.Name = "pHiragana";
            this.pHiragana.Size = new System.Drawing.Size(364, 387);
            this.pHiragana.TabIndex = 40;
            // 
            // HiraganaListPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(202)))), ((int)(((byte)(241)))));
            this.Controls.Add(this.pHiragana);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bHome);
            this.Controls.Add(this.lTitle);
            this.Name = "HiraganaListPanel";
            this.Size = new System.Drawing.Size(400, 600);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bHome;
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.Panel pHiragana;
    }
}
