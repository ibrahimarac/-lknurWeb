using AutoMapper;
using Ilknur.Core.Domain.Dto;
using Ilknur.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ilknur.Core.Mappers
{
    public class LogMapper:Profile
    {
        public LogMapper()
        {
            //Entity To Dto
            CreateMap<Log, LogDto>();

            //Dto To Entity
            CreateMap<LogDto, Log>();
        }
    }
}
