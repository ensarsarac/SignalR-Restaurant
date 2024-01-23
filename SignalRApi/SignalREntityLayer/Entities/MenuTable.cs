using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalREntityLayer.Entities
{
	public class MenuTable
	{
		[Key]
		public int MenuTableID { get; set; }
		public string Name { get; set; }
		public bool Status { get; set; }
		public List<Order> Orders{ get; set; }
		public List<Basket> Baskets{ get; set; }
	}
}
