using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearningJapanese
{
    public partial class Test : UserControl
    {
        private List<String> questions;
        private List<Answers> answers;
        private int brojPitanja;
        public class Answers
        {
            String answer1;
            public String Answer1 { get; set; }
            String answer2;
            public String Answer2 { get; set; }
            String answer3;
            public String Answer3 { get; set; }
        }
        public Test()
        {
             InitializeComponent();
             questions = new List<string>();
             answers = new List<Answers>();
             brojPitanja = 0;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            questionLabel.Text = "First question on quiz?";
            questionNumberLabel.Text = "Question 1";
            answer1Btn.Text = "Answer 1";
            answer1Btn.Font = new System.Drawing.Font("Berlin Sans FB", 22);
            answer2Btn.Text = "Answer 2";
            answer3Btn.Text = "Answer 3";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            questionLabel.Text = "Is this question number 2?";
            questionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18);
            questionNumberLabel.Text = "Question 2";
            answer1Btn.Text = "This might be correct answer!";
            answer1Btn.Font = new System.Drawing.Font("Berlin Sans FB", 16);
            answer2Btn.Text = "Try this one";
            answer3Btn.Text = "Or maybe this one";
        }
    }
}
