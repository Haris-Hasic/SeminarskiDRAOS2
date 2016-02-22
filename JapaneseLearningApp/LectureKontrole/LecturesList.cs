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
                try
                {
                    DBManipulation dbmanipulation = DBManipulation.getInstance();
                    int progress = dbmanipulation.getLectureProgress(dbmanipulation.getUserId(currentUser.Username));

                    switch (progress)
                    {
                        case 7:
                            bLecture7.BackColor = Color.FromArgb(140, 225, 245);
                            goto case 6;
                        case 6:
                            bLecture6.BackColor = Color.FromArgb(140, 225, 245);
                            goto case 5;
                        case 5:
                            bLecture5.BackColor = Color.FromArgb(140, 225, 245);
                            goto case 4;
                        case 4:
                            bLecture4.BackColor = Color.FromArgb(140, 225, 245);
                            goto case 3;
                        case 3:
                            bLecture3.BackColor = Color.FromArgb(140, 225, 245);
                            goto case 2;
                        case 2:
                            bLecture2.BackColor = Color.FromArgb(140, 225, 245);
                            goto case 1;
                        case 1:
                            bLecture1.BackColor = Color.FromArgb(140, 225, 245);
                            goto case 0;
                        case 0:
                            bLectureIntro.BackColor = Color.FromArgb(140, 225, 245);
                            break;
                    }

                    //bLectureIntro.Enabled = true;
                    //bLecture1.Enabled = true;
                    //bLecture2.Enabled = true;
                    //bLecture3.Enabled = true;
                    //bLecture4.Enabled = true;
                    //bLecture5.Enabled = true;
                    //bLecture6.Enabled = true;
                    //bLecture7.Enabled = true;

                    //switch (progress)
                    //{
                    //    case -1:
                    //        bLecture1.Enabled = false;
                    //        goto case 0;
                    //    case 0:
                    //        bLecture2.Enabled = false;
                    //        goto case 1;
                    //    case 1:
                    //        bLecture3.Enabled = false;
                    //        goto case 2;
                    //    case 2:
                    //        bLecture4.Enabled = false;
                    //        goto case 3;
                    //    case 3:
                    //        bLecture5.Enabled = false;
                    //        goto case 4;
                    //    case 4:
                    //        bLecture6.Enabled = false;
                    //        goto case 5;
                    //    case 5:
                    //        bLecture7.Enabled = false;
                    //        break;
                    //}
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
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
