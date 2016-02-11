using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapaneseLearningApp.Klase
{
    class Test
    {
        String tip;
        Int32 skor, tacanOdgovor, trenutnoPitanje;

        public Test() 
        {
            Skor = 0;
            TrenutnoPitanje = 0;
        }

        public String Tip
        {
            get { return tip; }
            set { tip = value; }
        }

        public Int32 Skor
        {
            get { return skor; }
            set { skor = value; }
        }

        public Int32 TacanOdgovor
        {
            get { return tacanOdgovor; }
            set { tacanOdgovor = value; }
        }

        public Int32 TrenutnoPitanje
        {
            get { return trenutnoPitanje; }
            set { trenutnoPitanje = value; }
        }

        public Boolean Odgovori(Int32 odg) 
        {
            TrenutnoPitanje = TrenutnoPitanje + 1;

            if (odg == TacanOdgovor)
            {
                Skor = Skor + 1;
                return true;
            }

            return false;
        }

        public Boolean ZavrsenTest()
        {
            if (TrenutnoPitanje == 10)
                return true;

            return false;
        }

        public void Resetuj()
        {
            Skor = 0;
            TrenutnoPitanje = 0;
        }
    }
}
