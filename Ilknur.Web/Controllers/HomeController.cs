
using Ilknur.Web.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Ilknur.Web.Controllers
{
    public class HomeController : Controller
    {
        IlknurContext _ctx;
        public HomeController(IlknurContext ctx)
        {
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();

            //var category1 = _ctx.Categories.SingleOrDefault(c => c.Id == 4); //Attached
            //var category2 = new Category { Id = 4 }; //Detecthed
            //_ctx.Attach(category2);

            //var category3 = _ctx.Entry<Category>();

            //_ctx.Set<Category>().Where

            _ctx.SaveChanges();
        }

    }
}
