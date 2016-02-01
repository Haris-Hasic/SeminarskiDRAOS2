using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JapaneseLearningApp.Klase;
using MySql.Data.MySqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Data.SqlClient;
using JapaneseLearningApp.Properties;

namespace JapaneseLearningApp
{
    public partial class GlavnaForma : Form
    {
        User aktivniKorisnik;

        public GlavnaForma()
        {
            InitializeComponent();
        }

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

        private void btnLOGIN_Click(object sender, EventArgs e)
        {
            MySqlConnection konekcija = new MySqlConnection("server=localhost;User Id=root;database=draosbaza");
            MySqlCommand komanda = new MySqlCommand();

            try
            {
                komanda.CommandText = "SELECT * FROM draosbaza.users WHERE username=@username AND password=@password;";
                komanda.Parameters.AddWithValue("@username", tbUSERNAME.Text);
                komanda.Parameters.AddWithValue("@password", GetMd5Hash(tbPASSWORD.Text));
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

                        // Ne znam očitati sliku :(
                        Image sl = Resources.ProfilePicPlaceHolder;

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

        private void llblFORGOTPASS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.tabControl1.SelectedTab = tpFORGOTPASS;
        }

        private void llblSIGNUP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.tabControl1.SelectedTab = tpSIGNUP;
        }

        private void btnUPLOAD_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();

            if (o.ShowDialog() == DialogResult.OK)
                pbSLIKA.Image = Image.FromFile(o.FileName);
        }

        private void btnSIGNUP_Click(object sender, EventArgs e)
        {
            String nivoZnanja;

            if (radioBEG.Checked)
                nivoZnanja = "Begginer";
            else if (radioINTER.Checked)
                nivoZnanja = "Intermediate";
            else
                nivoZnanja = "Expert";

            User u = new User(tbFIRSTNAME.Text, tbLASTNAME.Text, tbNEWUSERNAME.Text, GetMd5Hash(tbPASSWORD.Text), dtpBIRTHDATE.Value, nivoZnanja, rtbCOMMENT.Text, pbSLIKA.Image);
            aktivniKorisnik = u;

            MySqlCommand komanda = new MySqlCommand();
            komanda.CommandText = "INSERT INTO draosbaza.users(ime,prezime,username,password,datumrodenja,nivoznanja,komentar,slika,kreiran) VALUES (@ime,@prezime,@username,@password,@datum,@znanje,@komentar,@slika,CURDATE());";
            komanda.Parameters.AddWithValue("@ime", tbFIRSTNAME.Text);
            komanda.Parameters.AddWithValue("@prezime", tbLASTNAME.Text);
            komanda.Parameters.AddWithValue("@username", tbNEWUSERNAME.Text);
            komanda.Parameters.AddWithValue("@password", GetMd5Hash(tbNEWPASSWORD.Text));
            komanda.Parameters.AddWithValue("@datum", dtpBIRTHDATE.Value);
            komanda.Parameters.AddWithValue("@znanje", nivoZnanja);
            komanda.Parameters.AddWithValue("@komentar", rtbCOMMENT.Text);
            komanda.Parameters.AddWithValue("@slika", pbSLIKA.Image);

            manipulacija(komanda);

            this.tabControl1.SelectedTab = tpPROFILE;
        }

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
            if (!tbCPASSPASS.Text.Equals(tbCPASSCONFIRM.Text))
            {
                MessageBox.Show("Password and Confirm password fields must be the same!");
            }

            else
            {
                MySqlCommand komanda = new MySqlCommand();
                komanda.CommandText = "UPDATE draosbaza.users SET password=@novipassword WHERE username=@username;";
                komanda.Parameters.AddWithValue("@username", tbCPASSUSERNAME.Text);
                komanda.Parameters.AddWithValue("@novipassword", GetMd5Hash(tbCPASSPASS.Text));
                manipulacija(komanda);
            }
        }

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
                komanda.Parameters.AddWithValue("@slika", pbPROFILESL.Image);
                komanda.Parameters.AddWithValue("@username", aktivniKorisnik.Username);

                manipulacija(komanda);

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
        }

        /* ####################################################################################### */
        /* NAVIGACIJA KROZ APLIKACIJU */
        /* ####################################################################################### */

        private void button12_Click(object sender, EventArgs e)
        {
            menu();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            menu();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            profil();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            profil();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            logout();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            logout();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            logout();
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            logout();
        }

        /* ####################################################################################### */
        /* KORISNIČKI NAPISANE FUNKCIJE */
        /* ####################################################################################### */

        public void menu()
        {
            this.tabControl1.SelectedTab = tpPRVIMENU;
        }

        public void profil()
        {
            this.tabControl1.SelectedTab = tpPROFILE;
        }

        public void logout()
        {
            this.tabControl1.SelectedTab = tpLOGIN;
        }

        public static string GetMd5Hash(string input)
        {
            MD5 md5Hash = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        /* ####################################################################################### */
        /* RAD SA BAZOM */
        /* ####################################################################################### */

        public void manipulacija(MySqlCommand msc)
        {
            MySqlConnection konekcija = new MySqlConnection("server=localhost;User Id=root;database=draosbaza");

            try
            {
                msc.Connection = konekcija;
                konekcija.Open();
                int aff = msc.ExecuteNonQuery();
                MessageBox.Show("Changes were succesfully made. " + aff + " rows were affected.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Changes failed. Reason: " + ex.Message);
            }
            finally
            {
                konekcija.Close();
            }
        }

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

    }
}
