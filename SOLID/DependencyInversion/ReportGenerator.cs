using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversion
{
    public class ReportGenerator(ISender sender)
    {

        //private MailSender sender;

        //public ReportGenerator(MailSender mailSender)
        //{
        //    this.sender = mailSender;
        //}

        //public MailSender Sender { get; set; }
        public void Send(string to)
        {
           
            sender.Send(to);

        }
    }

    public interface ISender
    {
        void Send(string to);
    }
    public class MailSender : ISender
    {
        public void Send(string to)
        {
            Console.WriteLine($"{to} kişisne mail gönderildi");
        }
    }

    public class WhatsAppSender : ISender
    {
        public void Send(string to)
        {
            Console.WriteLine($"{to} kişisne WS gönderildi");
        }
    }

    public class TelegramSender : ISender
    {
        public void Send(string to)
        {
            Console.WriteLine($"{to} kişisne telegram mesajı  gönderildi");
        }
    }

    public class TwitterSender : ISender
    {
        public void Send(string to)
        {
            Console.WriteLine($"{to} kişisne twit gönderildi");
        }
    }
}
