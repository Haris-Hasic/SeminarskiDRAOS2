using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapaneseLearningApp.Klase
{
    public class User
    {
        String ime, prezime, username, password, nivoZnanja, komentar;
        DateTime datumRodenja;
        Int32 maxLekcija;
        Image profilnaSlika;

        public User() { }

        public User(String i, String p, String un, String pass, DateTime dr, String nz, String k, Image sl)
        {
            Ime = i;
            Prezime = p;
            Username = un;
            Password = pass;
            DatumRodenja = dr;
            NivoZnanja = nz;
            Komentar = k;
            MaxLekcija = 0;
            ProfilnaSlika = sl;
        }

        public String Ime
        {
            get { return ime; }
            set { ime = value; }
        }

        public String Prezime
        {
            get { return prezime; }
            set { prezime = value; }
        }

        public String Username
        {
            get { return username; }
            set { username = value; }
        }

        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        public DateTime DatumRodenja
        {
            get { return datumRodenja; }
            set { datumRodenja = value; }
        }

        public String NivoZnanja
        {
            get { return nivoZnanja; }
            set { nivoZnanja = value; }
        }

        public String Komentar
        {
            get { return komentar; }
            set { komentar = value; }
        }

        public Int32 MaxLekcija
        {
            get { return maxLekcija; }
            set { maxLekcija = value; }
        }

        public Image ProfilnaSlika
        {
            get { return profilnaSlika; }
            set { profilnaSlika = value; }
        }
    }
}
