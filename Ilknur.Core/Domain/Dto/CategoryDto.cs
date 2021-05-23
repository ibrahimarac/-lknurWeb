using System;
using System.Collections.Generic;
using System.Text;

namespace Ilknur.Core.Domain.Dto
{
    //POCO object
    //Plain Old Clr Object
    public class CategoryDto:AuditableDto
    {
        public string Name { get; set; }    
    }
}
