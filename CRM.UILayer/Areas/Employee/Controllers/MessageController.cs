using CRM.BusinessLayer.Abstract;
using CRM.DAL.Concrete;
using CRM.EntityLayer.Concrete;
using CRM.UILayer.Areas.Employee.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly UserManager<AppUser> _userManager;

        public MessageController(IMessageService messageService, UserManager<AppUser> userManager)
        {
            _messageService = messageService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(Message m)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);//UserName'e göre sisteme erişen kullancının verilerini values değişkenine atadık.//Sistemden gelen User'ı kullanarak

            m.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            m.SenderEmail = values.Email;
            m.SenderName = values.Name + " " + values.Surname;

            using (var context = new Context())
            {
                m.ReceiverName = context.Users.Where(x => x.Email == m.ReceiverEmail).Select(x => x.Name + " " + x.Surname).FirstOrDefault();//m parametresinden gelen alıcı e-mailine göre veri tabanından bu kullancının isim ve soyadını aldık
            }
            _messageService.TInsert(m);//Mesaj gönderimi için
            return RedirectToAction("SendMessage");
        }

        [HttpGet]
        public IActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(EmailRequest m)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin","merve@gmail.com");//Gerçek E-mail adresini giriyoruz
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", m.ReceiverEmail);//Alıcı maili olarak modelden gelen alıcının mail adresini gönderdik
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();//Mesajın içeriği için BodyBuilder sınıfını kullandık,html etiketleri,vs. de kullanabilmek için(kalın punto,eğik yazı gibi işlemler için)
            bodyBuilder.TextBody = m.Content;
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = m.Subject;


            SmtpClient client = new SmtpClient(); //Simple Mail Transfer Protokol.Email gönderim aşaması
            client.Connect("smtp.gmail.com", 587, false); //Gmail için mail gönderme protokolü ve 587:Türkiye için port numarası,false:ssl kullanılmasın
            client.Authenticate("merve@gmail.com", "lepsirbpvyiklxmt");//gerçek email adresini key değeri ile birlikte gönderiyoruz
            client.Send(mimeMessage);
            client.Disconnect(true);//İşlem bittikten sonra bağlantının kapanması için

            return View();
        }
    }
}
