﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Linq;

using JapaneseLearningApp.Klase;
using JapaneseLearningApp.TestKontrole;
using JapaneseLearningApp.Properties;

namespace JapaneseLearningApp
{
    public partial class GlavnaForma : Form
    {
        User aktivniKorisnik; //Korisnik koji je trenutno aktivan na aplikaciji, da se ne pristupa stalno bazi kada trebaju neke informacije
        Test aktivniTest; //Test koji je odabrao da radi korisnik, isti razlog kao i u prethodnom slučaju
        Int32 odabraniNivo; //Nivo iz kojeg je odabran test da se radi zbog mogućnosti ponavljanja testova nižeg nivoa

        public GlavnaForma()
        {
            InitializeComponent();
        }

        // Funkcije Enter i Leave evenata u kojima se postavlja placeholder tekst Textboxova za Username i Password 
        #region IZGLED_POČETNE_STRANICE

        private void tbUSERNAME_Enter(object sender, EventArgs e)
        {
            if (tbUSERNAME.Text == " Username...")
            {
                tbUSERNAME.ForeColor = Color.FromArgb(51, 51, 51);
                tbUSERNAME.Text = "";
            }
        }
        private void tbUSERNAME_Leave(object sender, EventArgs e)
        {
            if (tbUSERNAME.Text == "")
            {
                tbUSERNAME.ForeColor = Color.LightGray;
                tbUSERNAME.Text = " Username...";
            }
        }
        private void tbPASSWORD_Enter(object sender, EventArgs e)
        {
            if (tbPASSWORD.Text == " Password...")
            {
                tbPASSWORD.ForeColor = Color.FromArgb(51, 51, 51);
                tbPASSWORD.PasswordChar = '*';
                tbPASSWORD.Text = "";
            }
        }
        private void tbPASSWORD_Leave(object sender, EventArgs e)
        {
            if (tbPASSWORD.Text == "")
            {
                tbPASSWORD.ForeColor = Color.LightGray;
                tbPASSWORD.PasswordChar = '\0';
                tbPASSWORD.Text = " Password...";
            }
        }

        #endregion

        // Event dugmeta Login koji pronalazi korisnika u bazi i učitava mu informacije u privatnu varijablu aktivniKorisnik
        #region LOGIN_KORISNIKA

        private void btnLOGIN_Click(object sender, EventArgs e)
        {
            MySqlConnection konekcija = new MySqlConnection("server=localhost;User Id=root;database=draosbaza");
            MySqlCommand komanda = new MySqlCommand();

            try
            {
                komanda.CommandText = "SELECT * FROM draosbaza.users WHERE username=@username AND password=@password;";
                komanda.Parameters.AddWithValue("@username", tbUSERNAME.Text);
                komanda.Parameters.AddWithValue("@password", KorisnickeFunkcije.GetMd5Hash(tbPASSWORD.Text));
                komanda.Connection = konekcija;
                konekcija.Open();

                MySqlDataReader dr = komanda.ExecuteReader();

                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        Int32 id = Convert.ToInt32(dr["ID"]);
                        String i = Convert.ToString(dr["Ime"]);
                        String p = Convert.ToString(dr["Prezime"]);
                        String un = Convert.ToString(dr["Username"]);
                        String pass = Convert.ToString(dr["Password"]);
                        DateTime dat = Convert.ToDateTime(dr["DatumRodenja"]);
                        String nz = Convert.ToString(dr["NivoZnanja"]);
                        String kom = Convert.ToString(dr["Komentar"]);
                        DateTime kre = Convert.ToDateTime(dr["Kreiran"]);

                        Image sl = Image.FromFile(un + ".jpg");
                        pbSLIKA.Image = sl;

                        aktivniKorisnik = new User(i, p, un, pass, dat, nz, kom, sl);
                    }

                    dr.Close();
                    ((IDisposable)dr).Dispose();

                    this.tabControl1.SelectedTab = tpPRVIMENU;
                    tbUSERNAME.ForeColor = Color.LightGray;
                    tbUSERNAME.Text = " Username...";
                    tbPASSWORD.ForeColor = Color.LightGray;
                    tbPASSWORD.PasswordChar = '\0';
                    tbPASSWORD.Text = " Password...";
                }

                else
                {
                    MessageBox.Show("Invalid username or password!");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                konekcija.Close();
            }
        }

        #endregion

        // Funkcije i Eventi kontrola vezani za početnu registraciju korisnika
        #region SIGNUP_NOVOG_KORISNIKA

        private void llblSIGNUP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.tabControl1.SelectedTab = tpSIGNUP;
        }

        private void btnUPLOAD_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();

            if (o.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(o.FileName);
                pbSLIKA.Image = img;
            }
        }

        private void btnSIGNUP_Click(object sender, EventArgs e)
        {
            try
            {
                String nivoZnanja;

                if (radioBEG.Checked)
                    nivoZnanja = "Begginer";
                else if (radioINTER.Checked)
                    nivoZnanja = "Intermediate";
                else
                    nivoZnanja = "Expert";

                User u = new User(tbFIRSTNAME.Text, tbLASTNAME.Text, tbNEWUSERNAME.Text, KorisnickeFunkcije.GetMd5Hash(tbPASSWORD.Text), dtpBIRTHDATE.Value, nivoZnanja, rtbCOMMENT.Text, pbSLIKA.Image);
                aktivniKorisnik = u;

                MySqlCommand komanda = new MySqlCommand();
                komanda.CommandText = "INSERT INTO draosbaza.users(ime,prezime,username,password,datumrodenja,nivoznanja,komentar,maxlekcija,kreiran) VALUES (@ime,@prezime,@username,@password,@datum,@znanje,@komentar,@maxlekcija,CURDATE());";
                komanda.Parameters.AddWithValue("@ime", tbFIRSTNAME.Text);
                komanda.Parameters.AddWithValue("@prezime", tbLASTNAME.Text);
                komanda.Parameters.AddWithValue("@username", tbNEWUSERNAME.Text);
                komanda.Parameters.AddWithValue("@password", KorisnickeFunkcije.GetMd5Hash(tbNEWPASSWORD.Text));
                komanda.Parameters.AddWithValue("@datum", dtpBIRTHDATE.Value);
                komanda.Parameters.AddWithValue("@znanje", nivoZnanja);
                komanda.Parameters.AddWithValue("@komentar", rtbCOMMENT.Text);
                komanda.Parameters.AddWithValue("@maxlekcija", 0);

                Image sl = pbSLIKA.Image;
                sl.Save(tbNEWUSERNAME.Text + ".jpg");

                MessageBox.Show("Changes were succesfully made. " + PristupBazi.Manipulacija(komanda) + " rows were affected.");

                GoToProfile();
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Changes failed. Reason: " + ex.Message);
            }
        }

        #endregion

        // Funkcije i Eventi kontrola vezani za promjenu passworda
        #region PROMJENA_PASSWORDA

        private void llblFORGOTPASS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.tabControl1.SelectedTab = tpFORGOTPASS;
        }

        private void cbUNMASKPASS_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUNMASKPASS.Checked)
                tbNEWPASSWORD.PasswordChar = '\0';
            else
                tbNEWPASSWORD.PasswordChar = '*';
        }

        private void cbCPUNMASK_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCPUNMASK.Checked)
            {
                tbCPASSPASS.PasswordChar = '\0';
                tbCPASSCONFIRM.PasswordChar = '\0';
            }
            else
            {
                tbCPASSPASS.PasswordChar = '*';
                tbCPASSCONFIRM.PasswordChar = '*';
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                if (!tbCPASSPASS.Text.Equals(tbCPASSCONFIRM.Text))
                {
                    MessageBox.Show("Password and Confirm password fields must be the same!");
                }

                else
                {
                    MySqlCommand komanda = new MySqlCommand();
                    komanda.CommandText = "UPDATE draosbaza.users SET password=@novipassword WHERE username=@username;";
                    komanda.Parameters.AddWithValue("@username", tbCPASSUSERNAME.Text);
                    komanda.Parameters.AddWithValue("@novipassword", KorisnickeFunkcije.GetMd5Hash(tbCPASSPASS.Text));
                    MessageBox.Show("Changes were succesfully made. " + PristupBazi.Manipulacija(komanda) + " rows were affected.");
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Changes failed. Reason: " + ex.Message);
            }
        }

        #endregion

        // Event ulaska na tab gdje se prikazuju sve informacije o korisnikovom profilu
        #region PREGLED_PROFILA_KORISNIKA

        private void tpPROFILE_Enter(object sender, EventArgs e)
        {
            try
            {
                lblUSER.Text = "Welcome, " + aktivniKorisnik.Ime + " !";

                pbPROFILESL.Image = aktivniKorisnik.ProfilnaSlika;
                tbPROFILEFN.Text = aktivniKorisnik.Ime;
                tbPROFILELN.Text = aktivniKorisnik.Prezime;
                dtpPROFILEBD.Value = aktivniKorisnik.DatumRodenja;
                rtbPROFILEC.Text = aktivniKorisnik.Komentar;

                if (aktivniKorisnik.NivoZnanja.Equals("Begginer"))
                    rbPROFILEB.Checked = true;
                else if (aktivniKorisnik.NivoZnanja.Equals("Intermediate"))
                    rbPROFILEI.Checked = true;
                else
                    rbPROFILEE.Checked = true;
            }

            catch (Exception)
            {
                lblUSER.Text = "You must login first !";
            }
        }

        #endregion

        // Eventi i funkcije za izmjene korisnickih informacija na tabu gdje se pregleda korisnicki profil
        #region IZMJENE_KORISNICKIH_INFORMACIJA

        private void btnEDITPROFILEPIC_Click(object sender, EventArgs e)
        {
            pbPROFILESL.Enabled = true;

            OpenFileDialog o = new OpenFileDialog();

            if (o.ShowDialog() == DialogResult.OK)
                pbPROFILESL.Image = Image.FromFile(o.FileName);
        }

        private void btnEDITFIRSTNAME_Click(object sender, EventArgs e)
        {
            tbPROFILEFN.Enabled = true;
        }

        private void btnEDITLASTNAME_Click(object sender, EventArgs e)
        {
            tbPROFILELN.Enabled = true;
        }

        private void btnEDITDATE_Click(object sender, EventArgs e)
        {
            dtpPROFILEBD.Enabled = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            rbPROFILEB.Enabled = true;
            rbPROFILEI.Enabled = true;
            rbPROFILEE.Enabled = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            rtbPROFILEC.Enabled = true;
        }

        private void btnPROFILEAPPLYCHANGES_Click(object sender, EventArgs e)
        {
            String nivoZnanja;

            if (!pbPROFILESL.Enabled && !tbPROFILEFN.Enabled && !tbPROFILELN.Enabled && !dtpBIRTHDATE.Enabled && !rbPROFILEB.Enabled && !rbPROFILEI.Enabled && !rbPROFILEE.Enabled && !rtbPROFILEC.Enabled && !pbPROFILESL.Enabled)
                MessageBox.Show("You must make changes to commit them to your profile.");
            else
            {
                try
                {
                    if (rbPROFILEB.Checked)
                        nivoZnanja = "Begginer";
                    else if (rbPROFILEI.Checked)
                        nivoZnanja = "Intermediate";
                    else
                        nivoZnanja = "Expert";

                    MySqlCommand komanda = new MySqlCommand();
                    komanda.CommandText = "UPDATE draosbaza.users SET ime=@ime, prezime=@prezime, datumrodenja=@datum, nivoznanja=@znanje, komentar=@komentar WHERE username=@username;";
                    komanda.Parameters.AddWithValue("@ime", tbPROFILEFN.Text);
                    komanda.Parameters.AddWithValue("@prezime", tbPROFILELN.Text);
                    komanda.Parameters.AddWithValue("@datum", dtpBIRTHDATE.Value);
                    komanda.Parameters.AddWithValue("@znanje", nivoZnanja);
                    komanda.Parameters.AddWithValue("@komentar", rtbPROFILEC.Text);
                    komanda.Parameters.AddWithValue("@username", aktivniKorisnik.Username);

                    //saveImage(aktivniKorisnik.ProfilnaSlika, aktivniKorisnik.Username + ".jpg");

                    MessageBox.Show("Changes were succesfully made. " + PristupBazi.Manipulacija(komanda) + " rows were affected.");

                    aktivniKorisnik = new User(tbPROFILEFN.Text, tbPROFILELN.Text, aktivniKorisnik.Username, aktivniKorisnik.Password, dtpBIRTHDATE.Value, nivoZnanja, rtbPROFILEC.Text, pbPROFILESL.Image);
                    lblUSER.Text = "Welcome, " + aktivniKorisnik.Ime + " !";

                    tbPROFILEFN.Enabled = false;
                    tbPROFILELN.Enabled = false;
                    dtpBIRTHDATE.Enabled = false;
                    rbPROFILEB.Enabled = false;
                    rbPROFILEI.Enabled = false;
                    rbPROFILEE.Enabled = false;
                    rtbPROFILEC.Enabled = false;
                    pbPROFILESL.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Changes failed. Reason: " + ex.Message);
                }
            }
        }

        #endregion
        
        // Funkcije i eventi za izradu testa
        #region IZRADA_TESTA

        void zakljucajNivoe(Int32 nivo)
        {
            foreach (var b in tpTESTLIST.Controls.OfType<Button>())
            {
                try
                {
                    if (Convert.ToInt32(b.Text) > nivo)
                        b.Enabled = false;
                }
                catch (Exception)
                {

                }
            }
        }

        void zapocniTest()
        {
            aktivniTest = new Test();
            aktivniTest.TacanOdgovor = ucitajRandomPitanje(0);
        }

        Int32 postaviRandomOdgovore(Int32 br, PitanjeOdaberi p)
        {
            if (br%4 == 0)
            {
                buttANSWER1.Text = p.TacanOdgovor;
                buttANSWER2.Text = p.Odgovor1;
                buttANSWER3.Text = p.Odgovor2;
                buttANSWER4.Text = p.Odgovor3;

                return 1;
            }
            else if (br%4 == 1)
            {
                buttANSWER1.Text = p.Odgovor1;
                buttANSWER2.Text = p.TacanOdgovor;
                buttANSWER3.Text = p.Odgovor3;
                buttANSWER4.Text = p.Odgovor2;

                return 2;
            }
            else if (br%4 == 2)
            {
                buttANSWER1.Text = p.Odgovor2;
                buttANSWER2.Text = p.Odgovor3;
                buttANSWER3.Text = p.TacanOdgovor;
                buttANSWER4.Text = p.Odgovor1;

                return 3;
            }
            else
            {
                buttANSWER1.Text = p.Odgovor3;
                buttANSWER2.Text = p.Odgovor1;
                buttANSWER3.Text = p.Odgovor2;
                buttANSWER4.Text = p.TacanOdgovor;

                return 4;
            }
        }

        Int32 ucitajRandomPitanje(Int32 nivo) // Učita pitanje i vrati broj dugmeta sa tačnim odgovorom
        {
            MySqlConnection konekcija = new MySqlConnection("server=localhost;User Id=root;database=draosbaza");
            MySqlCommand komanda = new MySqlCommand();

            PitanjeOdaberi p = new PitanjeOdaberi();
            Int32 tacanOdgovor = 0;

            try
            {
                komanda.CommandText = "SELECT * FROM draosbaza.obicnopitanje WHERE nivo=@nivo ANd id=@id;";
                komanda.Parameters.AddWithValue("@nivo", odabraniNivo);
                komanda.Parameters.AddWithValue("@id", new Random().Next(1, 16));
                komanda.Connection = konekcija;
                konekcija.Open();

                MySqlDataReader dr = komanda.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Int32 id = Convert.ToInt32(dr["id"]);
                        Int32 niv = Convert.ToInt32(dr["nivo"]);
                        String tekst = Convert.ToString(dr["tekst"]);
                        String todg = Convert.ToString(dr["tacanodgovor"]);
                        String odg1 = Convert.ToString(dr["odgovor1"]);
                        String odg2 = Convert.ToString(dr["odgovor2"]);
                        String odg3 = Convert.ToString(dr["odgovor3"]);
                        DateTime kre = Convert.ToDateTime(dr["Kreiran"]);

                        p = new PitanjeOdaberi(id, tekst, odg1, odg2, odg3, todg, niv);
                    }

                    dr.Close();
                    ((IDisposable)dr).Dispose();

                    lblQUESTIONTXT.Text = p.TekstPitanja;
                    tacanOdgovor = postaviRandomOdgovore(new Random().Next(1, 100), p);
                }

                else
                {
                    MessageBox.Show("Invalid username or password!");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                konekcija.Close();
            }

            return tacanOdgovor;
        }

        private void buttANSWER1_Click(object sender, EventArgs e)
        {
            refreshPitanja(aktivniTest.Odgovori(1));
        }

        private void buttANSWER2_Click(object sender, EventArgs e)
        {
            refreshPitanja(aktivniTest.Odgovori(2));
        }

        private void buttANSWER3_Click(object sender, EventArgs e)
        {
            refreshPitanja(aktivniTest.Odgovori(3));
        }

        private void buttANSWER4_Click(object sender, EventArgs e)
        {
            refreshPitanja(aktivniTest.Odgovori(4));
        }

        void refreshPitanja(Boolean b)
        {
            label40.Text = "Vocabulary - Question #" + Convert.ToString(aktivniTest.TrenutnoPitanje + 1);

            if (aktivniTest.ZavrsenTest())
            {
                this.tabControl1.SelectedTab = tpTESTRESULT;
                labelSCOREINDICATOR.Text = Convert.ToString(aktivniTest.Skor) + "/10";
            }

            else
                aktivniTest.TacanOdgovor = ucitajRandomPitanje(0);

            lblQUESTIONINDICATOR.Text = aktivniTest.Skor + "/10";

            if (b)
                ((ProgressBar)tpVOCABQUESTSIMPLE.Controls.Find("progressBar" + Convert.ToString(aktivniTest.TrenutnoPitanje), true)[0]).Value = 100;
            else
                ((ProgressBar)tpVOCABQUESTSIMPLE.Controls.Find("progressBar" + Convert.ToString(aktivniTest.TrenutnoPitanje), true)[0]).Value = 0;
        }

        #endregion

        // Eventi i funkcije za promjenu tabova i time promjenu stranice koja se prikazuje
        #region NAVIGACIJA_KROZ_APLIKACIJU

        private void button12_Click(object sender, EventArgs e)
        {
            GoToMainMenu();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            GoToMainMenu();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            GoToProfile();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            GoToProfile();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            Logout();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GoToTestMenu();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            GoToMainMenu();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            GoToProfile();
        }

        private void buttVOCABULARYTEST_Click(object sender, EventArgs e)
        {
            ChapterSelect();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Questions();
        }

        public void GoToMainMenu()
        {
            this.tabControl1.SelectedTab = tpPRVIMENU;
        }

        public void GoToTestMenu()
        {
            this.tabControl1.SelectedTab = tpTESTMENU;
        }

        public void GoToProfile()
        {
            this.tabControl1.SelectedTab = tpPROFILE;
        }

        public void GoToSignup()
        {
            this.tabControl1.SelectedTab = tpSIGNUP;
        }

        public void Logout()
        {
            this.tabControl1.SelectedTab = tpLOGIN;

            tbUSERNAME.Text = "";
            tbPASSWORD.Text = "";
        }

        public void ChapterSelect()
        {
            this.tabControl1.SelectedTab = tpTESTLIST;
            zakljucajNivoe(aktivniKorisnik.MaxLekcija);
        }

        public void Questions()
        {
            odabraniNivo = 0;
            this.tabControl1.SelectedTab = tpVOCABQUESTSIMPLE;
            zapocniTest();
        }

        #endregion

        //Dejo i ti sebi ovako razvrstaj, da se zna šta je čije i da plaho ne brkamo jedan drugom
        #region DEJINE_FUNKCIJE

        private void bLectures_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = tpLecturesList;
        }

        private void tpLecturesList_Enter(object sender, EventArgs e)
        {
            //this.mainPanel.Controls.Add(new LecturesList(mainPanel));
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == tabControl1.TabPages.IndexOf(tpLecturesList))
            {
                this.mainPanel.Controls.Add(new LecturesList(mainPanel));
            }
        }

        #endregion
    }
}
