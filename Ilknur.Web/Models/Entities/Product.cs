using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ilknur.Web.Models.Entities
{
    public class Product:AuditableEntity
    {
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public string Name { get; set; }

    }
}
