using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ilknur.Web.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error() //500 numaralı status kodlarda yani C# kodlarının ürettiği exceptionlar için
        {
            return View();
        }
    }
}
