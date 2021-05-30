using Ilknur.Core.Domain.Dto;
using Ilknur.Core.Loggers;
using Ilknur.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ilknur.Utils.Loggers
{
    public class DbExceptionLogger:IExceptionLogger
    {
        private readonly IErrorService _errorService;

        public DbExceptionLogger(IErrorService errorService)
        {
            _errorService = errorService;
        }

        public void LogException(ErrorDto error)
        {
            _errorService.AddError(error);
        }

        
    }
}
