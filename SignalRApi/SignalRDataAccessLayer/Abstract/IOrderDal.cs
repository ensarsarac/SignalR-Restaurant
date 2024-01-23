using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDataAccessLayer.Abstract
{
	public interface IOrderDal:IGenericDal<Order>
	{
		int TotalOrder();
		int ActiveOrderCount();
		decimal LastOrderPrice();
		decimal TodayTotalPrice();
	}
}
