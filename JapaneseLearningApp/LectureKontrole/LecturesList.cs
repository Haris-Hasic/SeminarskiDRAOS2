using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using JapaneseLearningApp.Klase;

namespace JapaneseLearningApp
{
    public partial class LecturesList : UserControl
    {
        private Panel mainPanel;
        private User currentUser;

        public LecturesList(Panel mainPanel, User currentUser)
        {
            InitializeComponent();

            this.mainPanel = mainPanel;
            this.currentUser = currentUser;
            adjustButtonColors();
        }

        public void adjustButtonColors()
        {
            if (currentUser != null)
            {
                DBManipulation dbmanipulation = DBManipulation.getInstance();
                int progress = dbmanipulation.getLectureProgress(dbmanipulation.getUserId(currentUser.Username));

                MessageBox.Show(progress.ToString());
            }
        }

        private void bLectureIntro_Click(object sender, EventArgs e)
        {            
            this.mainPanel.Controls.Add(new LectureMenu(this.mainPanel, 0, this.currentUser));
            this.mainPanel.Controls.Remove(this);
        }

        private void bLecture1_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new LectureMenu(this.mainPanel, 1, this.currentUser));
            this.mainPanel.Controls.Remove(this);
        }

        private void bLecture2_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new LectureMenu(this.mainPanel, 2, this.currentUser));
            this.mainPanel.Controls.Remove(this);
        }

        private void bLecture3_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new LectureMenu(this.mainPanel, 3, this.currentUser));
            this.mainPanel.Controls.Remove(this);
        }

        private void bLecture4_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new LectureMenu(this.mainPanel, 4, this.currentUser));
            this.mainPanel.Controls.Remove(this);
        }

        private void bLecture5_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new LectureMenu(this.mainPanel, 5, this.currentUser));
            this.mainPanel.Controls.Remove(this);
        }

        private void bLecture6_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new LectureMenu(this.mainPanel, 6, this.currentUser));
            this.mainPanel.Controls.Remove(this);
        }

        private void bLecture7_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new LectureMenu(this.mainPanel, 7, this.currentUser));
            this.mainPanel.Controls.Remove(this);
        }
        
    }
}
