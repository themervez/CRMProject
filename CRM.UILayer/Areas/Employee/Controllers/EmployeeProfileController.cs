using CRM.EntityLayer.Concrete;
using CRM.UILayer.Areas.Employee.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class EmployeeProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public EmployeeProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserProfileEdit userProfileEdit = new UserProfileEdit();
            userProfileEdit.Name = values.Name;
            userProfileEdit.Surname = values.Surname;
            userProfileEdit.PhoneNumber = values.PhoneNumber;
            userProfileEdit.Email = values.Email;
            return View(userProfileEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserProfileEdit p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            if (p.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();//Dosyanın anlık bulunduğu konumu için
                var extension = Path.GetExtension(p.Image.FileName);//Resim dosyasının path'ini aldık
                var imageName = Guid.NewGuid() + extension;//Benzersiz dosya isimleri için
                var savelocation = resource + "/wwwroot/UserImages/" + imageName;//Resmin kaydedileceği konum
                var stream = new FileStream(savelocation, FileMode.Create);//Resmin kaydolacağı kısım ve dosyanın erişim türünü(okuma,yazma,oluşturma,..) belirttik stream ile birlikte
                await p.Image.CopyToAsync(stream);//Akıştaki değeri asenkron olarak kopyaladık
                values.ImageURL = imageName;
            }
            values.Name = p.Name;
            values.Surname = p.Surname;
            values.Email = p.Email;
            values.PhoneNumber = p.PhoneNumber;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, p.Password);//hangi kullanıcı için ve şifrenin geleceği değişken adını giriyoruz

            if (p.Password == p.ConfirmPassword)
            {
                var result = await _userManager.UpdateAsync(values);
                if (result.Succeeded)
                {
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
            return View();
        }
    }
}
