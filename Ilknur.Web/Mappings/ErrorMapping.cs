using AutoMapper;
using Ilknur.Core.Domain.Dto;
using Ilknur.Web.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ilknur.Web.Mappings
{
    public class ErrorMapping:Profile
    {
        public ErrorMapping()
        {
            CreateMap<ErrorDto, ErrorVM>();
            CreateMap<ErrorVM, ErrorDto>();
        }
    }
}
