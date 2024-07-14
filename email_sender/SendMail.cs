using error_handler;
//using MailKit.Net.Smtp;
//using MailKit.Security;
//using MimeKit;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using email_sender.Models;
using System.IO;

namespace email_sender
{
    public class SendMail
    {
        private static LogError objError = new LogError();
        //public static (bool messageid, string message) Send(string From, string to, string cc, string subject, string body, string smtpServer, int smtpPort, Boolean security, string userName, string password)
        //{
        //    try
        //    {
        //        string decPassword;
        //        var message = new MimeMessage();
        //        message.From.Add(new MailboxAddress(From));
        //        message.To.Add(new MailboxAddress(to));

        //        if (cc != "")
        //        {
        //            message.Cc.Add(new MailboxAddress(cc));
        //        }


        //        message.Subject = subject;

        //        var bodyBuilder = new BodyBuilder
        //        {
        //            HtmlBody = body
        //        };

        //        message.Body = bodyBuilder.ToMessageBody();



        //        using (var client = new SmtpClient())
        //        {
        //            // Set our custom SSL certificate validation callback.
        //            client.ServerCertificateValidationCallback = MySslCertificateValidationCallback;

        //            if (security == true)
        //            {
        //                client.Connect(smtpServer, smtpPort, SecureSocketOptions.Auto);
        //            }
        //            else
        //            {
        //                client.Connect(smtpServer, smtpPort, SecureSocketOptions.None);
        //            }

        //            if (userName != "")
        //            {
        //                decPassword = password;// EncDec.DecryptStringAES("kljsddS3lo4454GG", password);
        //                client.Authenticate(userName, decPassword);
        //            }


        //            // Note: only needed if the SMTP server requires authentication
        //            //client.Authenticate(userName, decPassword);

        //            client.Send(message);
        //            client.Disconnect(true);
        //        }

        //        return (true, "Mail send succefully");
        //    }
        //    catch (Exception ex)
        //    {
        //        objError.WriteLog(0, "EmailController", "PostEmailTemps", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "EmailController", "PostEmailTemps", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "EmailController", "PostEmailTemps", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "EmailController", "PostEmailTemps", "Inner Exception Message: " + ex.InnerException.Message);
        //        }
        //        return (false, "Mail Sending Error : " + ex.Message);

        //    }
        //}

        public static (bool messageid, string message) Send_V1(string From, string to, string cc, string subject, string body, string smtpServer, int smtpPort, Boolean security, string userName, string password, string EmailFromName, EmailAttachedFileDetails objFilesAttachment)
        {
            try
            {
                SmtpClient client = new SmtpClient();

                //ServicePointManager.SecurityProtocol =SecurityProtocolType.Ssl3 |  SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(/*userName*/From, password);
                client.Port = smtpPort;
                client.Host = smtpServer;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = security;

                MailAddress mailfrom = new MailAddress(From, EmailFromName);

                MailAddress mailto = new MailAddress(to);


                MailMessage msg = new MailMessage(mailfrom, mailto) { Body = body, Subject = subject };

                if (objFilesAttachment.HasFilesAttached == true && objFilesAttachment.FileObjectList != null)
                {
                    foreach (var item in objFilesAttachment.FileObjectList)
                    {
                        if (item.FileBinary != null)
                        {
                            Attachment att = new Attachment(new MemoryStream(item.FileBinary), item.FileName + "." + item.FileExtension);
                            msg.Attachments.Add(att);
                        }
                    }
                }

                msg.IsBodyHtml = true;

                client.Send(msg);

                Console.WriteLine("email sent!");

                objError.WriteLog(2, "SendMail", "Send_V1", "response : " + "email sent!" + " EmailAddress : " + to);

                return (true, "Mail send succefully For subject :" + subject);
            }
            catch (Exception ex)
            {
                objError.WriteLog(0, "SendMail", "Send_V1", " For subject :" + subject + " EmailAddress : " + to + "  Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "SendMail", "Send_V1", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "SendMail", "Send_V1", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "SendMail", "Send_V1", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return (false, "Mail Sending  For subject :" + subject + " Error : " + ex.Message);

            }
        }

        public static (bool messageid, string message) Send_V1_MultipleSender(string From, string to, string cc, string subject, string body, string smtpServer, int smtpPort, Boolean security, string userName, string password, string EmailFromName, EmailAttachedFileDetails objFilesAttachment)
        {
            try
            {
                SmtpClient client = new SmtpClient();

                //ServicePointManager.SecurityProtocol =SecurityProtocolType.Ssl3 |  SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(/*userName*/From, password);
                client.Port = smtpPort;
                client.Host = smtpServer;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = security;

                MailAddress mailfrom = new MailAddress(From, EmailFromName);

                MailMessage msg = new MailMessage() { Body = body, Subject = subject };
                msg.From = mailfrom;

                foreach (var address in to.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    msg.To.Add(new MailAddress(address));
                }

                msg.IsBodyHtml = true;

                if (objFilesAttachment.HasFilesAttached == true && objFilesAttachment.FileObjectList != null)
                {
                    foreach (var item in objFilesAttachment.FileObjectList)
                    {
                        if (item.FileBinary != null)
                        {
                            Attachment att = new Attachment(new MemoryStream(item.FileBinary), item.FileName + "." + item.FileExtension);
                            msg.Attachments.Add(att);
                        }
                    }
                }

                client.Send(msg);

                Console.WriteLine("email sent!");

                objError.WriteLog(2, "SendMail", "Send_V1_MultipleSender", "response : " + "email sent!" + " EmailAddress : " + to);

                return (true, "Mail send succefully For subject :" + subject);
            }
            catch (Exception ex)
            {
                objError.WriteLog(0, "SendMail", "Send_V1_MultipleSender", " For subject :" + subject + " EmailAddress : " + to + "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "SendMail", "Send_V1_MultipleSender", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "SendMail", "Send_V1_MultipleSender", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "SendMail", "Send_V1_MultipleSender", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return (false, "Mail Sending  For subject :" + subject + " Error : " + ex.Message);

            }
        }

        //WithAuth
        //public bool SendWithAuth(string From, string to, string subject, string body, string smtpServer, int smtpPort, Boolean security, string userName, string password)
        //{
        //    try
        //    {
        //        string decPassword = EncDec.DecryptStringAES("kljsddS3lo4454GG", password);
        //        var message = new MimeMessage();
        //        message.From.Add(new MailboxAddress(From));
        //        message.To.Add(new MailboxAddress(to));
        //        message.Subject = subject;

        //        message.Body = new TextPart("plain")
        //        {
        //            Text = body
        //        };

        //        using (var client = new SmtpClient())
        //        {
        //            // Set our custom SSL certificate validation callback.
        //            client.ServerCertificateValidationCallback = MySslCertificateValidationCallback;

        //            if (security == true)
        //            {
        //                client.Connect(smtpServer, smtpPort, SecureSocketOptions.Auto);
        //            }
        //            else
        //            {
        //                client.Connect(smtpServer, smtpPort, SecureSocketOptions.None);
        //            }


        //            // Note: only needed if the SMTP server requires authentication
        //            client.Authenticate(userName, decPassword);

        //            client.Send(message);
        //            client.Disconnect(true);
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        objError.WriteLog(0, "EmailController", "PostEmailTemps", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "EmailController", "PostEmailTemps", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "EmailController", "PostEmailTemps", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "EmailController", "PostEmailTemps", "Inner Exception Message: " + ex.InnerException.Message);
        //        }
        //        return false;
        //    }
        //}

        private static bool MySslCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            // If there are no errors, then everything went smoothly.
            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;

            // Note: MailKit will always pass the host name string as the `sender` argument.
            var host = (string)sender;

            if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateNotAvailable) != 0)
            {
                // This means that the remote certificate is unavailable. Notify the user and return false.
                Console.WriteLine("The SSL certificate was not available for {0}", host);
                return false;
            }

            if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateNameMismatch) != 0)
            {
                // This means that the server's SSL certificate did not match the host name that we are trying to connect to.
                var certificate2 = certificate as X509Certificate2;
                var cn = certificate2 != null ? certificate2.GetNameInfo(X509NameType.SimpleName, false) : certificate.Subject;

                Console.WriteLine("The Common Name for the SSL certificate did not match {0}. Instead, it was {1}.", host, cn);
                return false;
            }

            // The only other errors left are chain errors.
            Console.WriteLine("The SSL certificate for the server could not be validated for the following reasons:");

            // The first element's certificate will be the server's SSL certificate (and will match the `certificate` argument)
            // while the last element in the chain will typically either be the Root Certificate Authority's certificate -or- it
            // will be a non-authoritative self-signed certificate that the server admin created. 
            foreach (var element in chain.ChainElements)
            {
                // Each element in the chain will have its own status list. If the status list is empty, it means that the
                // certificate itself did not contain any errors.
                if (element.ChainElementStatus.Length == 0)
                    continue;

                Console.WriteLine("\u2022 {0}", element.Certificate.Subject);
                foreach (var error in element.ChainElementStatus)
                {
                    // `error.StatusInformation` contains a human-readable error string while `error.Status` is the corresponding enum value.
                    Console.WriteLine("\t\u2022 {0}", error.StatusInformation);
                }
            }

            return false;
        }

    }
}
