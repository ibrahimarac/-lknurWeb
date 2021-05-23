using Ilknur.Core;
using Ilknur.Core.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ilknur.Core.Domain.Entities;
using System.Linq;
using Ilknur.Core.Services;

namespace Ilknur.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitWork Database;

        public CategoryService(IUnitWork uWork)
        {
            Database = uWork;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategories()
        {
            var categories = await Database.Categories.GetAllAsync(false);
            return categories.Select(c => new CategoryDto
            {
                Id=c.Id,
                Name=c.Name
            });
        }

    }
}
