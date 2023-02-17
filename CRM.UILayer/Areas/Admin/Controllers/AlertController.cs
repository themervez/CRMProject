using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM.UILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AlertController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
