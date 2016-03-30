namespace JapaneseLearningApp.LectureKontrole
{
    partial class KanjiPanel
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
            this.pbKanji = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lTitle = new System.Windows.Forms.Label();
            this.bNext = new System.Windows.Forms.Button();
            this.bPrevious = new System.Windows.Forms.Button();
            this.lKunyomi = new System.Windows.Forms.Label();
            this.lOnyomi = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bSymbolList = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbKanji)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbKanji
            // 
            this.pbKanji.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbKanji.Location = new System.Drawing.Point(103, 215);
            this.pbKanji.Name = "pbKanji";
            this.pbKanji.Size = new System.Drawing.Size(200, 150);
            this.pbKanji.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbKanji.TabIndex = 48;
            this.pbKanji.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(100, 577);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(206, 13);
            this.label5.TabIndex = 47;
            this.label5.Text = "Copyright 2015. All rights reserved.";
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Font = new System.Drawing.Font("Berlin Sans FB", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitle.ForeColor = System.Drawing.Color.White;
            this.lTitle.Location = new System.Drawing.Point(162, 165);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(75, 32);
            this.lTitle.TabIndex = 45;
            this.lTitle.Text = "Kanji";
            // 
            // bNext
            // 
            this.bNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.bNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bNext.Font = new System.Drawing.Font("Berlin Sans FB", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bNext.ForeColor = System.Drawing.Color.White;
            this.bNext.Location = new System.Drawing.Point(300, 488);
            this.bNext.Name = "bNext";
            this.bNext.Size = new System.Drawing.Size(80, 68);
            this.bNext.TabIndex = 51;
            this.bNext.Text = ">";
            this.bNext.UseVisualStyleBackColor = false;
            this.bNext.Click += new System.EventHandler(this.bNext_Click);
            // 
            // bPrevious
            // 
            this.bPrevious.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.bPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bPrevious.Font = new System.Drawing.Font("Berlin Sans FB", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPrevious.ForeColor = System.Drawing.Color.White;
            this.bPrevious.Location = new System.Drawing.Point(30, 488);
            this.bPrevious.Name = "bPrevious";
            this.bPrevious.Size = new System.Drawing.Size(80, 68);
            this.bPrevious.TabIndex = 50;
            this.bPrevious.Text = "<";
            this.bPrevious.UseVisualStyleBackColor = false;
            this.bPrevious.Click += new System.EventHandler(this.bPrevious_Click);
            // 
            // lKunyomi
            // 
            this.lKunyomi.AutoSize = true;
            this.lKunyomi.Font = new System.Drawing.Font("Berlin Sans FB", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lKunyomi.ForeColor = System.Drawing.Color.White;
            this.lKunyomi.Location = new System.Drawing.Point(102, 390);
            this.lKunyomi.Name = "lKunyomi";
            this.lKunyomi.Size = new System.Drawing.Size(204, 29);
            this.lKunyomi.TabIndex = 49;
            this.lKunyomi.Text = "Kunyomi Reading";
            // 
            // lOnyomi
            // 
            this.lOnyomi.AutoSize = true;
            this.lOnyomi.Font = new System.Drawing.Font("Berlin Sans FB", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lOnyomi.ForeColor = System.Drawing.Color.White;
            this.lOnyomi.Location = new System.Drawing.Point(102, 430);
            this.lOnyomi.Name = "lOnyomi";
            this.lOnyomi.Size = new System.Drawing.Size(193, 29);
            this.lOnyomi.TabIndex = 52;
            this.lOnyomi.Text = "Onyomi Reading";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.bSymbolList);
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(25, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(355, 46);
            this.panel2.TabIndex = 142;
            // 
            // bSymbolList
            // 
            this.bSymbolList.BackColor = System.Drawing.Color.Transparent;
            this.bSymbolList.BackgroundImage = global::JapaneseLearningApp.Properties.Resources._1459355941_back;
            this.bSymbolList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bSymbolList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSymbolList.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSymbolList.ForeColor = System.Drawing.Color.White;
            this.bSymbolList.Location = new System.Drawing.Point(3, 4);
            this.bSymbolList.Name = "bSymbolList";
            this.bSymbolList.Size = new System.Drawing.Size(38, 34);
            this.bSymbolList.TabIndex = 42;
            this.bSymbolList.UseVisualStyleBackColor = false;
            this.bSymbolList.Click += new System.EventHandler(this.bSymbolList_Click);
            // 
            // KanjiPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lOnyomi);
            this.Controls.Add(this.bNext);
            this.Controls.Add(this.bPrevious);
            this.Controls.Add(this.lKunyomi);
            this.Controls.Add(this.pbKanji);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lTitle);
            this.Name = "KanjiPanel";
            this.Size = new System.Drawing.Size(400, 600);
            ((System.ComponentModel.ISupportInitialize)(this.pbKanji)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbKanji;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.Button bNext;
        private System.Windows.Forms.Button bPrevious;
        private System.Windows.Forms.Label lKunyomi;
        private System.Windows.Forms.Label lOnyomi;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bSymbolList;
    }
}
