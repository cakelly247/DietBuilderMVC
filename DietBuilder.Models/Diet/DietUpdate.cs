using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietBuilder.Models.Diet
{
	public class DietUpdate
	{
        public int Id { get; set; }

		[Required, MaxLength(100)]
		public string? Name { get; set; }

		[Required, MaxLength(1000)]
		public string? Description { get; set; }
    }
}
