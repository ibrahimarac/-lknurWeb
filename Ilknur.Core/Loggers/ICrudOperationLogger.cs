using Ilknur.Core.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ilknur.Core.Loggers
{
    public interface ICrudOperationLogger
    {
        void LogCrudOperation(IEnumerable<LogDto> logs);
    }
}
