using System;
using System.Collections.Generic;
using System.Text;

namespace Ilknur.Core.Domain.Abstractions
{
    public interface ITrackable:IBaseEntity
    {
        string CreateUser { get; set; }
        string LastupUser { get; set; }
        DateTime CreateDate { get; set; }
        DateTime LastupDate { get; set; }
    }
}
