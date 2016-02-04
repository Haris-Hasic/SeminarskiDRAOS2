using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapaneseLearningApp.Klase
{
    class PitanjeOdaberi: Pitanje
    {
        String tacanOdgovor;
        String odgovor1, odgovor2, odgovor3;
        Int32 nivo;

        public PitanjeOdaberi() {}

        public PitanjeOdaberi(Int32 id, String tekst, String o1, String o2, String o3, String tOdg, Int32 n)
            : base(id, tekst)
        {
            TacanOdgovor = tOdg;
            Odgovor1 = o1;
            Odgovor2 = o2;
            Odgovor3 = o3;
            Nivo = n;
        }

        public String TacanOdgovor
        {
            get { return tacanOdgovor; }
            set { tacanOdgovor = value; }
        }

        public String Odgovor1
        {
            get { return odgovor1; }
            set { odgovor1 = value; }
        }

        public String Odgovor2
        {
            get { return odgovor2; }
            set { odgovor2 = value; }
        }

        public String Odgovor3
        {
            get { return odgovor3; }
            set { odgovor3 = value; }
        }

        public Int32 Nivo
        {
            get { return nivo; }
            set { nivo = value; }
        }
    }
}
