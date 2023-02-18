using CRM.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.UILayer.Controllers
{
    [AllowAnonymous]//Login sayfasının, startup.cs kısmında yaptığımız sisteme giriş yapma zorunluluğundan muaf kalması için
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Index(AppUser appUser)
        {
            var result = await _signInManager.PasswordSignInAsync(appUser.UserName, appUser.PasswordHash, false, true);

            if(result.Succeeded && appUser.EmailConfirmed==true)//E-mail onayı şartını da ekledik
            {
                return RedirectToAction("Index", "User");
            }
            return View();
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
