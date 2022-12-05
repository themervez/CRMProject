using CRM.BusinessLayer.Abstract;
using CRM.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.UILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AdminCustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public AdminCustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Sayfa yüklendikten sonra bir post işlemi olmadan butona tıklandığı zaman verilerin listelenmesi işlemi
        public IActionResult CustomerList()
        {
            var jsonCustomers = JsonConvert.SerializeObject(_customerService.TGetList());
            return Json(jsonCustomers);//Birleştirme, dizi haline getirme işlemi için kulandık json'ı
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            _customerService.TInsert(customer);//Veri tabanına ekledik
            var values = JsonConvert.SerializeObject(customer);//AJAX' ı kullanabilmek için bu ilemi yaptık,Ekleme işlemini veri tabanına AJAX üzerinden göndermemizi sağlayacak
            return Json(values);
        }
    }
}
