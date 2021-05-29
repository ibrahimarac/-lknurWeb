using Ilknur.Core.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ilknur.Core.Domain.Entities
{
    public class Category:TrackablePermanentEntity
    {   
        public string Name { get; set; }


        public Category()
        {

        }
    }
}
