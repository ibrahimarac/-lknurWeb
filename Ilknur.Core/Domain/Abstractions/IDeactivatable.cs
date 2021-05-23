using System;
using System.Collections.Generic;
using System.Text;

namespace Ilknur.Core.Domain.Abstractions
{
    public interface IDeactivatable
    {
        bool IsActive { get; set; }
    }
}
