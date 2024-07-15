using HRM_DAL.Data;
using HRM_DAL.Models;
using HRM_DAL.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRM_DAL.Utility
{
    public class PasswordRelated
    {
        public PasswordRelated()
        {
        }

        public static string CreateRandomPassword()
        {
            List<ReturSystemPMModelHead> tem = SystemParameter_Data.get_system_parameter_single(
                                 new GetSystemPMSingleModel()
                                 { SP_ID = "PWD_MinLength" });

            int passwordminlength = 8;
            if (tem != null && tem.Count > 0 && tem[0].SystemPM != null && tem[0].SystemPM.Count > 0)
            {
                int.TryParse(tem[0].SystemPM[0].SP_Value, out passwordminlength);
            }

            List<ReturSystemPMModelHead> temMax = SystemParameter_Data.get_system_parameter_single(
                               new GetSystemPMSingleModel()
                               { SP_ID = "PWD_MaxLength" });

            int passwordmaxlength = 8;
            if (temMax != null && temMax.Count > 0 && temMax[0].SystemPM != null && temMax[0].SystemPM.Count > 0)
            {
                int.TryParse(temMax[0].SystemPM[0].SP_Value, out passwordmaxlength);
            }

            if (passwordminlength > passwordmaxlength)
            {
                throw new ArgumentException("The minimumLength is bigger than the maximum length.",
                    "minimumLengthPassword");
            }

            var generator = new PasswordGenerator(minimumLengthPassword: passwordminlength, maximumLengthPassword: passwordmaxlength);
            string password = generator.Generate();
            return password;

            //Membership.GeneratePassword(25, 10);

            //string _allowedChars = "0123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ@#$&%";
            //Random randNum = new Random();
            //char[] chars = new char[passwordminlength];
            //int allowedCharCount = _allowedChars.Length;
            //for (int i = 0; i < passwordminlength; i++)
            //{
            //    chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            //}
            //return new string(chars);
        }

        public static string CreateRandomPIN()
        {
            List<ReturSystemPMModelHead> tem = SystemParameter_Data.get_system_parameter_single(
                                    new GetSystemPMSingleModel()
                                    { SP_ID = "PIN_MinLength" });

            int passwordminlength = 8;
            if (tem != null && tem.Count > 0 && tem[0].SystemPM != null && tem[0].SystemPM.Count > 0)
            {
                int.TryParse(tem[0].SystemPM[0].SP_Value, out passwordminlength);
            }

            List<ReturSystemPMModelHead> temMax = SystemParameter_Data.get_system_parameter_single(
                                 new GetSystemPMSingleModel()
                                 { SP_ID = "PIN_MaxLength" });

            int passwordmaxlength = 8;
            if (temMax != null && temMax.Count > 0 && temMax[0].SystemPM != null && temMax[0].SystemPM.Count > 0)
            {
                int.TryParse(tem[0].SystemPM[0].SP_Value, out passwordmaxlength);
            }

            Random rm = new Random();
            int minNumber = 10000000;
            int maxNumber = 99999999;

            string[] arrMinlength = new string[passwordminlength];
            string[] arrMaxlength = new string[passwordmaxlength];

            arrMinlength[0] = "1";
            arrMaxlength[0] = "9";
            for (int i = 1; i < passwordminlength; i++)
            {
                arrMinlength[i] = "0";
                arrMaxlength[i] = "9";
            }

            string strMinlength = string.Join("", arrMinlength);// arrMinlength.ToString();
            string strMaxlength = string.Join("", arrMaxlength);//arrMaxlength.ToString();
            minNumber = Convert.ToInt32(strMinlength);
            maxNumber = Convert.ToInt32(strMaxlength);

            return rm.Next(minNumber, maxNumber).ToString();
            //string _allowedChars = "0123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ@#$&%";
            //Random randNum = new Random();
            //char[] chars = new char[passwordminlength];
            //int allowedCharCount = _allowedChars.Length;
            //for (int i = 0; i < passwordminlength; i++)
            //{
            //    chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            //}
            //return new string(chars);
        }

        public static void CreateEncryptedPassword(string NotEncryptedPassword, ref string EncryptedPassword, ref decimal PasswordSault)
        {
            string PasswordPeper = ConfigCaller.PasswordPepper;
            Random rm = new Random();
            int minNumber = 10000;
            int maxNumber = 99999;
            PasswordSault = rm.Next(minNumber, maxNumber);

            string PasswordToEncrypt = PasswordPeper + "" + NotEncryptedPassword + "" + PasswordSault.ToString();

            EncryptedPassword = sha256(PasswordToEncrypt);
        }

        public static bool ValidatePassword(string KeyInPassword, string DBPassword, string PasswordSalt)
        {
            string PasswordPeper = ConfigCaller.PasswordPepper;

            string PasswordToEncrypt = PasswordPeper + "" + KeyInPassword + "" + PasswordSalt;

            string EncryptedPassword = sha256(PasswordToEncrypt);

            bool IsValid = false;

            if (DBPassword == EncryptedPassword)
            {
                IsValid = true;
            }
            return IsValid;
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
    }
}