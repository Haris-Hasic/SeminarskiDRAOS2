namespace JapaneseLearningApp.LectureKontrole
{
    partial class HiraganaKatakanaPanel
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
            this.bSymbolList = new System.Windows.Forms.Button();
            this.lTitle = new System.Windows.Forms.Label();
            this.pbHiragana = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbHiragana)).BeginInit();
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
            this.label5.TabIndex = 43;
            this.label5.Text = "Copyright 2015. All rights reserved.";
            // 
            // bSymbolList
            // 
            this.bSymbolList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(202)))), ((int)(((byte)(241)))));
            this.bSymbolList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSymbolList.Font = new System.Drawing.Font("Berlin Sans FB", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSymbolList.ForeColor = System.Drawing.Color.White;
            this.bSymbolList.Location = new System.Drawing.Point(113, 502);
            this.bSymbolList.Name = "bSymbolList";
            this.bSymbolList.Size = new System.Drawing.Size(174, 68);
            this.bSymbolList.TabIndex = 42;
            this.bSymbolList.Text = "Hiragana List";
            this.bSymbolList.UseVisualStyleBackColor = false;
            this.bSymbolList.Click += new System.EventHandler(this.bSymbolList_Click);
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Font = new System.Drawing.Font("Berlin Sans FB", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitle.ForeColor = System.Drawing.Color.White;
            this.lTitle.Location = new System.Drawing.Point(136, 60);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(130, 32);
            this.lTitle.TabIndex = 41;
            this.lTitle.Text = "Hiragana";
            // 
            // pbHiragana
            // 
            this.pbHiragana.Location = new System.Drawing.Point(106, 156);
            this.pbHiragana.Name = "pbHiragana";
            this.pbHiragana.Size = new System.Drawing.Size(200, 150);
            this.pbHiragana.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbHiragana.TabIndex = 44;
            this.pbHiragana.TabStop = false;
            // 
            // HiraganaKatakanaPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(202)))), ((int)(((byte)(241)))));
            this.Controls.Add(this.pbHiragana);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bSymbolList);
            this.Controls.Add(this.lTitle);
            this.Name = "HiraganaKatakanaPanel";
            this.Size = new System.Drawing.Size(400, 600);
            ((System.ComponentModel.ISupportInitialize)(this.pbHiragana)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bSymbolList;
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.PictureBox pbHiragana;
    }
}
