//using Newtonsoft.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace utility_handler.Utility
{
    public class Misc
    {
        public static string FormatIso8601(DateTimeOffset dto)
        {
            string format = dto.Offset == TimeSpan.Zero
                ? "yyyy-MM-ddTHH:mm:ss.fffZ"
                : "yyyy-MM-ddTHH:mm:ss.fffzzz";

            return dto.ToString(format, System.Globalization.CultureInfo.InvariantCulture);
        }

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

        public static string SerializeJason<T>(List<T> objList) where T : class
        {
            string output = JsonConvert.SerializeObject(objList);
            //Console.WriteLine(output);
            //Console.ReadLine();
            return output;
        }
        public static List<T> DeserializeJason<T>(string output) where T : class
        {
            List<T> deserializedProduct = JsonConvert.DeserializeObject<List<T>>(output);
            return deserializedProduct;
        }
        public static T DeserializeJasonObj<T>(string output) where T : class
        {
            T deserializedProduct = JsonConvert.DeserializeObject<T>(output);
            return deserializedProduct;
        }

        public static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
