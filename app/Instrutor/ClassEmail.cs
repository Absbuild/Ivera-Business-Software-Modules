    public class ClassEmail
    {
        public ClassEmail()
        {

        }
        //----
        IVE_INSTRUCTOR.Class.ClassHistory hist = new IVE_INSTRUCTOR.Class.ClassHistory();
        IVE_INSTRUCTOR.Class.ClassAlert calert = new IVE_INSTRUCTOR.Class.ClassAlert();
        IVE_INSTRUCTOR.Class.ClassEncryption ce = new IVE_INSTRUCTOR.Class.ClassEncryption();
        //--------
        string area = "Janela Envio de Email";
        string data = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
        //-------

        public void EnviarEmail(int empresa_id, string username, string sender, string password, string to, string subject, string message, string serverSMTP, int portSMTP, bool sslSMTP, string attach1, string attach2, string attach3, string attach4)
        {
            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Port = Convert.ToInt32(portSMTP);
                smtp.Host = serverSMTP.Trim();
                smtp.EnableSsl = sslSMTP;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(sender, ce.desencriptar(password));

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(sender.Trim());
                mail.To.Add(to.Trim());
                mail.Subject = subject.Trim();
                
                //Preprando o Body
            

                mail.IsBodyHtml = true;
                mail.Body = message.Trim();

                if(attach1 != null)
                {
                    mail.Attachments.Add(new Attachment(attach1));
                }
                if (attach2 != null)
                {
                    mail.Attachments.Add(new Attachment(attach2));
                }
                if (attach3 != null)
                {
                    mail.Attachments.Add(new Attachment(attach3));
                }
                if (attach4 != null)
                {
                    mail.Attachments.Add(new Attachment(attach4));
                }

                smtp.Send(mail);

                calert.AlertSuccess("Email enviado com sucesso.");
                hist.InserirHistorico(empresa_id, username, area, "Enviou Email sobre: (" + subject + ")");

            }catch(Exception ex)
            {
                calert.AlertError("Falha no envio de Email: "+ex.Message);
            }
            
        }
    }