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
        private List<Button> buttons = new List<Button>();

        public LecturesList(Panel mainPanel, User currentUser)
        {
            InitializeComponent();

            this.mainPanel = mainPanel;
            this.currentUser = currentUser;
            fillButtonList();
            adjustButtonColors();
        }

        private void fillButtonList()
        {
            buttons.Add(bLectureIntro);
            buttons.Add(bLecture1);
            buttons.Add(bLecture2);
            buttons.Add(bLecture3);
            buttons.Add(bLecture4);
            buttons.Add(bLecture5);
            buttons.Add(bLecture6);
            buttons.Add(bLecture7);
            buttons.Add(bLecture8);
            buttons.Add(bLecture9);
            buttons.Add(bLecture10);
            buttons.Add(bLecture11);
            buttons.Add(bLecture12);
        }

        private void adjustButtonColors()
        {
            if (currentUser != null)
            {
                try
                {
                    int progress = currentUser.Progress;

                    for (int i = 0; i < buttons.Count; i++)
                    {
                        if (i <= progress + 1)
                            buttons[i].Enabled = true;
                        else
                            buttons[i].Enabled = false;
                    }

                    //switch (progress)
                    //{
                    //    case 7:
                    //        bLecture7.BackColor = Color.FromArgb(140, 225, 245);
                    //        goto case 6;
                    //    case 6:
                    //        bLecture6.BackColor = Color.FromArgb(140, 225, 245);
                    //        goto case 5;
                    //    case 5:
                    //        bLecture5.BackColor = Color.FromArgb(140, 225, 245);
                    //        goto case 4;
                    //    case 4:
                    //        bLecture4.BackColor = Color.FromArgb(140, 225, 245);
                    //        goto case 3;
                    //    case 3:
                    //        bLecture3.BackColor = Color.FromArgb(140, 225, 245);
                    //        goto case 2;
                    //    case 2:
                    //        bLecture2.BackColor = Color.FromArgb(140, 225, 245);
                    //        goto case 1;
                    //    case 1:
                    //        bLecture1.BackColor = Color.FromArgb(140, 225, 245);
                    //        goto case 0;
                    //    case 0:
                    //        bLectureIntro.BackColor = Color.FromArgb(140, 225, 245);
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

        private void bLecture8_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new LectureMenu(this.mainPanel, 8, this.currentUser));
            this.mainPanel.Controls.Remove(this);
        }

        private void bLecture9_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new LectureMenu(this.mainPanel, 9, this.currentUser));
            this.mainPanel.Controls.Remove(this);
        }

        private void bLecture10_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new LectureMenu(this.mainPanel, 10, this.currentUser));
            this.mainPanel.Controls.Remove(this);
        }

        private void bLecture11_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new LectureMenu(this.mainPanel, 11, this.currentUser));
            this.mainPanel.Controls.Remove(this);
        }

        private void bLecture12_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new LectureMenu(this.mainPanel, 12, this.currentUser));
            this.mainPanel.Controls.Remove(this);
        }

        private void bHome_Click(object sender, EventArgs e)
        {
            (this.Parent.Parent.Parent as TabControl).SelectedIndex = 1;
        }
    }
}
