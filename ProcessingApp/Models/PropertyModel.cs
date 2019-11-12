using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessingApp.Models
{
    public class PropertyModel
    {
        // Key
        [Key]
        public virtual int PropertyId { get; set; }
        public virtual String PropertyName { get; set; }
        public virtual String PropertyAdress { get; set; }
        public virtual double PropertyPrice { get; set; }
        public virtual OwnerModel Owner { get; set; }

    }
}
