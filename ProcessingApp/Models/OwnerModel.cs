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

        // Owner Name
        [Display(Name = "Owner")]
        [Required]
        public virtual String OwnerName { get; set; }
    }
}
