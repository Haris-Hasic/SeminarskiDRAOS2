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

        public StoryPanel(Panel mainPanel, int lectureNumber)
        {
            InitializeComponent();

            this.mainPanel = mainPanel;
            this.lectureNumber = lectureNumber;
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
            }
            catch (Exception e)
            {
                this.lJapaneseText.Text = e.Message;
                this.lEnglishText.Text = e.Message;
            }
        }

        private void bLectures_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new LecturesList(this.mainPanel));
            this.mainPanel.Controls.Remove(this);
        }

        private void bVocabulary_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new VocabularyPanel(this.mainPanel, this.lectureNumber));
            this.mainPanel.Controls.Remove(this);
        }


    }
}
