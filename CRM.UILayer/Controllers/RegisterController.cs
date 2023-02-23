using CRM.EntityLayer.Concrete;
using CRM.UILayer.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Threading.Tasks;

namespace CRM.UILayer.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserSignUpModel p)
        {
            if (ModelState.IsValid)//Eğer model geçerliyse işlemlerin yapılması için
            {
                AppUser appUser = new AppUser()
                {
                    UserName = p.UserName,
                    Name = p.Name,
                    Surname = p.Surname,
                    Email = p.Email,
                    PhoneNumber = p.PhoneNumber,
                    EmailCode = new Random().Next(10000, 1000000).ToString()
                };

                if (p.Password == p.ConfirmPassword)
                {
                    var result = await _userManager.CreateAsync(appUser, p.Password);
                    if (result.Succeeded)
                    {
                        //SendEmail(appUser.Email, appUser.EmailCode);
                        //return RedirectToAction("EmailConfirmed", "Register");
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Şifreler Uyuşmuyor");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult EmailConfirmed()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EmailConfirmed(AppUser appUser)
        {
            var user = await _userManager.FindByEmailAsync(appUser.Email);
            if (user.EmailCode == appUser.EmailCode)
            {
                user.EmailConfirmed = true;

                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Login");
            }

            return View();
        }
        public void SendEmail(string email, string emailcode)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "merve@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", email);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = emailcode;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = "Üyelik Kaydı";

            SmtpClient smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, false);
            smtp.Authenticate("merve@gmail.com", "dfghjklokukllopty");
            smtp.Send(mimeMessage);
            smtp.Disconnect(true);
        }
    }
}
/*
 1)Kullanıcı tablosuna 1 tane daha sütun ekleyelim. Bu sütun rastgele 6 haneli bir karakter alsın, bu 6 haneli karakter kullanıcının sisteme giriş yaptığı e-mail adresine body kısmı üzerinden iletilsin
2)Login sayfasından önce bir sayfa daha açılsın, bu sayfa e-mail confirmed işlemini karşılıyor olacak. Eğer kullanıcı e-mail adresine gelen veriyi doğru şekilde input a girerse,
input: e-mail adresi
input: kod

eşleşme sonrasında EmailConfirmed sütunu true olarak değişsin
 */
