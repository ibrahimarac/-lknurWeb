using AutoMapper;
using Ilknur.Core.Domain.Dto;
using Ilknur.Web.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ilknur.Web.Mappings
{
    public class CategoryMappings:Profile
    {
        public CategoryMappings()
        {
            CreateMap<CategoryDto, CategoryVM>();
            CreateMap<CategoryVM, CategoryDto>();
        }
    }
}
