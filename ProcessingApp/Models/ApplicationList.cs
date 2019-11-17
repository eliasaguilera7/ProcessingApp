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
        public virtual int MyApplicationId { get; set; }
        public virtual MyApplication PersonalAccount { get; set; }
        public virtual int PropertyId { get; set; }
        public virtual PropertyModel Property { get; set; }
    }
}
