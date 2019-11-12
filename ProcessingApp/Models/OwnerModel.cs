using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessingApp.Models
{
    public class OwnerModel
    {
        // Key
        [Key]
        public virtual int OwnerId { get; set; }
        public virtual String OwnerName { get; set; }
    }
}
