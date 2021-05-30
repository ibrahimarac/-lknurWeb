using Ilknur.Core.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ilknur.Core.Services
{
    public interface IErrorService
    {
        void AddError(ErrorDto errorDto);
    }
}
