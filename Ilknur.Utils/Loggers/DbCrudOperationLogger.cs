using AutoMapper;
using Ilknur.Core.Domain.Dto;
using Ilknur.Core.Domain.Entities;
using Ilknur.Core.Loggers;
using Ilknur.Core.Repositories;
using Ilknur.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ilknur.Utils.Loggers
{
    public class DbCrudOperationLogger : ICrudOperationLogger
    {
        private readonly ICrudLoggerRepository _logCrudRepo;
        private readonly IMapper _mapper;

        public DbCrudOperationLogger(ICrudLoggerRepository logCrudRepo,IMapper mapper)
        {
            _logCrudRepo = logCrudRepo;
            _mapper = mapper;
        }

        public void LogCrudOperation(IEnumerable<LogDto> logs)
        {
            var logEntities = _mapper.Map<IEnumerable<LogDto>, IEnumerable<Log>>(logs);
            _logCrudRepo.Insert(logEntities);
        }
    }
}
