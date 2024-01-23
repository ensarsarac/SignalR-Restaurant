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
	public class IOrderManager : IOrderService
	{
		private readonly IOrderDal _orderDal;

		public IOrderManager(IOrderDal orderDal)
		{
			_orderDal = orderDal;
		}

		public int TActiveOrderCount()
		{
			return _orderDal.ActiveOrderCount();
		}

		public void TAdd(Order entity)
		{
			throw new NotImplementedException();
		}

		public void TDelete(Order entity)
		{
			throw new NotImplementedException();
		}

		public Order TGetById(int id)
		{
			throw new NotImplementedException();
		}

		public List<Order> TGetListAll()
		{
			throw new NotImplementedException();
		}

		public decimal TLastOrderPrice()
		{
			return _orderDal.LastOrderPrice();
		}

		public decimal TTodayTotalPrice()
		{
			return _orderDal.TodayTotalPrice();
		}

		public int TTotalOrder()
		{
			return _orderDal.TotalOrder();
		}

		public void TUpdate(Order entity)
		{
			throw new NotImplementedException();
		}
	}
}
