using SignalRBusinessLayer.Abstract;
using SignalRDataAccessLayer.Abstract;
using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusinessLayer.Concrete
{
	public class OrderDetailsManager : IOrderDetailsService
	{
		private readonly IOrderDetailsDal _orderDetailsDal;

		public OrderDetailsManager(IOrderDetailsDal orderDetailsDal)
		{
			_orderDetailsDal = orderDetailsDal;
		}

		public void TAdd(OrderDetail entity)
		{
			throw new NotImplementedException();
		}

		public void TDelete(OrderDetail entity)
		{
			throw new NotImplementedException();
		}

		public OrderDetail TGetById(int id)
		{
			throw new NotImplementedException();
		}

		public List<OrderDetail> TGetListAll()
		{
			throw new NotImplementedException();
		}

		public void TUpdate(OrderDetail entity)
		{
			throw new NotImplementedException();
		}
	}
}
