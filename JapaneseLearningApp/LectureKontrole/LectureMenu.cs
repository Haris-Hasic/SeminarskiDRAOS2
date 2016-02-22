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
    public partial class LectureMenu : UserControl
    {
        private const int NUMBER_OF_LECTURES = 8;

        private int lectureNumber;
        private Panel mainPanel;
        private User currentUser;

        public LectureMenu(Panel mainPanel, int lectureNumber, User currentUser)
        {
            InitializeComponent();

            this.mainPanel = mainPanel;
            this.currentUser = currentUser;
            loadLecture(lectureNumber);
        }

        private void loadLecture(int lectureNumber)
        {
            this.lectureNumber = lectureNumber;
            setButtonVisibilty();
            updateTitle();
        }

        private void updateTitle()
        {
            if (lectureNumber == 0)
                lTitle.Text = "Introduction";
            else
                lTitle.Text = "Lecture " + lectureNumber;

            lTitle.Left = (this.mainPanel.Width - lTitle.Width) / 2;
        }

        private void setButtonVisibilty()
        {
            if (lectureNumber == 0)
                bPrevious.Visible = false;
            else
                bPrevious.Visible = true;

            if (lectureNumber == NUMBER_OF_LECTURES - 1)
                bNext.Visible = false;
            else
                bNext.Visible = true;
        }

        private void bNext_Click(object sender, EventArgs e)
        {
            if (lectureNumber < NUMBER_OF_LECTURES - 1) lectureNumber++;
            setButtonVisibilty();

            //lectureNumber = (lectureNumber + 1) % NUMBER_OF_LECTURES;
            updateTitle();
        }

        private void bPrevious_Click(object sender, EventArgs e)
        {
            if (lectureNumber > 0) lectureNumber--;
            setButtonVisibilty();

            //lectureNumber = (lectureNumber + NUMBER_OF_LECTURES - 1) % NUMBER_OF_LECTURES;
            updateTitle();
        }

        private void bStory_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new StoryPanel(this.mainPanel, this.lectureNumber, this.currentUser));
            this.mainPanel.Controls.Remove(this);
        }

        private void bVocabulary_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new VocabularyPanel(this.mainPanel, this.lectureNumber, this.currentUser));
            this.mainPanel.Controls.Remove(this);
        }

        private void bGrammar_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new GrammarPanel(this.mainPanel, this.lectureNumber, this.currentUser));
            this.mainPanel.Controls.Remove(this);
        }

        private void bLectures_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new LecturesList(this.mainPanel, this.currentUser));
            this.mainPanel.Controls.Remove(this);
        }
    }
}
