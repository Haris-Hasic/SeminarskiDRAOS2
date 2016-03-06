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
    public partial class StoryPanel : UserControl
    {
        private int lectureNumber;
        private Panel mainPanel;
        private User currentUser;

        public StoryPanel(Panel mainPanel, int lectureNumber, User currentUser)
        {
            InitializeComponent();

            this.mainPanel = mainPanel;
            this.lectureNumber = lectureNumber;
            this.currentUser = currentUser;
            loadStory();
        }

        private void loadStory()
        {
            try
            {
                Story story = new Story(lectureNumber);
                this.lJapaneseTitle.Text = story.JapaneseTitle;
                this.lEnglishTitle.Text = story.EnglishTitle;
                this.lJapaneseText.Text = story.JapaneseText;
                this.lEnglishText.Text = story.EnglishText;

                this.lJapaneseTitle.Left = (this.mainPanel.Width - this.lJapaneseTitle.Width) / 2;
                this.lEnglishTitle.Left = (this.mainPanel.Width - this.lEnglishTitle.Width) / 2;

                if (lectureNumber == 0)
                    introductionSetup();
                else
                    standardSetup();

                updateStoryProgress();
            }
            catch (Exception e)
            {
                this.lJapaneseText.Text = e.Message;
                this.lEnglishText.Text = e.Message;
            }
        }

        private void introductionSetup()
        {
            pEnglish.Height += pEnglish.Height + (pEnglish.Top - pJapanese.Top - pJapanese.Height);
            pEnglish.Top = pJapanese.Top;
            pJapanese.Visible = false;
        }

        private void standardSetup()
        {
            pJapanese.Visible = true;
            pEnglish.Top = 319; // Magic numbers, YAY!
            pEnglish.Height = pJapanese.Height;
        }

        private void updateStoryProgress()
        {
            try
            {
                DBManipulation dbmanipulation = DBManipulation.getInstance();
                int currentProgress = dbmanipulation.getStoryProgress(currentUser.Id);
                if (lectureNumber > currentProgress)
                    dbmanipulation.setStoryProgress(currentUser.Id, lectureNumber);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void bLectures_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new LecturesList(this.mainPanel, this.currentUser));
            this.mainPanel.Controls.Remove(this);
        }

        private void bVocabulary_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new VocabularyPanel(this.mainPanel, this.lectureNumber, this.currentUser));
            this.mainPanel.Controls.Remove(this);
        }


    }
}
