using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using MySql.Data.MySqlClient;
using System.Data.SqlClient;

using JapaneseLearningApp.Klase;
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

                MySqlDataReader dr = komanda.ExecuteReader(CommandBehavior.SequentialAccess);

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
                        Image sl = KorisnickeFunkcije.ByteArrayToImage(dr["slika"] as byte[]);
                        DateTime kre = Convert.ToDateTime(dr["Kreiran"]);

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
                komanda.CommandText = "INSERT INTO draosbaza.users(ime,prezime,username,password,datumrodenja,nivoznanja,komentar,maxlekcija,slika,kreiran) VALUES (@ime,@prezime,@username,@password,@datum,@znanje,@komentar,@maxlekcija,@slika,CURDATE());";
                komanda.Parameters.AddWithValue("@ime", tbFIRSTNAME.Text);
                komanda.Parameters.AddWithValue("@prezime", tbLASTNAME.Text);
                komanda.Parameters.AddWithValue("@username", tbNEWUSERNAME.Text);
                komanda.Parameters.AddWithValue("@password", KorisnickeFunkcije.GetMd5Hash(tbNEWPASSWORD.Text));
                komanda.Parameters.AddWithValue("@datum", dtpBIRTHDATE.Value);
                komanda.Parameters.AddWithValue("@znanje", nivoZnanja);
                komanda.Parameters.AddWithValue("@komentar", rtbCOMMENT.Text);
                komanda.Parameters.AddWithValue("@maxlekcija", 0);
                komanda.Parameters.AddWithValue("@slika", KorisnickeFunkcije.ImageToByteArray(pbSLIKA.Image));

                MessageBox.Show("Changes were succesfully made. " + PristupBazi.Manipulacija(komanda) + " rows were affected.");

                GoToProfile();
            }
            catch (Exception ex)
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
                    komanda.CommandText = "UPDATE draosbaza.users SET ime=@ime, prezime=@prezime, datumrodenja=@datum, nivoznanja=@znanje, komentar=@komentar, slika=@slika WHERE username=@username;";
                    komanda.Parameters.AddWithValue("@ime", tbPROFILEFN.Text);
                    komanda.Parameters.AddWithValue("@prezime", tbPROFILELN.Text);
                    komanda.Parameters.AddWithValue("@datum", dtpBIRTHDATE.Value);
                    komanda.Parameters.AddWithValue("@znanje", nivoZnanja);
                    komanda.Parameters.AddWithValue("@komentar", rtbPROFILEC.Text);
                    komanda.Parameters.AddWithValue("@slika", KorisnickeFunkcije.ImageToByteArray(pbPROFILESL.Image));
                    komanda.Parameters.AddWithValue("@username", aktivniKorisnik.Username);

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
        
        // Funkcije i eventi za izradu vokabular testa
        #region IZRADA_VOKABULAR_TESTA

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

        Int32 ucitajRandomPitanje(Int32 nivo) // Učita pitanje i vrati broj dugmeta sa tačnim odgovorom
        {
            MySqlConnection konekcija = new MySqlConnection("server=localhost;User Id=root;database=draosbaza");
            MySqlCommand komanda = new MySqlCommand();

            PitanjeOdaberi p = new PitanjeOdaberi();
            Int32 tacanOdgovor = 0;

            try
            {
                komanda.CommandText = "SELECT * FROM draosbaza.obicnopitanje WHERE nivo=@nivo ANd id=@id;";
                komanda.Parameters.AddWithValue("@nivo", nivo);
                Int32 rnd;

                if (nivo == 0)
                    rnd = new Random().Next(1, 17);
                else
                    rnd = new Random().Next(17, 26);

                komanda.Parameters.AddWithValue("@id", rnd);
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

                        p = new PitanjeOdaberi(id, tekst, niv, odg1, odg2, odg3, todg);
                    }

                    dr.Close();
                    ((IDisposable)dr).Dispose();

                    tbQUESTIONTXT.Text = p.TekstPitanja;
                    tacanOdgovor = postaviRandomOdgovore(new Random().Next(1, 100), p);
                }

                else
                {
                    MessageBox.Show("Ooops! Somethig went wrong while reading the text questions.");
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

        Int32 postaviRandomOdgovore(Int32 br, PitanjeOdaberi p)
        {
            if (br % 4 == 0)
            {
                buttANSWER1.Text = p.TacanOdgovor;
                buttANSWER2.Text = p.Odgovor1;
                buttANSWER3.Text = p.Odgovor2;
                buttANSWER4.Text = p.Odgovor3;

                return 1;
            }
            else if (br % 4 == 1)
            {
                buttANSWER1.Text = p.Odgovor1;
                buttANSWER2.Text = p.TacanOdgovor;
                buttANSWER3.Text = p.Odgovor3;
                buttANSWER4.Text = p.Odgovor2;

                return 2;
            }
            else if (br % 4 == 2)
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

        Int32 ucitajRandomSlikaPitanje(Int32 nivo) // Učita slika pitanje i vrati broj dugmeta sa tačnim odgovorom
        {
            MySqlConnection konekcija = new MySqlConnection("server=localhost;User Id=root;database=draosbaza");
            MySqlCommand komanda = new MySqlCommand();

            PitanjeOdaberiSliku p = new PitanjeOdaberiSliku();
            Int32 tacanOdgovor = 0;

            try
            {
                komanda.CommandText = "SELECT * FROM draosbaza.slikapitanje WHERE nivo=@nivo ANd id=@id;";
                komanda.Parameters.AddWithValue("@nivo", nivo);
                komanda.Parameters.AddWithValue("@id", new Random().Next(1, 10));
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
                        Image todg = KorisnickeFunkcije.ByteArrayToImage(dr["tacanodgovor"] as byte[]);
                        String totxt = Convert.ToString(dr["totekst"]);
                        Image odg1 = KorisnickeFunkcije.ByteArrayToImage(dr["odgovor1"] as byte[]);
                        String o1txt = Convert.ToString(dr["o1tekst"]);
                        Image odg2 = KorisnickeFunkcije.ByteArrayToImage(dr["odgovor2"] as byte[]);
                        String o2txt = Convert.ToString(dr["o2tekst"]);
                        Image odg3 = KorisnickeFunkcije.ByteArrayToImage(dr["odgovor3"] as byte[]);
                        String o3txt = Convert.ToString(dr["o3tekst"]);
                        DateTime kre = Convert.ToDateTime(dr["Kreiran"]);

                        p = new PitanjeOdaberiSliku(id, tekst, niv, todg, totxt, odg1, o1txt, odg2, o2txt, odg3, o3txt);
                    }

                    dr.Close();
                    ((IDisposable)dr).Dispose();

                    tbPICQUESTIONTXT.Text = p.TekstPitanja;

                    tacanOdgovor = postaviRandomSlikaOdgovore(new Random().Next(1, 100), p);
                }

                else
                {
                    MessageBox.Show("Ooops! Somethig went wrong while reading the picture questions.");
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

        Int32 postaviRandomSlikaOdgovore(Int32 br, PitanjeOdaberiSliku p)
        {

            if (br % 4 == 0)
            {
                buttPICANSWER1.BackgroundImage = p.TacanOdgovor;
                buttPICANSWER2.BackgroundImage = p.Odgovor1;
                buttPICANSWER3.BackgroundImage = p.Odgovor2;
                buttPICANSWER4.BackgroundImage = p.Odgovor3;

                return 1;
            }
            else if (br % 4 == 1)
            {
                buttPICANSWER1.BackgroundImage = p.Odgovor1;
                buttPICANSWER2.BackgroundImage = p.TacanOdgovor;
                buttPICANSWER3.BackgroundImage = p.Odgovor3;
                buttPICANSWER4.BackgroundImage = p.Odgovor2;

                return 2;
            }
            else if (br % 4 == 2)
            {
                buttPICANSWER1.BackgroundImage = p.Odgovor2;
                buttPICANSWER2.BackgroundImage = p.Odgovor3;
                buttPICANSWER3.BackgroundImage = p.TacanOdgovor;
                buttPICANSWER4.BackgroundImage = p.Odgovor1;

                return 3;
            }
            else
            {
                buttPICANSWER1.BackgroundImage = p.Odgovor3;
                buttPICANSWER2.BackgroundImage = p.Odgovor1;
                buttPICANSWER3.BackgroundImage = p.Odgovor2;
                buttPICANSWER4.BackgroundImage = p.TacanOdgovor;

                return 4;
            }
        }

        void refreshVocabPitanja(Boolean b)
        {
            label40.Text = "Vocabulary - Question #" + Convert.ToString(aktivniTest.TrenutnoPitanje + 1);
            label46.Text = "Vocabulary - Question #" + Convert.ToString(aktivniTest.TrenutnoPitanje + 1);

            if (aktivniTest.ZavrsenTest())
            {
                tpTESTRESULT.BackColor = Color.FromArgb(120, 200, 180);

                foreach (Control cont in tpTESTRESULT.Controls)
                    cont.BackColor = Color.FromArgb(120, 200, 180);

                labelSCOREINDICATOR.Text = Convert.ToString(aktivniTest.Skor) + "/10";
                this.tabControl1.SelectedTab = tpTESTRESULT;

                for (int i = 1; i < 11; i++)
                    ((ProgressBar)tpVOCABQUESTSIMPLE.Controls.Find("progressBar" + Convert.ToString(i), true)[0]).Value = 0;
                for (int i = 11; i < 21; i++)
                    ((ProgressBar)tpVOCABQUESTPIC.Controls.Find("progressBar" + Convert.ToString(i), true)[0]).Value = 0;
            }

            else
            {
                if (new Random().Next(1, 100) % 2 == 0)
                {
                    TextQuestion();
                    aktivniTest.TacanOdgovor = ucitajRandomPitanje(1);
                }
                else
                {
                    PictureQuestion();
                    aktivniTest.TacanOdgovor = ucitajRandomSlikaPitanje(1);
                }
            }

            lblQUESTIONINDICATOR.Text = aktivniTest.Skor + "/10";
            lblQUESTIONINDICATOR2.Text = aktivniTest.Skor + "/10";

            if (b)
            {
                ((ProgressBar)tpVOCABQUESTSIMPLE.Controls.Find("progressBar" + Convert.ToString(aktivniTest.TrenutnoPitanje), true)[0]).Value = 100;
                ((ProgressBar)tpVOCABQUESTPIC.Controls.Find("progressBar" + Convert.ToString(aktivniTest.TrenutnoPitanje + 10), true)[0]).Value = 100;
            }
            else
            {
                ((ProgressBar)tpVOCABQUESTSIMPLE.Controls.Find("progressBar" + Convert.ToString(aktivniTest.TrenutnoPitanje), true)[0]).Value = 0;
                ((ProgressBar)tpVOCABQUESTPIC.Controls.Find("progressBar" + Convert.ToString(aktivniTest.TrenutnoPitanje + 10), true)[0]).Value = 0;
            }
        }

        private void buttANSWER1_Click(object sender, EventArgs e)
        {
            refreshVocabPitanja(aktivniTest.Odgovori(1));
        }

        private void buttANSWER2_Click(object sender, EventArgs e)
        {
            refreshVocabPitanja(aktivniTest.Odgovori(2));
        }

        private void buttANSWER3_Click(object sender, EventArgs e)
        {
            refreshVocabPitanja(aktivniTest.Odgovori(3));
        }

        private void buttANSWER4_Click(object sender, EventArgs e)
        {
            refreshVocabPitanja(aktivniTest.Odgovori(4));
        }

        private void buttPICANSWER1_Click(object sender, EventArgs e)
        {
            refreshVocabPitanja(aktivniTest.Odgovori(1));
        }

        private void buttPICANSWER2_Click(object sender, EventArgs e)
        {
            refreshVocabPitanja(aktivniTest.Odgovori(2));
        }

        private void buttPICANSWER3_Click(object sender, EventArgs e)
        {
            refreshVocabPitanja(aktivniTest.Odgovori(3));
        }

        private void buttPICANSWER4_Click(object sender, EventArgs e)
        {
            refreshVocabPitanja(aktivniTest.Odgovori(4));
        }

        #endregion

        // Funkcije i eventi za izradu grammar testa
        #region IZRADA_GRAMMAR_TESTA
        
        Int32 ucitajRandomGrammarPitanje(Int32 nivo, Int32 vrsta) // Učita pitanje i vrati broj dugmeta sa tačnim odgovorom
        {
            MySqlConnection konekcija = new MySqlConnection("server=localhost;User Id=root;database=draosbaza");
            MySqlCommand komanda = new MySqlCommand();

            PitanjeKanji p = new PitanjeKanji();
            Int32 tacanOdgovor = 0;

            try
            {
                komanda.CommandText = "SELECT * FROM draosbaza.kanjipitanje WHERE nivo=@nivo AND id=@id;";
                komanda.Parameters.AddWithValue("@nivo", 3);
                //komanda.Parameters.AddWithValue("@nivo", nivo);
                komanda.Parameters.AddWithValue("@id", new Random().Next(1, 15));
                komanda.Connection = konekcija;
                konekcija.Open();

                MySqlDataReader dr = komanda.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Int32 id = Convert.ToInt32(dr["id"]);
                        Int32 niv = Convert.ToInt32(dr["nivo"]);
                        String znak = Convert.ToString(dr["znak"]);
                        Image slika = KorisnickeFunkcije.ByteArrayToImage(dr["slika"] as byte[]);
                        String znacenje = Convert.ToString(dr["znacenje"]);
                        String onyomi = Convert.ToString(dr["onyomi"]);
                        String onyomijap = Convert.ToString(dr["onyomijap"]);
                        String kunyomi = Convert.ToString(dr["kunyomi"]);
                        String kunyomijap = Convert.ToString(dr["kunyomijap"]);
                        String o1z = Convert.ToString(dr["o1znacenje"]);
                        String o2z = Convert.ToString(dr["o2znacenje"]);
                        String o3z = Convert.ToString(dr["o3znacenje"]);
                        String o1c = Convert.ToString(dr["o1citanje"]);
                        String o2c = Convert.ToString(dr["o2citanje"]);
                        String o3c = Convert.ToString(dr["o3citanje"]);
                        DateTime kre = Convert.ToDateTime(dr["kreiran"]);

                        pbKANJIPIC.Image = slika;
                        p = new PitanjeKanji(id, znak, niv, znacenje, onyomi, kunyomi, o1z, o2z, o3z, o1c, o2c, o3c);
                    }

                    dr.Close();
                    ((IDisposable)dr).Dispose();

                    tbQUESTIONTXT.Text = p.TekstPitanja;
                    tacanOdgovor = postaviRandomKanjiOdgovore(new Random().Next(1, 100), p, vrsta);
                }

                else
                {
                    MessageBox.Show("Ooops! Somethig went wrong while reading the text questions.");
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

        #endregion

        // Funkcije i eventi za izradu writing testa
        #region IZRADA_WRITING_TESTA

        Int32 ucitajRandomKanjiPitanje(Int32 nivo, Int32 vrsta) // Učita pitanje i vrati broj dugmeta sa tačnim odgovorom
        {
            MySqlConnection konekcija = new MySqlConnection("server=localhost;User Id=root;database=draosbaza");
            MySqlCommand komanda = new MySqlCommand();

            PitanjeKanji p = new PitanjeKanji();
            Int32 tacanOdgovor = 0;

            try
            {
                komanda.CommandText = "SELECT * FROM draosbaza.kanjipitanje WHERE nivo=@nivo AND id=@id;";
                komanda.Parameters.AddWithValue("@nivo", nivo);

                Int32 rnd = 0;

                if(nivo == 0)
                    rnd = new Random().Next(1, 46);
                else if(nivo == 1)
                    rnd = new Random().Next(47, 92);
                else if(nivo == 2)
                    rnd = new Random().Next(93, 105);
                else
                    rnd = new Random().Next(106, 120);

                komanda.Parameters.AddWithValue("@id", rnd);
                komanda.Connection = konekcija;
                konekcija.Open();

                MySqlDataReader dr = komanda.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Int32 id = Convert.ToInt32(dr["id"]);
                        Int32 niv = Convert.ToInt32(dr["nivo"]);
                        String znak = Convert.ToString(dr["znak"]);
                        Image slika = KorisnickeFunkcije.ByteArrayToImage(dr["slika"] as byte[]);
                        String znacenje = Convert.ToString(dr["znacenje"]);
                        String onyomi = Convert.ToString(dr["onyomi"]);
                        String onyomijap = Convert.ToString(dr["onyomijap"]);
                        String kunyomi = Convert.ToString(dr["kunyomi"]);
                        String kunyomijap = Convert.ToString(dr["kunyomijap"]);
                        String o1z = Convert.ToString(dr["o1znacenje"]);
                        String o2z = Convert.ToString(dr["o2znacenje"]);
                        String o3z = Convert.ToString(dr["o3znacenje"]);
                        String o1c = Convert.ToString(dr["o1citanje"]);
                        String o2c = Convert.ToString(dr["o2citanje"]);
                        String o3c = Convert.ToString(dr["o3citanje"]);
                        DateTime kre = Convert.ToDateTime(dr["kreiran"]);

                        pbKANJIPIC.Image = slika;
                        p = new PitanjeKanji(id, znak, niv, znacenje, onyomi, kunyomi, o1z, o2z, o3z, o1c, o2c, o3c);
                    }

                    dr.Close();
                    ((IDisposable)dr).Dispose();

                    tbQUESTIONTXT.Text = p.TekstPitanja;
                    tacanOdgovor = postaviRandomKanjiOdgovore(new Random().Next(1, 100), p, vrsta);
                }

                else
                {
                    MessageBox.Show("Ooops! Somethig went wrong while reading the text questions.");
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

        Int32 postaviRandomKanjiOdgovore(Int32 br, PitanjeKanji p, Int32 vrsta)
        {
            if (odabraniNivo < 3 || vrsta == 1)
            {
                if (br % 4 == 0)
                {
                    buttKANJIANSWER1.Text = p.Znacenje;
                    buttKANJIANSWER2.Text = p.O1znacenje;
                    buttKANJIANSWER3.Text = p.O2znacenje;
                    buttKANJIANSWER4.Text = p.O3znacenje;

                    return 1;
                }
                else if (br % 4 == 1)
                {
                    buttKANJIANSWER1.Text = p.O1znacenje;
                    buttKANJIANSWER2.Text = p.Znacenje;
                    buttKANJIANSWER3.Text = p.O3znacenje;
                    buttKANJIANSWER4.Text = p.O2znacenje;

                    return 2;
                }
                else if (br % 4 == 2)
                {
                    buttKANJIANSWER1.Text = p.O2znacenje;
                    buttKANJIANSWER2.Text = p.O3znacenje;
                    buttKANJIANSWER3.Text = p.Znacenje;
                    buttKANJIANSWER4.Text = p.O1znacenje;

                    return 3;
                }
                else
                {
                    buttKANJIANSWER1.Text = p.O3znacenje;
                    buttKANJIANSWER2.Text = p.O1znacenje;
                    buttKANJIANSWER3.Text = p.O2znacenje;
                    buttKANJIANSWER4.Text = p.Znacenje;

                    return 4;
                }
            }
            else
            {
                if (br % 4 == 0)
                {
                    buttKANJIANSWER1.Text = p.Kunyomi;
                    buttKANJIANSWER2.Text = p.O1citanje;
                    buttKANJIANSWER3.Text = p.O2citanje;
                    buttKANJIANSWER4.Text = p.O3citanje;

                    return 1;
                }
                else if (br % 4 == 1)
                {
                    buttKANJIANSWER1.Text = p.O1citanje;
                    buttKANJIANSWER2.Text = p.Onyomi;
                    buttKANJIANSWER3.Text = p.O3citanje;
                    buttKANJIANSWER4.Text = p.O2citanje;

                    return 2;
                }
                else if (br % 4 == 2)
                {
                    buttKANJIANSWER1.Text = p.O2citanje;
                    buttKANJIANSWER2.Text = p.O3citanje;
                    buttKANJIANSWER3.Text = p.Kunyomi;
                    buttKANJIANSWER4.Text = p.O1citanje;

                    return 3;
                }
                else
                {
                    buttKANJIANSWER1.Text = p.O3citanje;
                    buttKANJIANSWER2.Text = p.O1citanje;
                    buttKANJIANSWER3.Text = p.O2citanje;
                    buttKANJIANSWER4.Text = p.Onyomi;

                    return 4;
                }
            }
        }

        void refreshKanjiPitanja(Boolean b)
        {
            label48.Text = "Writing - Question #" + Convert.ToString(aktivniTest.TrenutnoPitanje + 1);

            if (aktivniTest.ZavrsenTest())
            {
                tpTESTRESULT.BackColor = Color.FromArgb(255, 192, 128);

                foreach (Control cont in tpTESTRESULT.Controls)
                    cont.BackColor = Color.FromArgb(255, 192, 128);

                this.tabControl1.SelectedTab = tpTESTRESULT;
                labelSCOREINDICATOR.Text = Convert.ToString(aktivniTest.Skor) + "/10";

                for(int i=21; i<31; i++)
                    ((ProgressBar)tpKANJIQUESTION.Controls.Find("progressBar" + Convert.ToString(i), true)[0]).Value = 0;
            }

            else
            {
                if (new Random().Next(1, 100) % 2 == 0)
                {
                    KanjiQuestion();
                    aktivniTest.TacanOdgovor = ucitajRandomKanjiPitanje(odabraniNivo, 1);
                }
                else
                {
                    KanjiQuestion();
                    aktivniTest.TacanOdgovor = ucitajRandomKanjiPitanje(odabraniNivo, 2);
                }
            }

            labelKQINDICATOR.Text = aktivniTest.Skor + "/10";

            if (b)
                ((ProgressBar)tpKANJIQUESTION.Controls.Find("progressBar" + Convert.ToString(aktivniTest.TrenutnoPitanje + 20), true)[0]).Value = 100;
            else
                ((ProgressBar)tpKANJIQUESTION.Controls.Find("progressBar" + Convert.ToString(aktivniTest.TrenutnoPitanje + 20), true)[0]).Value = 0;
        }

        private void buttKANJIANSWER1_Click(object sender, EventArgs e)
        {
            refreshKanjiPitanja(aktivniTest.Odgovori(1));
        }

        private void buttKANJIANSWER2_Click(object sender, EventArgs e)
        {
            refreshKanjiPitanja(aktivniTest.Odgovori(2));
        }

        private void buttKANJIANSWER3_Click(object sender, EventArgs e)
        {
            refreshKanjiPitanja(aktivniTest.Odgovori(3));
        }

        private void buttKANJIANSWER4_Click(object sender, EventArgs e)
        {
            refreshKanjiPitanja(aktivniTest.Odgovori(4));
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
            aktivniTest = new Test();
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

        private void button32_Click(object sender, EventArgs e)
        {
            GoToTestMenu();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            GoToTestMenu();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            GoToTestMenu();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            GoToTestMenu();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            GoToMainMenu();
        }

        private void buttVOCABULARYTEST_Click(object sender, EventArgs e)
        {
            aktivniTest.Tip = "VOCAB";
            ChapterSelect("VOCAB");
        }

        private void buttGRAMMARTEST_Click(object sender, EventArgs e)
        {
            aktivniTest.Tip = "GRAMMAR";
            ChapterSelect("GRAMMAR");
        }

        private void buttWRITINGTEST_Click(object sender, EventArgs e)
        {
            aktivniTest.Tip = "KANJI";
            ChapterSelect("KANJI");
        }

        private void button25_Click(object sender, EventArgs e)
        {
            odabraniNivo = 0;
            odaberiVrstuPitanja(aktivniTest.Tip);
            zapocniTest(odabraniNivo);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            odabraniNivo = 1;
            odaberiVrstuPitanja(aktivniTest.Tip);
            zapocniTest(odabraniNivo);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            odabraniNivo = 2;
            odaberiVrstuPitanja(aktivniTest.Tip);
            zapocniTest(odabraniNivo);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            odabraniNivo = 3;
            odaberiVrstuPitanja(aktivniTest.Tip);
            zapocniTest(odabraniNivo);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            odabraniNivo = 4;
            odaberiVrstuPitanja(aktivniTest.Tip);
            zapocniTest(odabraniNivo);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            odabraniNivo = 5;
            odaberiVrstuPitanja(aktivniTest.Tip);
            zapocniTest(odabraniNivo);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            odabraniNivo = 6;
            odaberiVrstuPitanja(aktivniTest.Tip);
            zapocniTest(odabraniNivo);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            odabraniNivo = 7;
            odaberiVrstuPitanja(aktivniTest.Tip);
            zapocniTest(odabraniNivo);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            odabraniNivo = 8;
            odaberiVrstuPitanja(aktivniTest.Tip);
            zapocniTest(odabraniNivo);
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            odabraniNivo = 9;
            odaberiVrstuPitanja(aktivniTest.Tip);
            zapocniTest(odabraniNivo);
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            odabraniNivo = 10;
            odaberiVrstuPitanja(aktivniTest.Tip);
            zapocniTest(odabraniNivo);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            odabraniNivo = 11;
            odaberiVrstuPitanja(aktivniTest.Tip);
            zapocniTest(odabraniNivo);
        }

        public void odaberiVrstuPitanja(String tip)
        {
            if (tip.Equals("VOCAB"))
                TextQuestion();
            else if (tip.Equals("KANJI"))
                KanjiQuestion();
            else
                GrammarQuestion();
        }

        void zapocniTest(Int32 n)
        {
            aktivniTest.Resetuj();

            if (aktivniTest.Tip.Equals("VOCAB"))
                aktivniTest.TacanOdgovor = ucitajRandomPitanje(n);
            else if (aktivniTest.Tip.Equals("KANJI"))
                aktivniTest.TacanOdgovor = ucitajRandomKanjiPitanje(n, 1);
            else
                aktivniTest.TacanOdgovor = ucitajRandomGrammarPitanje(n, 1);
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

        public void ChapterSelect(String tip)
        {
            if(tip.Equals("VOCAB")) 
            {
                tpTESTLIST.BackColor = Color.FromArgb(120, 200, 180);
                postaviBojeButtona(Color.FromArgb(120, 200, 180));
                this.tabControl1.SelectedTab = tpTESTLIST;
            }
            else if (tip.Equals("KANJI"))
            {
                tpTESTLIST.BackColor = Color.FromArgb(255, 192, 128);
                postaviBojeButtona(Color.FromArgb(255, 192, 128));
                this.tabControl1.SelectedTab = tpTESTLIST;
            }
            else 
            {
                tpTESTLIST.BackColor = Color.FromArgb(80, 120, 100);
                postaviBojeButtona(Color.FromArgb(80, 120, 100));
                this.tabControl1.SelectedTab = tpTESTLIST;
            }

            zakljucajNivoe(aktivniKorisnik.MaxLekcija);
        }

        public void TextQuestion()
        {
            this.tabControl1.SelectedTab = tpVOCABQUESTSIMPLE;
        }

        public void PictureQuestion()
        {
            this.tabControl1.SelectedTab = tpVOCABQUESTPIC;
        }

        public void GrammarQuestion()
        {
            this.tabControl1.SelectedTab = tpGRAMMARQUESTION;
        }

        public void KanjiQuestion()
        {
            this.tabControl1.SelectedTab = tpKANJIQUESTION;
        }

        public void postaviBojeButtona(Color c)
        {
            foreach (Control b in tpTESTLIST.Controls)
                b.BackColor = c;
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
