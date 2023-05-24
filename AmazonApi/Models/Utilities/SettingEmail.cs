using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace AmazonApi.Utilities
{
    public class SettingEmail
    {
        //crear variables de servidor SMTP
        private static readonly SmtpClient ServidorSMTP = new();
        //private static string EmailBody = "";
        //private static string Asunto 
        private static readonly MailMessage Correo = new();
        //Asignar valores a las variables
        private static void ParameterEmail()
        {
            //Asignar valores a las variables
            ServidorSMTP.Host = "smtp.office365.com";
            ServidorSMTP.EnableSsl = true;
            NetworkCredential Credenciales = new("info@ariaslaw.com", "W%Ex9VJa52cANl$");
            ServidorSMTP.UseDefaultCredentials = false;
            ServidorSMTP.Credentials = Credenciales;
            ServidorSMTP.Port = 587;
            
        }


        public static void SendEmail(List<string> DestinatariosTo, List<string> DestinatariosCC, string Asunto,string EmailBody)
        {
            try
            {
                ParameterEmail();
                Correo.Subject = Asunto;
                Correo.IsBodyHtml = true;
                Correo.SubjectEncoding = Encoding.UTF8;
                Correo.Body = EmailBody;
                Correo.BodyEncoding = Encoding.UTF8;
                Correo.Priority = MailPriority.Normal;
                Correo.From = new MailAddress("info@ariaslaw.com");
                //Agregar los destinatarios
                Correo.To.Clear();
                Correo.CC.Clear();
                var emailValid = new EmailAddressAttribute();
                foreach (string Contact in DestinatariosTo)
                {
                    if (Contact != "")
                    {
                        if (emailValid.IsValid(Contact))
                        {
                            Correo.To.Add(new MailAddress(Contact));
                        }
                    }

                }
                foreach (string Contact in DestinatariosCC)
                {
                    if (Contact != "")
                    {
                        if (emailValid.IsValid(Contact))
                        {
                            Correo.CC.Add(new MailAddress(Contact));
                        }

                    }

                }
                //Enviar correo
                ServidorSMTP.Send(Correo);
            }
            catch (Exception)
            {
            }
        }
    }
}
