using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace JapaneseLearningApp.Klase
{
    class DBManipulation
    {
        private static DBManipulation instance = null;
        private MySqlConnection connection;

        private DBManipulation() { }

        public static DBManipulation getInstance()
        {
            return (instance == null) ? instance = new DBManipulation() : instance;
        }

        public void connect()
        {
            connection = new MySqlConnection("server=localhost;User Id=root;database=draosbaza");
            connection.Open();
        }

        public void disconnect()
        {
            if (connection.State != System.Data.ConnectionState.Closed)
                connection.Close();

            connection = null;
        }

        public int getUserId(string username)
        {
            connect();

            string sql = "SELECT id FROM users WHERE username = @username";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@username", username);

            object result = cmd.ExecuteScalar();
            if (result == null)
            {
                disconnect();
                throw new Exception("No user with the username: " + username);
            }

            disconnect();

            return Convert.ToInt32(result);
        }

        public void addLectureProgress(int user)
        {
            connect();

            string sql = "INSERT INTO lectureprogress(user) VALUES (@user)";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.ExecuteNonQuery();

            disconnect();
        }

        public int getLectureProgress(int user)
        {
            connect();

            string sql = "SELECT story, vocabulary, grammar FROM lectureprogress WHERE user = @user";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@user", user);

            MySqlDataReader rdr = cmd.ExecuteReader();
            int progress = -1;
            while (rdr.Read())
            {
                int[] values = { Convert.ToInt32(rdr[0]), Convert.ToInt32(rdr[1]), Convert.ToInt32(rdr[2]) };
                progress = values.Min();
            }

            disconnect();

            return progress;
        }

        public int getStoryProgress(int user)
        {
            connect();

            string sql = "SELECT story FROM lectureprogress WHERE user = @user";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@user", user);

            object result = cmd.ExecuteScalar();
            if (result == null)
            {
                disconnect();
                throw new Exception("No user with the id: " + user);
            }

            disconnect();

            return Convert.ToInt32(result);
        }

        public void setStoryProgress(int user, int progress)
        {
            connect();

            string sql = "UPDATE lectureprogress SET story = @story WHERE user = @user;";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@story", progress);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.ExecuteNonQuery();

            disconnect();
        }

        public int getVocabularyProgress(int user)
        {
            connect();

            string sql = "SELECT vocabulary FROM lectureprogress WHERE user = @user";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@user", user);

            object result = cmd.ExecuteScalar();
            if (result == null)
            {
                disconnect();
                throw new Exception("No user with the id: " + user);
            }

            disconnect();

            return Convert.ToInt32(result);
        }

        public void setVocabularyProgress(int user, int progress)
        {
            connect();

            string sql = "UPDATE lectureprogress SET vocabulary = @vocabulary WHERE user = @user;";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@vocabulary", progress);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.ExecuteNonQuery();

            disconnect();
        }

        public int getGrammarProgress(int user)
        {
            connect();

            string sql = "SELECT grammar FROM lectureprogress WHERE user = @user";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@user", user);

            object result = cmd.ExecuteScalar();
            if (result == null)
            {
                disconnect();
                throw new Exception("No user with the id: " + user);
            }

            disconnect();

            return Convert.ToInt32(result);
        }

        public void setGrammarProgress(int user, int progress)
        {
            connect();

            string sql = "UPDATE lectureprogress SET grammar = @grammar WHERE user = @user;";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@grammar", progress);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.ExecuteNonQuery();

            disconnect();
        }
    }
}
