using AutoMapper;
using Ilknur.Core.Domain.Dto;
using Ilknur.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ilknur.Core.Mappers
{
    public class CategoryMapper:Profile
    {
        public CategoryMapper()
        {
            //Entity To Dto
            CreateMap<Category, CategoryDto>();

            //Dto to Entity
            CreateMap<CategoryDto, Category>();
        }
    }
}
