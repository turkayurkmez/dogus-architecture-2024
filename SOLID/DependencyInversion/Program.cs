// See https://aka.ms/new-console-template for more information
using DependencyInversion;

Console.WriteLine("Hello, World!");
MailSender mailSender = new MailSender();
WhatsAppSender whatsSender = new WhatsAppSender();
TelegramSender TelegramSender = new TelegramSender();
TwitterSender TwitterSender = new TwitterSender();

ReportGenerator reportGenerator = new ReportGenerator(whatsSender);
ReportGenerator reportGenerator2 = new ReportGenerator(TwitterSender);

