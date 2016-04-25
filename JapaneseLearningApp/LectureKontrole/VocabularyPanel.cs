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
    public partial class VocabularyPanel : UserControl
    {
        private int numberOfLectures = 12;

        private int lectureNumber;
        private Panel mainPanel;
        private User currentUser;

        private String[] titles;
        private String[] japaneseWords;
        private String[] englishWords;

        private int currentSection;

        public VocabularyPanel(Panel mainPanel, int lectureNumber, User currentUser)
        {
            InitializeComponent();

            this.mainPanel = mainPanel;
            this.lectureNumber = lectureNumber;
            this.currentUser = currentUser;
            this.numberOfLectures = currentUser.Progress + 2;
            updateLectureLabel();
            setLectureButtonVisibility();
            loadVocabulary();
        }

        private void loadVocabulary()
        {
            try
            {
                Vocabulary vocabulary = new Vocabulary(lectureNumber);
                titles = vocabulary.Titles;
                japaneseWords = vocabulary.JapaneseWords;
                englishWords = vocabulary.EnglishWords;
                currentSection = 1;
                lProgress.Text = currentSection + "/" + titles.Length;

                displayVocabularySection();

                setButtonVisibility();

                if (currentSection == titles.Length)
                {
                    updateVocabularyProgress();
                }
            }
            catch (Exception e)
            {
                Label error = new Label();
                error.Text = e.Message;
                flpVocabulary.Controls.Add(error);

                lProgress.Text = currentSection + "/0";
                bPrevious.Visible = false;
                bNext.Visible = false;
            }
        }

        private void updateLectureLabel()
        {
            if (lectureNumber == 0)
                lLecture.Text = "Introduction";
            else
                lLecture.Text = "Lecture " + lectureNumber;

            lLecture.Left = (this.mainPanel.Width - lLecture.Width) / 2;
        }

        private void displayVocabularySection()
        {
            // Get array of words for the current section
            String[] japaneseWordsInSection = japaneseWords[currentSection - 1].Split(new string[] { "\n" }, StringSplitOptions.None);
            String[] englishWordsInSection = englishWords[currentSection - 1].Split(new string[] { "\n" }, StringSplitOptions.None);

            flpVocabulary.Controls.Clear();

            // Remove scroll bar if it's not needed
            flpVocabulary.AutoScroll = false;
            flpVocabulary.AutoScroll = true;

            for (int i = 0; i < japaneseWordsInSection.Length; i++)
            {
                Label japaneseWord = new Label();
                japaneseWord.Text = japaneseWordsInSection[i];
                japaneseWord.Font = new Font(bVocabulary.Font.FontFamily, 14);
                japaneseWord.ForeColor = Color.White;
                japaneseWord.AutoSize = true;
                japaneseWord.MaximumSize = new System.Drawing.Size((int)(0.4 * flpVocabulary.Width), 0);                
                flpVocabulary.Controls.Add(japaneseWord);
                int rightMargin = flpVocabulary.Width / 2 - japaneseWord.Size.Width;
                japaneseWord.Margin = new System.Windows.Forms.Padding(3, 3, rightMargin, 3);
                

                Label englishWord = new Label();
                englishWord.Text = englishWordsInSection[i];
                englishWord.Font = new Font(bVocabulary.Font.FontFamily, 14);
                englishWord.ForeColor = Color.White;
                englishWord.AutoSize = true;
                englishWord.MaximumSize = new System.Drawing.Size((int)(0.4 * flpVocabulary.Width), 0);
                englishWord.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
                flpVocabulary.Controls.Add(englishWord);
            }
        }

        private void updateVocabularyProgress()
        {
            try
            {
                DBManipulation dbmanipulation = DBManipulation.getInstance();
                int currentProgress = dbmanipulation.getVocabularyProgress(currentUser.Id);
                if (lectureNumber > currentProgress)
                    dbmanipulation.setVocabularyProgress(currentUser.Id, lectureNumber);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void setButtonVisibility()
        {
            if (currentSection == 1)
                bPrevious.Visible = false;
            else
                bPrevious.Visible = true;

            if (currentSection == titles.Length)
                bNext.Visible = false;
            else
                bNext.Visible = true;
        }

        private void bPrevious_Click(object sender, EventArgs e)
        {
            if (currentSection > 1)
            {
                currentSection--;
                lProgress.Text = currentSection + "/" + titles.Length;
                displayVocabularySection();
            }
            setButtonVisibility();
        }

        private void bNext_Click(object sender, EventArgs e)
        {
            if (currentSection < titles.Length)
            {
                currentSection++;
                lProgress.Text = currentSection + "/" + titles.Length;
                displayVocabularySection();
            }
            setButtonVisibility();

            if (currentSection == titles.Length)
            {
                updateVocabularyProgress();
                this.numberOfLectures = currentUser.Progress + 2;
                setLectureButtonVisibility();
            }
        }

        private void setLectureButtonVisibility()
        {
            if (lectureNumber == 0)
                bPreviousLecture.Visible = false;
            else
                bPreviousLecture.Visible = true;

            if (lectureNumber == numberOfLectures - 1)
                bNextLecture.Visible = false;
            else
                bNextLecture.Visible = true;
        }


        private void bBack_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new LecturesList(this.mainPanel, this.currentUser));
            this.mainPanel.Controls.Remove(this);
        }

        private void bStory_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new StoryPanel(this.mainPanel, this.lectureNumber, this.currentUser));
            this.mainPanel.Controls.Remove(this);
        }

        private void bGrammar_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new GrammarPanel(this.mainPanel, this.lectureNumber, this.currentUser));
            this.mainPanel.Controls.Remove(this);
        }

        private void bHome_Click(object sender, EventArgs e)
        {
            (this.Parent.Parent.Parent as TabControl).SelectedIndex = 1;
            this.mainPanel.Controls.Clear();
        }

        private void bPreviousLecture_Click(object sender, EventArgs e)
        {
            if (lectureNumber > 0)
            {
                this.mainPanel.Controls.Add(new StoryPanel(this.mainPanel, this.lectureNumber - 1, this.currentUser));
                this.mainPanel.Controls.Remove(this);
            }
        }

        private void bNextLecture_Click(object sender, EventArgs e)
        {
            if (lectureNumber < numberOfLectures)
            {
                this.mainPanel.Controls.Add(new StoryPanel(this.mainPanel, this.lectureNumber + 1, this.currentUser));
                this.mainPanel.Controls.Remove(this);
            }
        }

    }
}
