using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;

namespace DietBuilder.Data.Entities
{
	public class UserEntity : IdentityUser<int>
	{
        //[ForeignKey(nameof(Diet))]
        //public int DietId { get; set; }

        //public virtual DietEntity? Diet { get; set; }

        //public virtual IEnumerable<MealEntity>? Meals { get; set; }
    }
}
