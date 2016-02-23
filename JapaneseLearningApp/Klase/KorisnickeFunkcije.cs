using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JapaneseLearningApp.Klase
{
    public class KorisnickeFunkcije
    {
        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            ms.Position = 0;
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static byte[] ImageToByteArray(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
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

        public static Boolean validirajPassword(String pass)
        {
            return Regex.IsMatch(pass, "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,15}$");
        }

        public static Boolean validirajEmail(String mail)
        {
            return Regex.IsMatch(mail,
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }

        public static Boolean validirajSvePodatkeSignUp(String fn, String ln, String un, String pass)
        {
            if (fn.Length >= 3 && ln.Length >= 3 && un.Length >= 5 && validirajPassword(pass))
                return true;
            else
                return false;
        }

        public static Boolean validirajSvePodatkeChangePassword(String un, String mail, String pass, String passc)
        {
            if (un.Length >= 5 && validirajEmail(mail) && validirajPassword(pass) && validirajPassword(passc) && pass.Equals(passc))
                return true;
            else
                return false;
        }
    }
}
