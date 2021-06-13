using AutoMapper;
using Ilknur.Core.Domain.Dto;
using Ilknur.Core.Services;
using Ilknur.Web.Models.VM;
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
        private readonly IMapper Mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            Categories = categoryService;
            Mapper = mapper;
        }

        [HttpGet]
        [Route("Category/List")]
        public async Task<IActionResult> List()
        {
            //Dto to VM
            var categoryDtos = await Categories.GetAllCategories();
            var categoryVM = Mapper.Map<IEnumerable<CategoryDto>, IEnumerable<CategoryVM>>(categoryDtos);
            return View(categoryVM);
        }

        [HttpGet]
        [Route("Category/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Category/Create")]
        public IActionResult Create(CategoryVM categoryVM)
        {
            //Validation kontrolünü yapalım
            if (!ModelState.IsValid)
                return View(categoryVM);

            //VM to Dto
            var categoryDto = Mapper.Map<CategoryVM, CategoryDto>(categoryVM);

            Categories.AddCategory(categoryDto);
                       
            return RedirectToAction("List");
        }

        [HttpGet]
        [Route("Category/Edit/{id:int?}")]
        public IActionResult Edit(int? id)
        {
            var categoryDto = Categories.GetCategoryById(id);
            var categoryVM = Mapper.Map<CategoryDto, CategoryVM>(categoryDto);
            return View(categoryVM);
        }

        [HttpPost]
        [Route("Category/Edit")]
        public IActionResult Edit(CategoryVM categoryVM)
        {
            if (!ModelState.IsValid)
                return View(categoryVM);

            var categoryDto = Categories.GetCategoryById(categoryVM.Id,isTracking:false);
            categoryDto.Name = categoryVM.Name;
            categoryDto.IsActive = categoryVM.IsActive;
           
            Categories.UpdateCategory(categoryDto);
            return RedirectToAction("List");
        }

        

    }
}
