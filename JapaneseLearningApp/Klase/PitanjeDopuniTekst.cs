﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapaneseLearningApp.Klase
{
    class PitanjeDopuniTekst: Pitanje
    {
        String tacanOdgovor;
        String odgovor1, odgovor2, odgovor3;

        public PitanjeDopuniTekst(Int32 id, String tekst, String o1, String o2, String o3, String tOdg)
            : base(id, tekst, 1)
        {
            TacanOdgovor = tOdg;
            Odgovor1 = o1;
            Odgovor2 = o2;
            Odgovor3 = o3;
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
    }
}
