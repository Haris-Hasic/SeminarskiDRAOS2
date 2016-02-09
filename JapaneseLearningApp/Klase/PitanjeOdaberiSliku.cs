using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapaneseLearningApp.Klase
{
    class PitanjeOdaberiSliku: Pitanje
    {
        String toTekst, o1Tekst, o2Tekst, o3Tekst;
        Image tacanOdgovor, odgovor1, odgovor2, odgovor3;

        public PitanjeOdaberiSliku() { }

        public PitanjeOdaberiSliku(Int32 id, String tekst, Int32 niv, Image tOdg, String tot, Image o1sl, String o1, Image o2sl, String o2, Image o3sl, String o3)
            : base(id, tekst, niv)
        {
            ToTekst = tot;
            O1Tekst = o1;
            O2Tekst = o2;
            O3Tekst = o3;

            TacanOdgovor = tOdg;
            Odgovor1 = o1sl;
            Odgovor2 = o2sl;
            Odgovor3 = o3sl;
        }

        public String ToTekst
        {
            get { return toTekst; }
            set { toTekst = value; }
        }

        public String O1Tekst
        {
            get { return o1Tekst; }
            set { o1Tekst = value; }
        }

        public String O2Tekst
        {
            get { return o2Tekst; }
            set { o2Tekst = value; }
        }

        public String O3Tekst
        {
            get { return o3Tekst; }
            set { o3Tekst = value; }
        }

        public Image TacanOdgovor
        {
            get { return tacanOdgovor; }
            set { tacanOdgovor = value; }
        }

        public Image Odgovor1
        {
            get { return odgovor1; }
            set { odgovor1 = value; }
        }

        public Image Odgovor2
        {
            get { return odgovor2; }
            set { odgovor2 = value; }
        }

        public Image Odgovor3
        {
            get { return odgovor3; }
            set { odgovor3 = value; }
        }
    }
}
