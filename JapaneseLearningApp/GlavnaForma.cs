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
using System.Runtime.InteropServices;
using System.Windows.Forms.DataVisualization.Charting;

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

        static String konekcioniString = "server=localhost;User Id=root;database=draosbaza";
        //MySqlConnectionStringBuilder conn_string;

        public GlavnaForma()
        {
            // Ovo je za konekciju na udaljenu bazu
            /*
            conn_string = new MySqlConnectionStringBuilder();
            conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "db4free.net";
            conn_string.Port = 3306;
            conn_string.UserID = "draosroot";
            conn_string.Password = "draosroot";
            conn_string.Database = "draosbaza";
            konekcioniString = conn_string.ToString();
            */
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
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
            MySqlConnection konekcija = new MySqlConnection(konekcioniString);
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
                        Int32 maxL = Convert.ToInt32(dr["maxlekcija"]);
                        Image sl = KorisnickeFunkcije.ByteArrayToImage(dr["slika"] as byte[]);
                        DateTime kre = Convert.ToDateTime(dr["Kreiran"]);

                        aktivniKorisnik = new User(i, p, un, pass, dat, nz, kom, sl);
                        aktivniKorisnik.MaxLekcija = maxL;
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
            if (errorProvider1.GetError(tbNEWUSERNAME).Equals("") && errorProvider1.GetError(tbNEWPASSWORD).Equals("") && errorProvider1.GetError(tbFIRSTNAME).Equals("") && errorProvider1.GetError(tbLASTNAME).Equals("") && KorisnickeFunkcije.validirajSvePodatkeSignUp(tbFIRSTNAME.Text, tbLASTNAME.Text, tbNEWUSERNAME.Text, tbNEWPASSWORD.Text))
            {
                try
                {
                    MySqlConnection konekcija = new MySqlConnection(konekcioniString);
                    MySqlCommand kom1 = new MySqlCommand();
                    kom1.CommandText = "SELECT * FROM draosbaza.users WHERE username=@un OR password=@pass;";
                    kom1.Parameters.AddWithValue("@un", tbNEWUSERNAME.Text);
                    kom1.Parameters.AddWithValue("@pass", KorisnickeFunkcije.GetMd5Hash(tbNEWPASSWORD.Text));
                    kom1.Connection = konekcija;
                    konekcija.Open();

                    MySqlDataReader dr1 = kom1.ExecuteReader();

                    if (dr1.HasRows)
                    {
                        dr1.Close();
                        ((IDisposable)dr1).Dispose();
                        konekcija.Close();
                        MessageBox.Show("The username/password you entered is already taken. Enter new username/password.", "Existing user information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
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

                        PristupBazi.Manipulacija(konekcioniString, komanda);
                        MessageBox.Show("The registration is complete. Have fun learning japanese.", "Registration completed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Add lecture progress entry into the database
                        DBManipulation dbmanipulation = DBManipulation.getInstance();
                        dbmanipulation.addLectureProgress(dbmanipulation.getUserId(u.Username));

                        GoToProfile();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Registration failed. Reason: " + ex.Message);
                }
            }
            else
            {
                aktivirajValidacijuSignUp();
                MessageBox.Show("Please correct the indicated mistakes.", "Information mistakes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (!cbUNMASKPASS.Checked)
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
            Boolean postojiUN = true;
            Boolean nijeIstiPASS = true;

            if (errorProvider1.GetError(tbCPASSUSERNAME).Equals("") && errorProvider1.GetError(tbCPASSEMAIL).Equals("") && errorProvider1.GetError(tbCPASSPASS).Equals("") && errorProvider1.GetError(tbCPASSCONFIRM).Equals("") && KorisnickeFunkcije.validirajSvePodatkeChangePassword(tbCPASSUSERNAME.Text, tbCPASSEMAIL.Text, tbCPASSPASS.Text, tbCPASSCONFIRM.Text))
            {
                try
                {
                    MySqlConnection konekcija = new MySqlConnection(konekcioniString);

                    MySqlCommand kom1 = new MySqlCommand();
                    kom1.CommandText = "SELECT * FROM draosbaza.users WHERE password=@pass;";
                    kom1.Parameters.AddWithValue("@pass", KorisnickeFunkcije.GetMd5Hash(tbCPASSPASS.Text));
                    kom1.Connection = konekcija;

                    konekcija.Open();

                    MySqlDataReader dr1 = kom1.ExecuteReader();

                    if (dr1.HasRows)
                    {
                        MessageBox.Show("The password provided is already in use. Please enter new password.", "Incorrect password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        nijeIstiPASS = false;
                    }

                    dr1.Close();
                    ((IDisposable)dr1).Dispose();

                    MySqlCommand kom2 = new MySqlCommand();
                    kom2.CommandText = "SELECT * FROM draosbaza.users WHERE username=@un";
                    kom2.Parameters.AddWithValue("@un", tbCPASSUSERNAME.Text);
                    kom2.Connection = konekcija;

                    MySqlDataReader dr2 = kom2.ExecuteReader();

                    if (!dr2.HasRows)
                    {
                        MessageBox.Show("The username you entered is not valid. Please enter new username.", "Incorrect user information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dr2.Close();
                        ((IDisposable)dr2).Dispose();
                        postojiUN = false;
                    }

                    if(postojiUN && nijeIstiPASS)
                    {
                        MySqlCommand komanda = new MySqlCommand();
                        komanda.CommandText = "UPDATE draosbaza.users SET password=@novipassword WHERE username=@username;";
                        komanda.Parameters.AddWithValue("@username", tbCPASSUSERNAME.Text);
                        komanda.Parameters.AddWithValue("@novipassword", KorisnickeFunkcije.GetMd5Hash(tbCPASSPASS.Text));

                        tbCPASSUSERNAME.Text = "";
                        tbCPASSEMAIL.Text = "";
                        tbCPASSPASS.Text = "";
                        tbCPASSCONFIRM.Text = "";

                        PristupBazi.Manipulacija(konekcioniString, komanda);
                        MessageBox.Show("Your password has been changed succesfully.", "Password changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Password change failed. Reason: " + ex.Message);
                }
            }
            else
            {
                aktivirajValidacijuChangePassword();
                MessageBox.Show("Please correct the indicated mistakes.", "Information mistakes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        // Event ulaska na tab gdje se prikazuju sve informacije o korisnikovom profilu
        #region PREGLED_PROFILA_KORISNIKA

        private void tpPROFILE_Enter(object sender, EventArgs e)
        {
            try
            {
                tbUSER.Text = "Welcome, " + aktivniKorisnik.Ime + " !";

                pbPROFILESL.Image = aktivniKorisnik.ProfilnaSlika;
                tbPROFILEFN.Text = aktivniKorisnik.Ime;
                tbPROFILELN.Text = aktivniKorisnik.Prezime;
                dtpPROFILEBD.Value = aktivniKorisnik.DatumRodenja;
                rtbPROFILEC.Text = aktivniKorisnik.Komentar;
                labelLVL.Text = "Lvl: " + Convert.ToString(aktivniKorisnik.MaxLekcija);

                if (aktivniKorisnik.NivoZnanja.Equals("Begginer"))
                    rbPROFILEB.Checked = true;
                else if (aktivniKorisnik.NivoZnanja.Equals("Intermediate"))
                    rbPROFILEI.Checked = true;
                else
                    rbPROFILEE.Checked = true;
            }

            catch (Exception)
            {
                tbUSER.Text = "You must login first !";
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

                    PristupBazi.Manipulacija(konekcioniString, komanda);

                    MessageBox.Show("Profile changes were succesfully made.", "Profile change succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    aktivniKorisnik = new User(tbPROFILEFN.Text, tbPROFILELN.Text, aktivniKorisnik.Username, aktivniKorisnik.Password, dtpBIRTHDATE.Value, nivoZnanja, rtbPROFILEC.Text, pbPROFILESL.Image);
                    tbUSER.Text = "Welcome, " + aktivniKorisnik.Ime + " !";

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
                    MessageBox.Show("Profile changes failed. Reason: " + ex.Message);
                }
            }
        }

        #endregion
        
        // Funkcije i eventi za izradu vokabular testa
        #region IZRADA_VOKABULAR_TESTA

        Int32 ucitajRandomPitanje(Int32 nivo) // Učita pitanje i vrati broj dugmeta sa tačnim odgovorom
        {
            MySqlConnection konekcija = new MySqlConnection(konekcioniString);
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
            MySqlConnection konekcija = new MySqlConnection(konekcioniString);
            MySqlCommand komanda = new MySqlCommand();

            PitanjeOdaberiSliku p = new PitanjeOdaberiSliku();
            Int32 tacanOdgovor = 0;

            try
            {
                komanda.CommandText = "SELECT * FROM draosbaza.slikapitanje WHERE nivo=@nivo ANd id=@id;";
                komanda.Parameters.AddWithValue("@nivo", nivo);
                Int32 rnd;

                if (nivo == 0)
                    rnd = new Random().Next(1, 10);
                else
                    rnd = new Random().Next(11, 20);

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
            for (int i = 0; i < 1000000; i++)
            {

            }

            label40.Text = "Vocabulary - Question #" + Convert.ToString(aktivniTest.TrenutnoPitanje + 1);
            label46.Text = "Vocabulary - Question #" + Convert.ToString(aktivniTest.TrenutnoPitanje + 1);

            if (aktivniTest.ZavrsenTest())
                TestResultsPage(Color.FromArgb(120, 200, 180), aktivniTest.Skor, "VOCAB");

            else
            {
                if (new Random().Next(1, 100) % 2 == 0)
                {
                    TextQuestion();
                    aktivniTest.TacanOdgovor = ucitajRandomPitanje(odabraniNivo);
                }
                else
                {
                    PictureQuestion();
                    aktivniTest.TacanOdgovor = ucitajRandomSlikaPitanje(odabraniNivo);
                }
            }

            lblQUESTIONINDICATOR.Text = aktivniTest.Skor + "/10";
            lblQUESTIONINDICATOR2.Text = aktivniTest.Skor + "/10";

            if (b)
            {
                ModifyProgressBarColor.SetState(((ProgressBar)tpVOCABQUESTSIMPLE.Controls.Find("progressBar" + Convert.ToString(aktivniTest.TrenutnoPitanje), true)[0]), 1);
                ModifyProgressBarColor.SetState(((ProgressBar)tpVOCABQUESTPIC.Controls.Find("progressBar" + Convert.ToString(aktivniTest.TrenutnoPitanje + 10), true)[0]), 1);
            }
            else
            {
                ModifyProgressBarColor.SetState(((ProgressBar)tpVOCABQUESTSIMPLE.Controls.Find("progressBar" + Convert.ToString(aktivniTest.TrenutnoPitanje), true)[0]), 2);
                ModifyProgressBarColor.SetState(((ProgressBar)tpVOCABQUESTPIC.Controls.Find("progressBar" + Convert.ToString(aktivniTest.TrenutnoPitanje + 10), true)[0]), 2);
            }

            obojiIzvjestaj(aktivniTest.TrenutnoPitanje, b);
            resetujBojeButtona();
        }

        void resetujBojeButtona()
        {
            buttANSWER1.ForeColor = Color.White;
            buttANSWER2.ForeColor = Color.White;
            buttANSWER3.ForeColor = Color.White;
            buttANSWER4.ForeColor = Color.White;

            buttPICANSWER1.ForeColor = Color.White;
            buttPICANSWER2.ForeColor = Color.White;
            buttPICANSWER3.ForeColor = Color.White;
            buttPICANSWER4.ForeColor = Color.White;

            buttGRAMMARANSWER1.ForeColor = Color.White;
            buttGRAMMARANSWER2.ForeColor = Color.White;
            buttGRAMMARANSWER3.ForeColor = Color.White;
            buttGRAMMARANSWER4.ForeColor = Color.White;

            buttKANJIANSWER1.ForeColor = Color.White;
            buttKANJIANSWER2.ForeColor = Color.White;
            buttKANJIANSWER3.ForeColor = Color.White;
            buttKANJIANSWER4.ForeColor = Color.White;
        }

        private void buttANSWER1_Click(object sender, EventArgs e)
        {
            buttANSWER1.ForeColor = Color.Red;
            ((Button)tpVOCABQUESTSIMPLE.Controls.Find("buttANSWER" + Convert.ToString(aktivniTest.TacanOdgovor), true)[0]).ForeColor = Color.Green;
            
            // Ovo je manualna zadrška određeno vrijeme da se ofarbaju tačan i netačan odgovor, threadovi useru
            this.Refresh();
            for (int i = 0; i < 300000000; i++)
            {
                Int32 br = 1; 
                br = br + 1;
            }

            refreshVocabPitanja(aktivniTest.Odgovori(1));
        }

        private void buttANSWER2_Click(object sender, EventArgs e)
        {
            buttANSWER2.ForeColor = Color.Red;
            ((Button)tpVOCABQUESTSIMPLE.Controls.Find("buttANSWER" + Convert.ToString(aktivniTest.TacanOdgovor), true)[0]).ForeColor = Color.Green;
            
            // Ovo je manualna zadrška određeno vrijeme da se ofarbaju tačan i netačan odgovor, threadovi useru
            this.Refresh();
            for (int i = 0; i < 300000000; i++)
            {
                Int32 br = 1;
                br = br + 1;
            }

            refreshVocabPitanja(aktivniTest.Odgovori(2));
        }

        private void buttANSWER3_Click(object sender, EventArgs e)
        {
            buttANSWER3.ForeColor = Color.Red;
            ((Button)tpVOCABQUESTSIMPLE.Controls.Find("buttANSWER" + Convert.ToString(aktivniTest.TacanOdgovor), true)[0]).ForeColor = Color.Green;

            // Ovo je manualna zadrška određeno vrijeme da se ofarbaju tačan i netačan odgovor, threadovi useru
            this.Refresh();
            for (int i = 0; i < 300000000; i++)
            {
                Int32 br = 1;
                br = br + 1;
            }

            refreshVocabPitanja(aktivniTest.Odgovori(3));
        }

        private void buttANSWER4_Click(object sender, EventArgs e)
        {
            buttANSWER4.ForeColor = Color.Red;
            ((Button)tpVOCABQUESTSIMPLE.Controls.Find("buttANSWER" + Convert.ToString(aktivniTest.TacanOdgovor), true)[0]).ForeColor = Color.Green;

            // Ovo je manualna zadrška određeno vrijeme da se ofarbaju tačan i netačan odgovor, threadovi useru
            this.Refresh();
            for (int i = 0; i < 300000000; i++)
            {
                Int32 br = 1;
                br = br + 1;
            }

            refreshVocabPitanja(aktivniTest.Odgovori(4));
        }

        private void buttPICANSWER1_Click(object sender, EventArgs e)
        {
            buttPICANSWER1.ForeColor = Color.Red;
            ((Button)tpVOCABQUESTPIC.Controls.Find("buttPICANSWER" + Convert.ToString(aktivniTest.TacanOdgovor), true)[0]).ForeColor = Color.Green;

            // Ovo je manualna zadrška određeno vrijeme da se ofarbaju tačan i netačan odgovor, threadovi useru
            this.Refresh();
            for (int i = 0; i < 300000000; i++)
            {
                Int32 br = 1;
                br = br + 1;
            }

            refreshVocabPitanja(aktivniTest.Odgovori(1));
        }

        private void buttPICANSWER2_Click(object sender, EventArgs e)
        {
            buttPICANSWER2.ForeColor = Color.Red;
            ((Button)tpVOCABQUESTPIC.Controls.Find("buttPICANSWER" + Convert.ToString(aktivniTest.TacanOdgovor), true)[0]).ForeColor = Color.Green;

            // Ovo je manualna zadrška određeno vrijeme da se ofarbaju tačan i netačan odgovor, threadovi useru
            this.Refresh();
            for (int i = 0; i < 300000000; i++)
            {
                Int32 br = 1;
                br = br + 1;
            }

            refreshVocabPitanja(aktivniTest.Odgovori(2));
        }

        private void buttPICANSWER3_Click(object sender, EventArgs e)
        {
            buttPICANSWER3.ForeColor = Color.Red;
            ((Button)tpVOCABQUESTPIC.Controls.Find("buttPICANSWER" + Convert.ToString(aktivniTest.TacanOdgovor), true)[0]).ForeColor = Color.Green;

            // Ovo je manualna zadrška određeno vrijeme da se ofarbaju tačan i netačan odgovor, threadovi useru
            this.Refresh();
            for (int i = 0; i < 300000000; i++)
            {
                Int32 br = 1;
                br = br + 1;
            }

            refreshVocabPitanja(aktivniTest.Odgovori(3));
        }

        private void buttPICANSWER4_Click(object sender, EventArgs e)
        {
            buttPICANSWER4.ForeColor = Color.Red;
            ((Button)tpVOCABQUESTPIC.Controls.Find("buttPICANSWER" + Convert.ToString(aktivniTest.TacanOdgovor), true)[0]).ForeColor = Color.Green;

            // Ovo je manualna zadrška određeno vrijeme da se ofarbaju tačan i netačan odgovor, threadovi useru
            this.Refresh();
            for (int i = 0; i < 300000000; i++)
            {
                Int32 br = 1;
                br = br + 1;
            }

            refreshVocabPitanja(aktivniTest.Odgovori(4));
        }

        #endregion

        // Funkcije i eventi za izradu grammar testa
        #region IZRADA_GRAMMAR_TESTA
        
        Int32 ucitajRandomGrammarPitanje(Int32 nivo) // Učita pitanje i vrati broj dugmeta sa tačnim odgovorom
        {
            MySqlConnection konekcija = new MySqlConnection(konekcioniString);
            MySqlCommand komanda = new MySqlCommand();

            PitanjeOdaberi p = new PitanjeOdaberi();
            Int32 tacanOdgovor = 0;

            try
            {
                komanda.CommandText = "SELECT * FROM draosbaza.grammarpitanje WHERE id=@id AND nivo=@nivo;";

                Int32 rnd;

                if (nivo == 0)
                    rnd = new Random().Next(1, 10);
                else
                    rnd = new Random().Next(11, 20);

                komanda.Parameters.AddWithValue("@id", rnd);
                komanda.Parameters.AddWithValue("@nivo", nivo);

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
                        DateTime kre = Convert.ToDateTime(dr["kreiran"]);

                        p = new PitanjeOdaberi(id, tekst, niv, odg1, odg2, odg3, todg);
                    }

                    dr.Close();
                    ((IDisposable)dr).Dispose();

                    tbGRAMMARQUESTIONTXT.Text = p.TekstPitanja;
                    tacanOdgovor = postaviRandomGrammarOdgovore(new Random().Next(1, 100), p);
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

        Int32 postaviRandomGrammarOdgovore(Int32 br, PitanjeOdaberi p)
        {
            if (br % 4 == 0)
            {
                buttGRAMMARANSWER1.Text = p.TacanOdgovor;
                buttGRAMMARANSWER2.Text = p.Odgovor1;
                buttGRAMMARANSWER3.Text = p.Odgovor2;
                buttGRAMMARANSWER4.Text = p.Odgovor3;

                return 1;
            }
            else if (br % 4 == 1)
            {
                buttGRAMMARANSWER1.Text = p.Odgovor1;
                buttGRAMMARANSWER2.Text = p.TacanOdgovor;
                buttGRAMMARANSWER3.Text = p.Odgovor3;
                buttGRAMMARANSWER4.Text = p.Odgovor2;

                return 2;
            }
            else if (br % 4 == 2)
            {
                buttGRAMMARANSWER1.Text = p.Odgovor2;
                buttGRAMMARANSWER2.Text = p.Odgovor3;
                buttGRAMMARANSWER3.Text = p.TacanOdgovor;
                buttGRAMMARANSWER4.Text = p.Odgovor1;

                return 3;
            }
            else
            {
                buttGRAMMARANSWER1.Text = p.Odgovor3;
                buttGRAMMARANSWER2.Text = p.Odgovor1;
                buttGRAMMARANSWER3.Text = p.Odgovor2;
                buttGRAMMARANSWER4.Text = p.TacanOdgovor;

                return 4;
            }
        }

        void refreshGrammarPitanja(Boolean b)
        {
            label52.Text = "Grammar - Question #" + Convert.ToString(aktivniTest.TrenutnoPitanje + 1);

            if (aktivniTest.ZavrsenTest())
                TestResultsPage(Color.FromArgb(80, 120, 100), aktivniTest.Skor, "GRAMMAR");

            else
            {
                GrammarQuestion();
                aktivniTest.TacanOdgovor = ucitajRandomGrammarPitanje(odabraniNivo);
            }

            labelGRAMMARSCORE.Text = aktivniTest.Skor + "/10";

            if (b)
                ModifyProgressBarColor.SetState(((ProgressBar)tpGRAMMARQUESTION.Controls.Find("progressBar" + Convert.ToString(aktivniTest.TrenutnoPitanje + 30), true)[0]), 1);
            else
                ModifyProgressBarColor.SetState(((ProgressBar)tpGRAMMARQUESTION.Controls.Find("progressBar" + Convert.ToString(aktivniTest.TrenutnoPitanje + 30), true)[0]), 2);

            obojiIzvjestaj(aktivniTest.TrenutnoPitanje, b);
            resetujBojeButtona();
        }

        private void buttGRAMMARANSWER1_Click(object sender, EventArgs e)
        {
            buttGRAMMARANSWER1.ForeColor = Color.Red;
            ((Button)tpGRAMMARQUESTION.Controls.Find("buttGRAMMARANSWER" + Convert.ToString(aktivniTest.TacanOdgovor), true)[0]).ForeColor = Color.Green;

            // Ovo je manualna zadrška određeno vrijeme da se ofarbaju tačan i netačan odgovor, threadovi useru
            this.Refresh();
            for (int i = 0; i < 300000000; i++)
            {
                Int32 br = 1;
                br = br + 1;
            }

            refreshGrammarPitanja(aktivniTest.Odgovori(1));
        }

        private void buttGRAMMARANSWER2_Click(object sender, EventArgs e)
        {
            buttGRAMMARANSWER2.ForeColor = Color.Red;
            ((Button)tpGRAMMARQUESTION.Controls.Find("buttGRAMMARANSWER" + Convert.ToString(aktivniTest.TacanOdgovor), true)[0]).ForeColor = Color.Green;

            // Ovo je manualna zadrška određeno vrijeme da se ofarbaju tačan i netačan odgovor, threadovi useru
            this.Refresh();
            for (int i = 0; i < 300000000; i++)
            {
                Int32 br = 1;
                br = br + 1;
            }

            refreshGrammarPitanja(aktivniTest.Odgovori(2));
        }

        private void buttGRAMMARANSWER3_Click(object sender, EventArgs e)
        {
            buttGRAMMARANSWER3.ForeColor = Color.Red;
            ((Button)tpGRAMMARQUESTION.Controls.Find("buttGRAMMARANSWER" + Convert.ToString(aktivniTest.TacanOdgovor), true)[0]).ForeColor = Color.Green;

            // Ovo je manualna zadrška određeno vrijeme da se ofarbaju tačan i netačan odgovor, threadovi useru
            this.Refresh();
            for (int i = 0; i < 300000000; i++)
            {
                Int32 br = 1;
                br = br + 1;
            }

            refreshGrammarPitanja(aktivniTest.Odgovori(3));
        }

        private void buttGRAMMARANSWER4_Click(object sender, EventArgs e)
        {
            buttGRAMMARANSWER4.ForeColor = Color.Red;
            ((Button)tpGRAMMARQUESTION.Controls.Find("buttGRAMMARANSWER" + Convert.ToString(aktivniTest.TacanOdgovor), true)[0]).ForeColor = Color.Green;

            // Ovo je manualna zadrška određeno vrijeme da se ofarbaju tačan i netačan odgovor, threadovi useru
            this.Refresh();
            for (int i = 0; i < 300000000; i++)
            {
                Int32 br = 1;
                br = br + 1;
            }

            refreshGrammarPitanja(aktivniTest.Odgovori(4));
        }

        #endregion

        // Funkcije i eventi za izradu writing testa
        #region IZRADA_WRITING_TESTA

        Int32 ucitajRandomKanjiPitanje(Int32 nivo, Int32 vrsta) // Učita pitanje i vrati broj dugmeta sa tačnim odgovorom
        {
            MySqlConnection konekcija = new MySqlConnection(konekcioniString);
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
                TestResultsPage(Color.FromArgb(255, 192, 128), aktivniTest.Skor, "WRITING");

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
                ModifyProgressBarColor.SetState(((ProgressBar)tpKANJIQUESTION.Controls.Find("progressBar" + Convert.ToString(aktivniTest.TrenutnoPitanje + 20), true)[0]), 1);
            else
                ModifyProgressBarColor.SetState(((ProgressBar)tpKANJIQUESTION.Controls.Find("progressBar" + Convert.ToString(aktivniTest.TrenutnoPitanje + 20), true)[0]), 2);

            obojiIzvjestaj(aktivniTest.TrenutnoPitanje, b);
            resetujBojeButtona();
        }

        private void buttKANJIANSWER1_Click(object sender, EventArgs e)
        {
            buttKANJIANSWER1.ForeColor = Color.Red;
            ((Button)tpKANJIQUESTION.Controls.Find("buttKANJIANSWER" + Convert.ToString(aktivniTest.TacanOdgovor), true)[0]).ForeColor = Color.Green;

            // Ovo je manualna zadrška određeno vrijeme da se ofarbaju tačan i netačan odgovor, threadovi useru
            this.Refresh();
            for (int i = 0; i < 300000000; i++)
            {
                Int32 br = 1;
                br = br + 1;
            }

            refreshKanjiPitanja(aktivniTest.Odgovori(1));
        }

        private void buttKANJIANSWER2_Click(object sender, EventArgs e)
        {
            buttKANJIANSWER2.ForeColor = Color.Red;
            ((Button)tpKANJIQUESTION.Controls.Find("buttKANJIANSWER" + Convert.ToString(aktivniTest.TacanOdgovor), true)[0]).ForeColor = Color.Green;

            // Ovo je manualna zadrška određeno vrijeme da se ofarbaju tačan i netačan odgovor, threadovi useru
            this.Refresh();
            for (int i = 0; i < 300000000; i++)
            {
                Int32 br = 1;
                br = br + 1;
            }

            refreshKanjiPitanja(aktivniTest.Odgovori(2));
        }

        private void buttKANJIANSWER3_Click(object sender, EventArgs e)
        {
            buttKANJIANSWER3.ForeColor = Color.Red;
            ((Button)tpKANJIQUESTION.Controls.Find("buttKANJIANSWER" + Convert.ToString(aktivniTest.TacanOdgovor), true)[0]).ForeColor = Color.Green;

            // Ovo je manualna zadrška određeno vrijeme da se ofarbaju tačan i netačan odgovor, threadovi useru
            this.Refresh();
            for (int i = 0; i < 300000000; i++)
            {
                Int32 br = 1;
                br = br + 1;
            }

            refreshKanjiPitanja(aktivniTest.Odgovori(3));
        }

        private void buttKANJIANSWER4_Click(object sender, EventArgs e)
        {
            buttKANJIANSWER4.ForeColor = Color.Red;
            ((Button)tpKANJIQUESTION.Controls.Find("buttKANJIANSWER" + Convert.ToString(aktivniTest.TacanOdgovor), true)[0]).ForeColor = Color.Green;

            // Ovo je manualna zadrška određeno vrijeme da se ofarbaju tačan i netačan odgovor, threadovi useru
            this.Refresh();
            for (int i = 0; i < 300000000; i++)
            {
                Int32 br = 1;
                br = br + 1;
            }

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

        private void button14_Click_2(object sender, EventArgs e)
        {
            GoToStats();
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

        private void button34_Click(object sender, EventArgs e)
        {
            GoToMainMenu();
        }

        private void button19_Click_1(object sender, EventArgs e)
        {
            GoToProfile();
        }

        private void button20_Click_1(object sender, EventArgs e)
        {
            GoToMainMenu();
        }

        private void buttDALJETESTREZ_Click(object sender, EventArgs e)
        {
            GoToVisualization(tpTESTRESULT.BackColor);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            GoToTestMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GoToMainMenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GoToHelp();
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

        private void button33_Click(object sender, EventArgs e)
        {
            odabraniNivo = 12;
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
            aktivniTest.Resetuj(n);
            pocistiTestStranice();

            if (aktivniTest.Tip.Equals("VOCAB"))
                aktivniTest.TacanOdgovor = ucitajRandomPitanje(n);
            else if (aktivniTest.Tip.Equals("KANJI"))
                aktivniTest.TacanOdgovor = ucitajRandomKanjiPitanje(n, 1);
            else
                aktivniTest.TacanOdgovor = ucitajRandomGrammarPitanje(n);
        }

        public void GoToMainMenu()
        {
            this.tabControl1.SelectedTab = tpPRVIMENU;
        }

        public void GoToTestMenu()
        {
            this.tabControl1.SelectedTab = tpTESTMENU;
        }

        public void GoToHelp()
        {
            this.tabControl1.SelectedTab = tpHELP;
        }

        public void GoToProfile()
        {
            this.tabControl1.SelectedTab = tpPROFILE;
        }

        public void GoToSignup()
        {
            this.tabControl1.SelectedTab = tpSIGNUP;
        }

        public void GoToStats()
        {
            this.tabControl1.SelectedTab = tpSTATS;
            pointGrafTestBodovi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void GoToVisualization(Color c)
        {
            chart1.Series.Clear();

            tpTESTVIZ.BackColor = c;
            foreach (Control cont in tpTESTVIZ.Controls)
                cont.BackColor = c;

            Series series1 = new Series
            {
                Name = "Sumarni Rezultat Testa",
                IsVisibleInLegend = true,
                ChartType = SeriesChartType.Doughnut
            };

            chart1.Series.Add(series1);
            series1.Points.Add(aktivniTest.Skor);
            series1.Points.Add(10 - aktivniTest.Skor);

            var p1 = series1.Points[0];
            p1.AxisLabel = Convert.ToString(aktivniTest.Skor);
            p1.LegendText = "Correct answer";
            p1.Color = Color.ForestGreen;

            var p2 = series1.Points[1];
            p2.AxisLabel = Convert.ToString(10 - aktivniTest.Skor);
            p2.LegendText = "Incorrect answer";
            p2.Color = Color.Firebrick;

            this.tabControl1.SelectedTab = tpTESTVIZ;
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
        }

        private void tpTESTLIST_Enter(object sender, EventArgs e)
        {
            zakljucajNivoe(aktivniKorisnik.MaxLekcija);
        }

        void zakljucajNivoe(Int32 nivo)
        {
            try
            {
                for (int i = 1; i < 13; i++)
                {
                    if(i <= aktivniKorisnik.MaxLekcija)
                        ((Button)tpTESTLIST.Controls.Find("buttonCH" + Convert.ToString(i), true)[0]).Enabled = true;
                    else
                        ((Button)tpTESTLIST.Controls.Find("buttonCH" + Convert.ToString(i), true)[0]).Enabled = false;
                }
            }

            catch (Exception) { }
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

        void TestResultsPage(Color c, Int32 sk, String tipTesta)
        {
            tpTESTRESULT.BackColor = c;

            foreach (Control cont in tpTESTRESULT.Controls)
                cont.BackColor = c;

            this.tabControl1.SelectedTab = tpTESTRESULT;

            if (sk < 5)
            {
                tbRESULTMESSAGE.Text = "You failed the test. Try again!";
                tbRESULTMESSAGE.ForeColor = Color.Red;
                tbRESULTMESSAGE2.Text = "You failed the test. Try again!";
                tbRESULTMESSAGE2.ForeColor = Color.Red;

                labelSCOREINDICATOR.Text = Convert.ToString(sk) + "/10";
                labelSCOREINDICATOR.ForeColor = Color.Red;
                
                labelSCOREINDICATOR2.Text = Convert.ToString(sk) + "/10";
                labelSCOREINDICATOR2.ForeColor = Color.Red;
            }

            else
            {
                tbRESULTMESSAGE.Text = "Congratulations, you passed the test!";
                tbRESULTMESSAGE.ForeColor = Color.Green;
                tbRESULTMESSAGE2.Text = "Congratulations, you passed the test!";
                tbRESULTMESSAGE2.ForeColor = Color.Green;

                labelSCOREINDICATOR.Text = Convert.ToString(sk) + "/10";
                labelSCOREINDICATOR.ForeColor = Color.Green;

                labelSCOREINDICATOR2.Text = Convert.ToString(sk) + "/10";
                labelSCOREINDICATOR2.ForeColor = Color.Green;

                if (tipTesta.Equals("VOCAB"))
                    aktivniKorisnik.Vocab = true;
                else if (tipTesta.Equals("GRAMMAR"))
                    aktivniKorisnik.Grammar = true;
                else
                    aktivniKorisnik.Writing = true;

                aktivniKorisnik.provjeriPrelazNaSljedeciNivo();
            }

            spremiTest();
        }

        void obojiIzvjestaj(Int32 i, Boolean b)
        {
            if (b)
            {
                ((TextBox)tpTESTRESULT.Controls.Find("tbRESULTSTATUSQ" + Convert.ToString(i), true)[0]).ForeColor = Color.Green;
                ((TextBox)tpTESTRESULT.Controls.Find("tbRESULTSTATUSQ" + Convert.ToString(i), true)[0]).Text = "Q" + Convert.ToString(i) + ": Correct";
            }
            else
            {
                ((TextBox)tpTESTRESULT.Controls.Find("tbRESULTSTATUSQ" + Convert.ToString(i), true)[0]).ForeColor = Color.Red;
                ((TextBox)tpTESTRESULT.Controls.Find("tbRESULTSTATUSQ" + Convert.ToString(i), true)[0]).Text = "Q" + Convert.ToString(i) + ": Incorrect";
            }
        }

        void pocistiTestStranice()
        {
            label40.Text = "Vocabulary - Question #1";
            label46.Text = "Vocabulary - Question #1";
            label52.Text = "Grammar - Question #1";
            label48.Text = "Writing - Question #1";

            lblQUESTIONINDICATOR.Text = "0/10";
            lblQUESTIONINDICATOR2.Text = "0/10";
            labelGRAMMARSCORE.Text = "0/10";
            labelKQINDICATOR.Text = "0/10";

            for (int i = 1; i < 11; i++)
            {
                ModifyProgressBarColor.SetState(((ProgressBar)tpVOCABQUESTSIMPLE.Controls.Find("progressBar" + Convert.ToString(i), true)[0]), 3);
                ModifyProgressBarColor.SetState(((ProgressBar)tpVOCABQUESTPIC.Controls.Find("progressBar" + Convert.ToString(i + 10), true)[0]), 3);
                ModifyProgressBarColor.SetState(((ProgressBar)tpKANJIQUESTION.Controls.Find("progressBar" + Convert.ToString(i + 20), true)[0]), 3);
                ModifyProgressBarColor.SetState(((ProgressBar)tpGRAMMARQUESTION.Controls.Find("progressBar" + Convert.ToString(i + 30), true)[0]), 3);
            }

        }

        #endregion

        // Event zatvaranja forme, gdje se snimaju izmjenjeni podaci o korisniku
        #region SNIMANJE_PROGRESA_KORISNIKA_I_PODATAKA_ZA_STATISTIKU

        private void GlavnaForma_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (aktivniKorisnik == null)
            {
            }
            else
            {
                try
                {
                    MySqlCommand komanda = new MySqlCommand();
                    komanda.CommandText = "UPDATE draosbaza.users SET maxlekcija=@max WHERE username=@username;";
                    komanda.Parameters.AddWithValue("@max", aktivniKorisnik.MaxLekcija);
                    komanda.Parameters.AddWithValue("@username", aktivniKorisnik.Username);

                    PristupBazi.Manipulacija(konekcioniString, komanda);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("User progress save failed. Reason: " + ex.Message);
                }
            }
        }

        public void spremiTest()
        {
            try
            {
                MySqlCommand komanda = new MySqlCommand();
                komanda.CommandText = "INSERT INTO draosbaza.uradenitestovi (user,tip,nivo,skor,datumizrade) VALUES (@user,@tip,@nivo,@skor,CURDATE());";

                komanda.Parameters.AddWithValue("@user", aktivniKorisnik.Username);
                komanda.Parameters.AddWithValue("@tip", aktivniTest.Tip);
                komanda.Parameters.AddWithValue("@nivo", aktivniTest.Nivo);
                komanda.Parameters.AddWithValue("@skor", aktivniTest.Skor);

                PristupBazi.Manipulacija(konekcioniString, komanda);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Test progress saving failed. Reason: " + ex.Message);
            }
        }

        public void pointGrafTestBodovi()
        {
            tbGRAPHDESC.Text = "This graph represents results from your earlier taken tests. The X axis represents the score, and Y axis represents the level of the test taken.";

            MySqlConnection konekcija = new MySqlConnection(konekcioniString);
            MySqlCommand komanda = new MySqlCommand();

            Series series1 = new Series
            {
                IsVisibleInLegend = true,
                ChartType = SeriesChartType.Bubble,
                MarkerStyle = MarkerStyle.Circle
            };

            chart2.ChartAreas["ChartArea1"].AxisX.Title = "Number of points";
            chart2.ChartAreas["ChartArea1"].AxisY.Title = "Level";
            chart2.Series.Add(series1);

            try
            {
                komanda.CommandText = "SELECT * FROM draosbaza.uradenitestovi WHERE user=@user;";
                komanda.Parameters.AddWithValue("@user", aktivniKorisnik.Username);
                komanda.Connection = konekcija;
                konekcija.Open();

                MySqlDataReader dr = komanda.ExecuteReader(CommandBehavior.SequentialAccess);

                if (dr.HasRows)
                {
                    Int32 i = 0;

                    while (dr.Read())
                    {
                        String tip = Convert.ToString(dr["tip"]);
                        Int32 niv = Convert.ToInt32(dr["nivo"]);
                        Int32 skor = Convert.ToInt32(dr["skor"]);

                        if (tip.Equals("VOCAB"))
                        {
                            series1.Points.Add(niv, 2).XValue = skor;
                            var p1 = series1.Points[i];
                            p1.Color = Color.FromArgb(120, 200, 180);
                        }
                        else if (tip.Equals("GRAMMAR"))
                        {
                            series1.Points.Add(niv, 2).XValue = skor;
                            var p2 = series1.Points[i];
                            p2.Color = Color.FromArgb(80, 120, 100);
                        }
                        else
                        {
                            series1.Points.Add(niv, 2).XValue = skor;
                            var p3 = series1.Points[i];
                            p3.Color = Color.FromArgb(255, 192, 128);
                        }

                        i++;
                    }

                    dr.Close();
                    ((IDisposable)dr).Dispose();
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

        public void lineGrafTestMjeseci()
        {
            tbGRAPHDESC.Text = "This graph represents results from your activity in the last month. The X axis represents the dates, and Y axis represents the number of test taken.";

            MySqlConnection konekcija = new MySqlConnection(konekcioniString);
            MySqlCommand komanda = new MySqlCommand();

            Series series1 = new Series
            {
                IsVisibleInLegend = true,
                ChartType = SeriesChartType.Line,
                Color = Color.Black,
                BorderWidth = 2,
                MarkerSize = 5,
                MarkerStyle = MarkerStyle.Circle,
                MarkerColor = Color.Red
            };

            chart2.ChartAreas["ChartArea1"].AxisX.Title = "Day of the month";
            chart2.ChartAreas["ChartArea1"].AxisY.Title = "Number of tests taken";
            chart2.Series.Add(series1);

            try
            {
                komanda.CommandText = "SELECT * FROM draosbaza.uradenitestovi WHERE user=@user;";
                komanda.Parameters.AddWithValue("@user", aktivniKorisnik.Username);
                komanda.Connection = konekcija;
                konekcija.Open();

                MySqlDataReader dr = komanda.ExecuteReader(CommandBehavior.SequentialAccess);

                if (dr.HasRows)
                {
                    Int32 i = 0;

                    int[] dani = Enumerable.Repeat(0, 32).ToArray();

                    while (dr.Read())
                    {
                        String tip = Convert.ToString(dr["tip"]);
                        Int32 niv = Convert.ToInt32(dr["nivo"]);
                        Int32 skor = Convert.ToInt32(dr["skor"]);
                        DateTime dat = Convert.ToDateTime(dr["datumizrade"]);

                        if (dat.Month == DateTime.Now.Month)
                            dani[dat.Day] = dani[dat.Day] + 1;
                    }

                    for (int j = 1; j < 32; j++)
                    {
                        series1.Points.Add(dani[j]).XValue = j;
                        var p1 = series1.Points[i];
                        p1.Color = Color.Red;
                    }
                    
                    dr.Close();
                    ((IDisposable)dr).Dispose();
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

        public void radarGrafProgresa()
        {
            tbGRAPHDESC.Text = "This graph represents your overall level in the three existing fields. Vocabulary, Grammar and Writing.";

            MySqlConnection konekcija = new MySqlConnection(konekcioniString);
            MySqlCommand komanda = new MySqlCommand();

            Series series1 = new Series
            {
                IsVisibleInLegend = true,
                ChartType = SeriesChartType.Radar,
                Color = Color.Black,
                BorderWidth = 2,
                MarkerColor = Color.Red
            };

            chart2.ChartAreas["ChartArea1"].AxisX.Title = "Progress";
            chart2.ChartAreas["ChartArea1"].AxisY.Title = "";
            chart2.Series.Add(series1);

            try
            {
                komanda.CommandText = "SELECT * FROM draosbaza.uradenitestovi WHERE user=@user;";
                komanda.Parameters.AddWithValue("@user", aktivniKorisnik.Username);
                komanda.Connection = konekcija;
                konekcija.Open();

                Int32 maxV = 0, maxG = 0, maxW = 0;

                MySqlDataReader dr = komanda.ExecuteReader(CommandBehavior.SequentialAccess);

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        String tip = Convert.ToString(dr["tip"]);
                        Int32 niv = Convert.ToInt32(dr["nivo"]);
                        Int32 skor = Convert.ToInt32(dr["skor"]);
                        DateTime dat = Convert.ToDateTime(dr["datumizrade"]);

                        if (tip.Equals("VOCAB") && niv > maxV)
                            maxV = niv;
                        if (tip.Equals("GRAMMAR") && niv > maxG)
                            maxG = niv;
                        if (tip.Equals("WRITING") && niv > maxW)
                            maxW = niv;
                    }

                    series1.Points.Add(maxV);
                    var p1 = series1.Points[0];
                    p1.Color = Color.FromArgb(120, 200, 180);

                    series1.Points.Add(maxG);
                    var p2 = series1.Points[1];
                    p2.Color = Color.FromArgb(80, 120, 100);

                    series1.Points.Add(maxW);
                    var p3 = series1.Points[2];
                    p3.Color = Color.FromArgb(255, 192, 128);

                    dr.Close();
                    ((IDisposable)dr).Dispose();
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

        private void button17_Click_1(object sender, EventArgs e)
        {
            if(button15.Text == "1/3") 
            {
                button15.Text = "2/3";
                chart2.Series.Clear();
                lineGrafTestMjeseci();
            }
            else if (button15.Text == "2/3")
            {
                button15.Text = "3/3";
                chart2.Series.Clear();
                radarGrafProgresa();
            }
            else
            {
                button15.Text = "1/3";
                chart2.Series.Clear();
                pointGrafTestBodovi();
            }
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            if (button15.Text == "1/3")
            {
                button15.Text = "3/3";
                chart2.Series.Clear();
                radarGrafProgresa();
            }
            else if (button15.Text == "2/3")
            {
                button15.Text = "1/3";
                chart2.Series.Clear();
                pointGrafTestBodovi();
            }
            else
            {
                button15.Text = "2/3";
                chart2.Series.Clear();
                lineGrafTestMjeseci();
            }
        }

        #endregion

        // Eventi za validaciju priliko signupa i promjene passworda
        #region VALIDACIJA_PODATAKA

        private void tbFIRSTNAME_Validating(object sender, CancelEventArgs e)
        {
            if (tbFIRSTNAME.Text.Length < 3)
            {
                errorProvider1.SetError(tbFIRSTNAME, "First name must contain at least 3 charcters!");
                tbFIRSTNAME.BackColor = Color.Salmon;
                tbFIRSTNAME.ForeColor = Color.White;
            }
            else
            {
                tbFIRSTNAME.BackColor = Color.White;
                tbFIRSTNAME.ForeColor = Color.FromArgb(51, 51, 51);
                errorProvider1.SetError(tbFIRSTNAME, "");
            }
        }

        private void tbLASTNAME_Validating(object sender, CancelEventArgs e)
        {
            if (tbLASTNAME.Text.Length < 3)
            {
                errorProvider1.SetError(tbLASTNAME, "Last name must contain at least 3 charcters!");
                tbLASTNAME.BackColor = Color.Salmon;
                tbLASTNAME.ForeColor = Color.White;
            }
            else
            {
                tbLASTNAME.BackColor = Color.White;
                tbLASTNAME.ForeColor = Color.FromArgb(51,51,51);
                errorProvider1.SetError(tbLASTNAME, "");
            }
        }

        private void tbNEWUSERNAME_Validating(object sender, CancelEventArgs e)
        {
            if (tbNEWUSERNAME.Text.Length < 5)
            {
                errorProvider1.SetError(tbNEWUSERNAME, "Username must contain at least 5 charcters!");
                tbNEWUSERNAME.BackColor = Color.Salmon;
                tbNEWUSERNAME.ForeColor = Color.White;
            }
            else
            {
                tbNEWUSERNAME.BackColor = Color.White;
                tbNEWUSERNAME.ForeColor = Color.FromArgb(51, 51, 51);
                errorProvider1.SetError(tbNEWUSERNAME, "");
            }
        }

        private void tbNEWPASSWORD_Validating(object sender, CancelEventArgs e)
        {
            if (!KorisnickeFunkcije.validirajPassword(tbNEWPASSWORD.Text))
            {
                errorProvider1.SetError(tbNEWPASSWORD, "A valid password must contain 8-15 charcters, have at least one upper case letter and have at least one number.");
                tbNEWPASSWORD.BackColor = Color.Salmon;
                tbNEWPASSWORD.ForeColor = Color.White;
            }
            else
            {
                tbNEWPASSWORD.BackColor = Color.White;
                tbNEWPASSWORD.ForeColor = Color.FromArgb(51, 51, 51);
                errorProvider1.SetError(tbNEWPASSWORD, "");
            }
        }

        public void aktivirajValidacijuSignUp()
        {
            if (tbFIRSTNAME.Text.Length < 3)
            {
                errorProvider1.SetError(tbFIRSTNAME, "First name must contain at least 3 charcters!");
                tbFIRSTNAME.BackColor = Color.Salmon;
                tbFIRSTNAME.ForeColor = Color.White;
            }

            if (tbLASTNAME.Text.Length < 3)
            {
                errorProvider1.SetError(tbLASTNAME, "Last name must contain at least 3 charcters!");
                tbLASTNAME.BackColor = Color.Salmon;
                tbLASTNAME.ForeColor = Color.White;
            }

            if (tbNEWUSERNAME.Text.Length < 5)
            {
                errorProvider1.SetError(tbNEWUSERNAME, "Username must contain at least 5 charcters!");
                tbNEWUSERNAME.BackColor = Color.Salmon;
                tbNEWUSERNAME.ForeColor = Color.White;
            }

            if (!KorisnickeFunkcije.validirajPassword(tbNEWPASSWORD.Text))
            {
                errorProvider1.SetError(tbNEWPASSWORD, "A valid password must contain 8-15 charcters, have at least one upper case letter and have at least one number.");
                tbNEWPASSWORD.BackColor = Color.Salmon;
                tbNEWPASSWORD.ForeColor = Color.White;
            }
        }

        private void tbCPASSUSERNAME_Validating(object sender, CancelEventArgs e)
        {
            if (tbCPASSUSERNAME.Text.Length < 5)
            {
                errorProvider1.SetError(tbCPASSUSERNAME, "Username must contain at least 5 charcters.");
                tbCPASSUSERNAME.BackColor = Color.Salmon;
                tbCPASSUSERNAME.ForeColor = Color.White;
            }
            else
            {
                tbCPASSUSERNAME.BackColor = Color.White;
                tbCPASSUSERNAME.ForeColor = Color.FromArgb(51, 51, 51);
                errorProvider1.SetError(tbCPASSUSERNAME, "");
            }
        }

        private void tbCPASSEMAIL_Validating(object sender, CancelEventArgs e)
        {
            if (!KorisnickeFunkcije.validirajEmail(tbCPASSEMAIL.Text))
            {
                errorProvider1.SetError(tbCPASSEMAIL, "Email must be in correct format.");
                tbCPASSEMAIL.BackColor = Color.Salmon;
                tbCPASSEMAIL.ForeColor = Color.White;
            }
            else
            {
                tbCPASSEMAIL.BackColor = Color.White;
                tbCPASSEMAIL.ForeColor = Color.FromArgb(51, 51, 51);
                errorProvider1.SetError(tbCPASSEMAIL, "");
            }
        }

        private void tbCPASSPASS_Validating(object sender, CancelEventArgs e)
        {
            if (!KorisnickeFunkcije.validirajPassword(tbCPASSPASS.Text))
            {
                errorProvider1.SetError(tbCPASSPASS, "A valid password must contain 8-15 charcters, have at least one upper case letter and have at least one number.");
                tbCPASSPASS.BackColor = Color.Salmon;
                tbCPASSPASS.ForeColor = Color.White;
            }
            else
            {
                tbCPASSPASS.BackColor = Color.White;
                tbCPASSPASS.ForeColor = Color.FromArgb(51, 51, 51);
                errorProvider1.SetError(tbCPASSPASS, "");
            }
        }

        private void tbCPASSCONFIRM_Validating(object sender, CancelEventArgs e)
        {
            if (!KorisnickeFunkcije.validirajPassword(tbCPASSCONFIRM.Text))
            {
                errorProvider1.SetError(tbCPASSCONFIRM, "A valid password must contain 8-15 charcters, have at least one upper case letter and have at least one number.");
                tbCPASSCONFIRM.BackColor = Color.Salmon;
                tbCPASSCONFIRM.ForeColor = Color.White;
            }
            else if (!tbCPASSPASS.Text.Equals(tbCPASSCONFIRM.Text))
            {
                errorProvider1.SetError(tbCPASSCONFIRM, "Passwords must be the same.");
                tbCPASSCONFIRM.BackColor = Color.Salmon;
                tbCPASSCONFIRM.ForeColor = Color.White;
            }
            else
            {
                tbCPASSCONFIRM.BackColor = Color.White;
                tbCPASSCONFIRM.ForeColor = Color.FromArgb(51, 51, 51);
                errorProvider1.SetError(tbCPASSCONFIRM, "");
            }
        }

        public void aktivirajValidacijuChangePassword()
        {
            if (tbNEWUSERNAME.Text.Length < 5)
            {
                errorProvider1.SetError(tbNEWUSERNAME, "Username must contain at least 5 charcters.");
                tbNEWUSERNAME.BackColor = Color.Salmon;
                tbNEWUSERNAME.ForeColor = Color.White;
            }

            if (KorisnickeFunkcije.validirajEmail(tbCPASSEMAIL.Text))
            {
                errorProvider1.SetError(tbLASTNAME, "Email must be in correct format.");
                tbLASTNAME.BackColor = Color.Salmon;
                tbLASTNAME.ForeColor = Color.White;
            }

            if (!KorisnickeFunkcije.validirajPassword(tbCPASSPASS.Text))
            {
                errorProvider1.SetError(tbNEWUSERNAME, "A valid password must contain 8-15 charcters, have at least one upper case letter and have at least one number.");
                tbNEWUSERNAME.BackColor = Color.Salmon;
                tbNEWUSERNAME.ForeColor = Color.White;
            }

            if (!KorisnickeFunkcije.validirajPassword(tbCPASSCONFIRM.Text))
            {
                errorProvider1.SetError(tbCPASSCONFIRM, "A valid password must contain 8-15 charcters, have at least one upper case letter and have at least one number.");
                tbCPASSCONFIRM.BackColor = Color.Salmon;
                tbCPASSCONFIRM.ForeColor = Color.White;
            }

            if (!tbCPASSPASS.Text.Equals(tbCPASSCONFIRM.Text))
            {
                errorProvider1.SetError(tbCPASSCONFIRM, "Passwords must be the same.");
                tbCPASSCONFIRM.BackColor = Color.Salmon;
                tbCPASSCONFIRM.ForeColor = Color.White;
            }
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
                this.mainPanel.Controls.Add(new LecturesList(mainPanel, aktivniKorisnik));
            }
        }

        #endregion
    }
}
