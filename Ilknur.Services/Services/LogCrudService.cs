using AutoMapper;
using Ilknur.Core;
using Ilknur.Core.Domain.Dto;
using Ilknur.Core.Domain.Entities;
using Ilknur.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ilknur.Services.Services
{
    public class LogCrudService : ILogCrudService
    {
        private readonly IMapper Mapper;
        private readonly IUnitWork Database;

        public LogCrudService(IMapper mapper, IUnitWork uWork)
        {
            Mapper = mapper;
            Database = uWork;
        }

    }
}
