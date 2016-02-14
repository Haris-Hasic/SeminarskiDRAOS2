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
    public partial class GrammarPanel : UserControl
    {
        private int lectureNumber;
        private Panel mainPanel;
        private User currentUser;
        private String[] sections;
        private int currentSection;

        public GrammarPanel(Panel mainPanel, int lectureNumber, User currentUser)
        {
            InitializeComponent();

            this.mainPanel = mainPanel;
            this.lectureNumber = lectureNumber;
            this.currentUser = currentUser;
            loadGrammar();
        }

        private void loadGrammar()
        {
            lTitle.Text = "Grammar " + lectureNumber;

            try
            {
                Grammar grammar = new Grammar(lectureNumber);
                sections = grammar.GrammarSections;
                currentSection = 1;
                lProgress.Text = currentSection + "/" + sections.Length;

                if (sections.Length > 0)
                    lGrammarText.Text = sections[0];

                if (currentSection == sections.Length)
                {
                    updateGrammarProgress();
                }
            }
            catch (Exception e)
            {
                lGrammarText.Text = e.Message;
                sections = new String[0];
                lProgress.Text = currentSection + "/" + sections.Length;
            }
        }

        private void updateGrammarProgress()
        {
            try
            {
                DBManipulation dbmanipulation = DBManipulation.getInstance();
                int currentProgress = dbmanipulation.getGrammarProgress(dbmanipulation.getUserId(currentUser.Username));
                if (lectureNumber > currentProgress)
                    dbmanipulation.setGrammarProgress(dbmanipulation.getUserId(currentUser.Username), lectureNumber);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void bPrevious_Click(object sender, EventArgs e)
        {
            if (currentSection > 1)
            {
                currentSection--;
                lProgress.Text = currentSection + "/" + sections.Length;
                lGrammarText.Text = sections[currentSection - 1];
            }
        }

        private void bNext_Click(object sender, EventArgs e)
        {
            if (currentSection < sections.Length)
            {
                currentSection++;
                lProgress.Text = currentSection + "/" + sections.Length;
                lGrammarText.Text = sections[currentSection - 1];
            }

            if (currentSection == sections.Length)
            {
                updateGrammarProgress();
            }
        }

        private void bVocabulary_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new VocabularyPanel(this.mainPanel, this.lectureNumber, this.currentUser));
            this.mainPanel.Controls.Remove(this);
        }

        private void bNextLecture_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new LectureMenu(this.mainPanel, this.lectureNumber + 1, this.currentUser));
            this.mainPanel.Controls.Remove(this);
        }
    }
}
