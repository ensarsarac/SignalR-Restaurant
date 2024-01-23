using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalREntityLayer.Entities
{
	public class Order
	{
		[Key]
		public int OrderID { get; set; }
		public int MenuTableID{ get; set; }
		public MenuTable MenuTable{ get; set; }
		public string Description{ get; set; }
		[Column(TypeName ="Date")]
		public DateTime Date{ get; set; }
		public decimal TotalPrice{ get; set; }
		public List<OrderDetail> OrderDetails { get; set; }
	}
}
