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
            var jsonCustomers = JsonConvert.SerializeObject(_customerService.TGetList());//Gelen verileri json formatına dönüştürdük
            return Json(jsonCustomers);
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            _customerService.TInsert(customer);//Veri tabanına ekledik
            var values = JsonConvert.SerializeObject(customer);//Ajax'a ait değerleri kullanabilmek için,Ekleme işlemini veri tabanına Ajax üzerinden göndermemizi sağlayacak
            return Json(values);
        }
        public IActionResult GetById(int ID)
        {
            var customer = JsonConvert.SerializeObject(_customerService.TGetById(ID));
            return Json(customer);
        }
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _customerService.TGetById(id);
            _customerService.TDelete(customer);
            return Json(customer);
        }

        public IActionResult UpdateCustomer(Customer customer)
        {
            _customerService.TUpdate(customer);
            var values = JsonConvert.SerializeObject(customer);
            return Json(values);
        }
    }
}
