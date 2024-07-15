using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using utility_handler.Utility;

namespace utility_handler.Data
{
    public static class BaseClassDBCallerData
    {
        static IConfigurationRoot config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();

        private static string _connectionString;
        //static String ConStuff = "";
        public static string ConStrignName
        {
            get
            {

                try
                {
                    var ConStrignName = config["appSettings:ConStrignName"];
                    return ConStrignName;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string inquiryEmail
        {
            get
            {

                try
                {
                    var inquiryEmail = config["appSettings:inquiryEmail"];
                    return inquiryEmail;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string inquirySubject
        {
            get
            {

                try
                {
                    var inquirySubject = config["appSettings:inquirySubject"];
                    return inquirySubject;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string inquiryCc
        {
            get
            {

                try
                {
                    var inquiryCc = config["appSettings:inquiryCc"];
                    return inquiryCc;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string UserPwSubject
        {
            get
            {

                try
                {
                    var UserPwSubject = config["appSettings:UserPwSubject"];
                    return UserPwSubject;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string ResetPwSubject
        {
            get
            {

                try
                {
                    var ResetPwSubject = config["appSettings:ResetPwSubject"];
                    return ResetPwSubject;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }


        public static string From
        {
            get
            {

                try
                {
                    var From = config["appSettings:From"];
                    return From;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }


        public static string smtpServer
        {
            get
            {

                try
                {
                    var smtpServer = config["appSettings:smtpServer"];
                    return smtpServer;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static int smtpPort
        {
            get
            {

                try
                {
                    int smtpPort = Convert.ToInt32(config["appSettings:smtpPort"]);
                    return smtpPort;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static bool security
        {
            get
            {

                try
                {
                    bool security = Convert.ToBoolean(config["appSettings:security"]);
                    return security;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string Authentication
        {
            get
            {

                try
                {
                    var Authentication = config["appSettings:Authentication"];
                    return Authentication;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }


        public static string userNameEmail
        {
            get
            {

                try
                {
                    var userNameEmail = config["appSettings:userNameEmail"];
                    return userNameEmail;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string userpassword
        {
            get
            {

                try
                {
                    var userpassword = config["appSettings:userpassword"];
                    string decryuserpassword = Misc.deCrypt(userpassword);
                    return decryuserpassword;

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }


        public static string SMSURL
        {
            get
            {

                try
                {
                    var SMSURL = config["appSettings:SMSURL"];
                    return SMSURL;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string SMSUsername
        {
            get
            {

                try
                {
                    var username = config["appSettings:username"];
                    return username;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string SMSPassword
        {
            get
            {

                try
                {
                    var password = config["appSettings:password"];
                    string decryuserpassword = Misc.deCrypt(password);
                    return decryuserpassword;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string src
        {
            get
            {

                try
                {
                    var src = config["appSettings:src"];
                    return src;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string dr
        {
            get
            {

                try
                {
                    var dr = config["appSettings:dr"];
                    return dr;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string type
        {
            get
            {

                try
                {
                    var type = config["appSettings:type"];
                    return type;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        //public static string TrackerFE_BaseUrl
        //{
        //    get
        //    {

        //        try
        //        {
        //            var TRACKERFE_BASEURL = config["appSettings:TrackerFE_BaseUrl"];
        //            return TRACKERFE_BASEURL;
        //        }
        //        catch (Exception ex)
        //        {

        //            throw ex;
        //        }
        //    }
        //}

        public static string Ccmail
        {
            get
            {

                try
                {
                    var Ccmail = config["appSettings:Ccmail"];
                    return Ccmail;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        //public static string EDKey
        //{
        //    get
        //    {

        //        try
        //        {
        //            var EDKey = config["appSettings:EDKey"];
        //            return EDKey;
        //        }
        //        catch (Exception ex)
        //        {

        //            throw ex;
        //        }
        //    }
        //}

        //public static string DBPass
        //{
        //    get
        //    {

        //        try
        //        {
        //            var KriptonValue = config["appSettings:KriptonValue"];
        //            return KriptonValue;
        //        }
        //        catch (Exception ex)
        //        {

        //            throw ex;
        //        }
        //    }
        //}

        //public static string KIPV
        //{
        //    get
        //    {

        //        try
        //        {
        //            var KIPV = config["appSettings:KIPV"];
        //            return KIPV;
        //        }
        //        catch (Exception ex)
        //        {

        //            throw ex;
        //        }
        //    }
        //}

        public static string PODPath
        {
            get
            {

                try
                {
                    var KIPV = config["appSettings:PODFilePath"];
                    return KIPV;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
        public static string PODIp
        {
            get
            {

                try
                {
                    var KIPV = config["appSettings:PODFileIP"];
                    return KIPV;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        //public static string SystemUserName
        //{
        //    get
        //    {

        //        try
        //        {
        //            var KIPV = config["appSettings:SystemUserName"];
        //            return KIPV;
        //        }
        //        catch (Exception ex)
        //        {

        //            throw ex;
        //        }
        //    }
        //}

        //public static string SystemPassword
        //{
        //    get
        //    {

        //        try
        //        {
        //            var KIPV = config["appSettings:SystemPassword"];
        //            return KIPV;
        //        }
        //        catch (Exception ex)
        //        {

        //            throw ex;
        //        }
        //    }
        //}

        //public static string ConStrign
        //{
        //    get
        //    {

        //        try
        //        {
        //            var ConStrign = config.GetConnectionString("DefaultConnection");
        //            return ConStrign;
        //        }
        //        catch (Exception ex)
        //        {

        //            throw ex;
        //        }
        //    }
        //}

        //public static string ConStrign_
        //{
        //    get
        //    {
        //        string ConStrign_ = "";
        //        try
        //        {
        //            ConStrign_ = config.GetConnectionString("ConStrign_");
        //        }
        //        catch (Exception ex)
        //        {

        //            //throw ex;
        //        }
        //        return ConStrign_;
        //    }
        //}

        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    var ConStrign = config.GetConnectionString("DefaultConnection");
                    _connectionString = ConStrign;
                }

                return _connectionString;
            }
        }
    }
}
