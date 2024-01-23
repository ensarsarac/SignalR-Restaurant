using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalREntityLayer.Entities
{
	public class OrderDetail
	{
		[Key]
		public int OrderDetailID { get; set; }
		public int ProductID  { get; set; }
		public Product Product  { get; set; }
		public int ProductCount { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal TotalPrice{ get; set; }
		public int OrderID{ get; set; }
		public Order Order{ get; set; }
	}
}
