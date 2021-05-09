using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ilknur.Web.Models.Entities
{
    public abstract class AuditableEntity:BaseEntity
    {
        public string LastupUser { get; set; }

        public string CreateUser { get; set; }

        
        public DateTime CreateDate { get; set; }
        public DateTime LastupDate { get; set; }

        public AuditableEntity()
        {
            CreateDate = DateTime.Now;
            LastupDate = DateTime.Now;
            CreateUser = "admin";
            LastupUser = "admin";
        }
    }
}
