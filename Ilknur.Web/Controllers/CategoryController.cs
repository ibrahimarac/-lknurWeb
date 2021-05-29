using Ilknur.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ilknur.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService Categories;

        public CategoryController(ICategoryService categoryService)
        {
            Categories = categoryService;
        }

        [HttpGet]
        [Route("Category/List")]
        public IActionResult List()
        {
            var categoryDtos=Categories.GetAllCategories();
            return View();
        }
    }
}
