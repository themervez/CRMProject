using CRM.UILayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CRM.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class ChartController : Controller
    {
        List<DepartmantSalary> departmantSalaries = new List<DepartmantSalary>();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DepartmantChart()
        {
            departmantSalaries.Add(new DepartmantSalary { 
            name="Yazılım",
            salaryavg=18000
            });

            departmantSalaries.Add(new DepartmantSalary
            {
                name = "Test",
                salaryavg = 15000
            });

            departmantSalaries.Add(new DepartmantSalary
            {
                name = "İnsan Kaynakları",
                salaryavg = 17000
            });

            departmantSalaries.Add(new DepartmantSalary
            {
                name = "Satış ve Pazarlama",
                salaryavg = 20000
            });

            return Json(new{ jsonList=departmantSalaries });//Google Chart ile bir json'la karşılaşacağımız için Json gönderiyoruz
        }
    }
}
