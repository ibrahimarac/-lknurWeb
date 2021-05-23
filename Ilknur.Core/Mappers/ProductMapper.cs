using AutoMapper;
using Ilknur.Core.Domain.Dto;
using Ilknur.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ilknur.Core.Mappers
{
    public class ProductMapper:Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductDto>();

            CreateMap<ProductDto, Product>();
        }
    }
}
