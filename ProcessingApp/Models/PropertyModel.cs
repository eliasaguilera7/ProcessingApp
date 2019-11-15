using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessingApp.Models
{
    public class PropertyModel
    {
        // Key1
        [Key]
        public virtual int PropertyId { get; set; }

        // Property Name
        [Display(Name = "Property Name")]
        // Input validation
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [StringLength(50, MinimumLength = 3)]
        public virtual String PropertyName { get; set; }

        [Display(Name = "Address")]
        // input validation
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [StringLength(60, MinimumLength = 10)]
        public virtual String PropertyAdress { get; set; }

        // Price
        [Required]
        public virtual double PropertyPrice { get; set; }

        // Owner
        public virtual OwnerModel Owner { get; set; }

    }
}
