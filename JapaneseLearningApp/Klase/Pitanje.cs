using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapaneseLearningApp.Klase
{
    class Pitanje
    {
        Int32 idPitanja;
        String tekstPitanja;

        public Pitanje() { }

        public Pitanje(Int32 id, String tekst) 
        {
            IdPitanja = id;
            TekstPitanja = tekst;
        }

        public Int32 IdPitanja
        {
            get { return idPitanja; }
            set { idPitanja = value; }
        }

        public String TekstPitanja
        {
            get { return tekstPitanja; }
            set { tekstPitanja = value; }
        }
    }
}
