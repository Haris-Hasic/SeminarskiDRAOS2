using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace JapaneseLearningApp.Klase
{
    class Kanji
    {
        private string symbol;
        private string onReading;
        private string kunReading;
        private Image image;

        public Kanji(int lectureNumber, int kanjiNumber)
        {
            var xmlStr = System.IO.File.ReadAllText(@"kanji\" + lectureNumber + @"\" + kanjiNumber + ".xml");
            var str = XElement.Parse(xmlStr);

            XElement symbolElement = str.Element("symbol");
            XElement onReadingElement = str.Element("onReading");
            XElement kunReadingElement = str.Element("kunReading");

            symbol = symbolElement == null ? "" : symbolElement.Value;
            onReading = onReadingElement == null ? "" : onReadingElement.Value;
            kunReading = kunReadingElement == null ? "" : kunReadingElement.Value;

            image = Image.FromFile(@"kanji\" + lectureNumber + @"\" + kanjiNumber + ".gif");
        }

        public string Symbol
        {
            get { return symbol; }
        }

        public string OnReading
        {
            get { return onReading; }
        }

        public string KunReading
        {
            get { return kunReading; }
        }

        public Image Image
        {
            get { return image; }
        }
    }
}
