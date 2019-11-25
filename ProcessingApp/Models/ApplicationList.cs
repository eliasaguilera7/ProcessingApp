using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessingApp.Models
{
    public class ApplicationList
    {
        [Key]
        public virtual int Id { get; set; }

		[Required]
        public virtual int MyApplicationId { get; set; }

		[Required]
        public virtual MyApplication PersonalAccount { get; set; }

		[ForeignKey("PropertyId")]
        public virtual int PropertyId { get; set; }

		[Required]
        public virtual PropertyModel Property { get; set; }
    }
}
