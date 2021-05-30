using AutoMapper;
using Ilknur.Core.Domain.Dto;
using Ilknur.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ilknur.Core.Mappers
{
    public class ErrorMapper:Profile
    {
        public ErrorMapper()
        {
            CreateMap<Error, ErrorDto>();
            CreateMap<ErrorDto, Error>();
        }
    }
}
