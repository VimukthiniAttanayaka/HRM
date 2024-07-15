using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace HRM_DAL.Utility
{
    public static class Misc
    {
        public static string enCrypt(string Source)
        {
            string original, encrypted, SecretWord;
            TripleDESCryptoServiceProvider des;
            MD5CryptoServiceProvider hashmd5;
            byte[] pwdhash, buff;


            SecretWord = "SysTechGoGoGo";
            original = Source;

            hashmd5 = new MD5CryptoServiceProvider();
            pwdhash = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(SecretWord));
            hashmd5 = null;

            des = new TripleDESCryptoServiceProvider();

            des.Key = pwdhash;
            des.Mode = CipherMode.ECB;
            buff = ASCIIEncoding.ASCII.GetBytes(original);

            encrypted = Convert.ToBase64String(
                des.CreateEncryptor().TransformFinalBlock(buff, 0, buff.Length)
            );
            des = null;
            return encrypted;
        }


        //Decrypt the String
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



        public static string listToXml<T>(List<T> objList)
        {
            var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            emptyNamepsaces.Add("", "");
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>), new XmlRootAttribute(typeof(T).Name));
            var stringwriter = new System.IO.StringWriter();
            serializer.Serialize(stringwriter, objList, emptyNamepsaces);
            return stringwriter.ToString();
        }

        public static T Deserialize<T>(string input) where T : class
        {
            using (XmlReader reader = XmlReader.Create(new StringReader(input)))
            {
                reader.MoveToContent();
                reader.ReadToDescendant(typeof(T).Name);
                var serializer = new XmlSerializer(typeof(T));
                var list = (T)serializer.Deserialize(reader);
                return list;
            }

            //System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));

            //using (StringReader sr = new StringReader(input))
            //{
            //    return (T)ser.Deserialize(sr);
            //}


        }

        public static List<T> DeserializeXML<T>(string input, string rootElementName) where T : class
        {
            using (XmlReader reader = XmlReader.Create(new StringReader(input)))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>), new XmlRootAttribute(rootElementName));

                StringReader stringReader = new StringReader(input);
                List<T> list = (List<T>)serializer.Deserialize(stringReader);
                return list;
            }
        }
    }
}
