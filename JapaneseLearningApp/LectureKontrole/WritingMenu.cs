﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JapaneseLearningApp.LectureKontrole
{
    public partial class WritingMenu : UserControl
    {
        private Panel mainPanel;

        public WritingMenu(Panel mainPanel)
        {
            InitializeComponent();

            this.mainPanel = mainPanel;
        }

        private void bHiragana_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new HiraganaListPanel(mainPanel));
            this.mainPanel.Controls.Remove(this);
        }
    }
}
