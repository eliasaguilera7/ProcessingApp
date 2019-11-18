using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessingApp.Models
{
    public class UserModel:IdentityUser
    {

        public virtual String Name { get; set; }
        public virtual int? MyApplicationId { get; set; }

        [ForeignKey("MyApplicationId")]
        public virtual MyApplication MyApplication { get; set; }
    }
}
