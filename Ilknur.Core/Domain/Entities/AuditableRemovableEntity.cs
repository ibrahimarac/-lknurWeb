using Ilknur.Core.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ilknur.Core.Domain.Entities
{
    public abstract class AuditableRemovableEntity:IBaseEntity,IAuditableEntity
    {
        public int Id { get; set; }

        public string LastupUser { get; set; }

        public string CreateUser { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastupDate { get; set; }

        public AuditableRemovableEntity()
        {
            CreateDate = DateTime.Now;
            LastupDate = DateTime.Now;
            CreateUser = "admin";
            LastupUser = "admin";
        }
    }
}
