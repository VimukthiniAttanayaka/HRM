using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_Creator_WinApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string encryptedPW = "";
            string encryptedpin = "";
            decimal Salt = 0;
            string NotEncryptedPassword = "";
            string PasswordSalt = "";

            NotEncryptedPassword = textBox1.Text;
            PasswordSalt = textBox2.Text;


            String EncryptedPassword = ValidatePassword(NotEncryptedPassword, "", PasswordSalt);
            textBox3.Text = EncryptedPassword;
        }

        public String ValidatePassword(string KeyInPassword, string DBPassword, string PasswordSalt)
        {
            string PasswordPeper = deCrypt("bKug8KjH+RT8mHURSPX2uQ==");

            string PasswordToEncrypt = PasswordPeper + "" + KeyInPassword + "" + PasswordSalt;

            string EncryptedPassword = sha256(PasswordToEncrypt);
          
            return EncryptedPassword;
        }

        public static string deCrypt(string Source)
        {
            string decrypted, SecretWord;
            TripleDESCryptoServiceProvider des;
            MD5CryptoServiceProvider hashmd5;
            byte[] pwdhash, buff;

            SecretWord = "SysTechGoGoGo";
            hashmd5 = new MD5CryptoServiceProvider();
            pwdhash = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(SecretWord));
            hashmd5 = null;

            des = new TripleDESCryptoServiceProvider();
            des.Key = pwdhash;
            des.Mode = CipherMode.ECB;

            buff = Convert.FromBase64String(Source);
            decrypted = ASCIIEncoding.ASCII.GetString(
                des.CreateDecryptor().TransformFinalBlock(buff, 0, buff.Length)
                );
            des = null;
            return decrypted;
        }

        static string sha256(string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    }
}
