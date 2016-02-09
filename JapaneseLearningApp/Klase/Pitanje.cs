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
        Int32 nivo;

        public Pitanje() { }

        public Pitanje(Int32 id, String tekst, Int32 n) 
        {
            IdPitanja = id;
            TekstPitanja = tekst;
            Nivo = n;
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

        public Int32 Nivo
        {
            get { return nivo; }
            set { nivo = value; }
        }
    }
}
