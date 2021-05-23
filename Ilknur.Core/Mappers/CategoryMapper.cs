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
            CreateMap<Category, CategoryDto>()
                .ForMember(dto => dto.Status, opt => opt.MapFrom(entity => entity.IsActive.Value?1:0));


            //Dto to Entity
            CreateMap<CategoryDto, Category>()
                .ForMember(entity => entity.IsActive, opt => opt.MapFrom(dto => dto.Status==1?true:false));
        }
    }
}
