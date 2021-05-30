using Ilknur.Core.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ilknur.Core.Loggers
{
    public interface IExceptionLogger
    {
        void LogException(ErrorDto error);
    }
}
