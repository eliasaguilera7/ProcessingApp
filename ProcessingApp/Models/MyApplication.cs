using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessingApp.Models
{
    public class MyApplication
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public virtual int MyApplicationId { get; set; }
        public virtual List<ApplicationList> Applications { get; set; }
    }
}
