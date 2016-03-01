using System;
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
    public partial class HiraganaPanel : UserControl
    {
        private Panel mainPanel;
        private String hiraganaReading;
        private Image hiraganaImage;

        public HiraganaPanel(Panel mainPanel, String hiraganaReading)
        {
            InitializeComponent();

            this.mainPanel = mainPanel;
            this.hiraganaReading = hiraganaReading;

            loadImage();
        }

        public void loadImage()
        {
            try
            {
                hiraganaImage = Image.FromFile(@"hiragana\" + hiraganaReading + ".gif");
                pbHiragana.Image = hiraganaImage;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void bHiraganaList_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new HiraganaListPanel(mainPanel));
            this.mainPanel.Controls.Remove(this);
        }
    }
}
