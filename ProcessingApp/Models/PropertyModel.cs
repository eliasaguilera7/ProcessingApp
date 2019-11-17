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

        // Property Name
        [Display(Name = "Property Name")]
        // Input validation
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [StringLength(50, MinimumLength = 3)]
        public virtual String PropertyName { get; set; }

        // Property Description
        [Display(Name = "Property Description")]
        [StringLength(50, MinimumLength = 10)]
        [Required]
        public virtual String PropertyDescription { get; set; }

        [Display(Name = "Address")]
        // input validation
        [Required]
        [StringLength(60, MinimumLength = 10)]
        public virtual String PropertyAdress { get; set; }

        // Price
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        [Required]
        public virtual double PropertyPrice { get; set; }

        // City
        [Display(Name = "City")]
        [Required]
        public virtual String City { get; set; }

        [Display(Name = "Image")]
        public virtual String ImageUrl { get; set; }
        
        // Owner
        public virtual OwnerModel Owner { get; set; }
    }
}
