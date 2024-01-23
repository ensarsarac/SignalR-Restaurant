using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalREntityLayer.Entities
{
	public class MoneyCase
	{
		[Key]
		public int MoneyCaseID { get; set; }
		public decimal TotalAmount { get; set; }
	}
}
