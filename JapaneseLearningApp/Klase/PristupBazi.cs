using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapaneseLearningApp.Klase
{
    public class PristupBazi
    {
        //Prima parametrizovanu komandu, vraća broj redova koji su izmjenjeni
        public static Int32 Manipulacija(String konekcioniString, MySqlCommand msc)
        {
            Int32 affectedRows = 0;
            MySqlConnection konekcija = new MySqlConnection(konekcioniString);

            try
            {
                msc.Connection = konekcija;
                konekcija.Open();
                affectedRows = msc.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                konekcija.Close();
            }

            return affectedRows;
        }
    }
}
