using Ilknur.Core.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ilknur.Core.Domain.Entities
{
    public abstract class BaseEntity:IBaseEntity
    {
        public int Id { get; set; }
    }

    public abstract class NonTrackablePermanentEntity:BaseEntity,IPermanent
    {
        public bool? IsActive { get; set; }
    }

    public abstract class TrackableTransientEntity : BaseEntity,ITrackable
    {
        public string CreateUser { get; set; }
        public string LastupUser { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastupDate { get; set; }
    }

    public abstract class TrackablePermanentEntity :BaseEntity, ITrackable,IPermanent
    {
        public string CreateUser { get; set; }
        public string LastupUser { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastupDate { get; set; }
        public bool? IsActive { get; set; }
    }

}
