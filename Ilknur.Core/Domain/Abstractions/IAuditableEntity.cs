using System;
using System.Collections.Generic;
using System.Text;

namespace Ilknur.Core.Domain.Abstractions
{
    public interface IAuditableEntity
    {
        string LastupUser { get; set; }

        string CreateUser { get; set; }

        DateTime CreateDate { get; set; }

        DateTime LastupDate { get; set; }
    }
}
