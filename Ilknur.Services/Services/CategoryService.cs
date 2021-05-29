using Ilknur.Core;
using Ilknur.Core.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ilknur.Core.Domain.Entities;
using System.Linq;
using Ilknur.Core.Services;
using AutoMapper;
using Ilknur.Core.Mappers;

namespace Ilknur.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitWork Database;
        private readonly IMapper Mapper;
        
        public CategoryService(IUnitWork uWork, IMapper mapper)
        {
            Database = uWork;
            Mapper = mapper;
        }

        public void AddCategory(CategoryDto categoryDto)
        {
            var category = Mapper.Map<CategoryDto, Category>(categoryDto);
            Database.Categories.Insert(category);
            Database.Commit();
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategories()
        {
            var categories = await Database.Categories.GetAllAsync(false);
            var categoryDtos=Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(categories);
            return categoryDtos;
        }

    }
}
