using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapaneseLearningApp.Klase
{
    class PitanjeKanji : Pitanje
    {

        String znacenje, kunyomi, onyomi;
        String o1znacenje, o2znacenje, o3znacenje;
        String o1citanje, o2citanje, o3citanje;

        public PitanjeKanji() { }

        public PitanjeKanji(Int32 id, String tekst, Int32 n, String z, String ky, String oy, String o1z, String o2z, String o3z, String o1c, String o2c, String o3c)
            : base(id, tekst, n)
        {
            Znacenje = z;
            Kunyomi = ky;
            Onyomi = oy;
            O1znacenje = o1z;
            O2znacenje = o2z;
            O3znacenje = o3z;
            O1citanje = o1c;
            O2citanje = o2c;
            O3citanje = o3c;
        }

        public String Znacenje
        {
            get { return znacenje; }
            set { znacenje = value; }
        }

        public String Kunyomi
        {
            get { return kunyomi; }
            set { kunyomi = value; }
        }

        public String Onyomi
        {
            get { return onyomi; }
            set { onyomi = value; }
        }

        public String O1znacenje
        {
            get { return o1znacenje; }
            set { o1znacenje = value; }
        }

        public String O2znacenje
        {
            get { return o2znacenje; }
            set { o2znacenje = value; }
        }

        public String O3znacenje
        {
            get { return o3znacenje; }
            set { o3znacenje = value; }
        }

        public String O1citanje
        {
            get { return o1citanje; }
            set { o1citanje = value; }
        }

        public String O2citanje
        {
            get { return o2citanje; }
            set { o2citanje = value; }
        }

        public String O3citanje
        {
            get { return o3citanje; }
            set { o3citanje = value; }
        }
    }
}
