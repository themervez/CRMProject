using CRM.BusinessLayer.Abstract;
using CRM.DTOLayer.ContactDTOs;
using CRM.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CRM.UILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(ContactAddDTO model)
        {
            if (ModelState.IsValid)
            {
                _contactService.TInsert(new Contact()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Content = model.Content,
                    Subject = model.Subject,
                    Date = DateTime.Parse(DateTime.Now.ToShortDateString())
                });

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
