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
    public class ErrorService : IErrorService
    {
        private readonly IMapper Mapper;
        private readonly IUnitWork Database;

        public ErrorService(IMapper mapper,IUnitWork uWork)
        {
            Mapper = mapper;
            Database = uWork;
        }

        public void AddError(ErrorDto errorDto)
        {
            var error = Mapper.Map<ErrorDto, Error>(errorDto);
            Database.Errors.Insert(error);
            Database.Commit();
        }
    }
}
