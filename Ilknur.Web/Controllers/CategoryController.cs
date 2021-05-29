﻿using AutoMapper;
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

        public CategoryController(ICategoryService categoryService,IMapper mapper)
        {
            Categories = categoryService;
            Mapper = mapper;
        }

        [HttpGet]
        [Route("Category/List")]
        public async Task<IActionResult> List()
        {
            //Dto to VM
            var categoryDtos=await Categories.GetAllCategories();
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
            //VM to Dto
            var categoryDto = Mapper.Map<CategoryVM, CategoryDto>(categoryVM);
            categoryDto.CreateDate = DateTime.Now;
            categoryDto.LastupDate = DateTime.Now;
            categoryDto.CreateUser = "admin";
            categoryDto.LastupUser = "admin";
            Categories.AddCategory(categoryDto);
            return RedirectToAction("List");
        }

    }
}
