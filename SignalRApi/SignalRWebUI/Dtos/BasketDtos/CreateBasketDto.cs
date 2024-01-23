using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Dtos.BasketDtos
{
	public class CreateBasketDto
	{
		public decimal Price { get; set; }
		public decimal Count { get; set; }
		public decimal TotalPrice { get; set; }
		public int ProductID { get; set; }
		public int MenuTableID { get; set; }
		public int AppUserID { get; set; }

	}
}
