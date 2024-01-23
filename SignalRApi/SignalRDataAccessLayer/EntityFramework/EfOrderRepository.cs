using SignalRDataAccessLayer.Abstract;
using SignalRDataAccessLayer.Concrete;
using SignalRDataAccessLayer.Repositories;
using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDataAccessLayer.EntityFramework
{
	public class EfOrderRepository: IGenericRepository<Order>,IOrderDal
	{
		public EfOrderRepository(SignalRContext context):base(context)
		{

		}

		public int ActiveOrderCount()
		{
			using var context = new SignalRContext();
			var value = context.Orders.Where(x => x.Description == "Müşteri Masada").Count();
			return value;
		}

		public decimal LastOrderPrice()
		{
			using var context = new SignalRContext();
			var value = context.Orders.Where(x=>x.Description=="Müşteri Masada").OrderByDescending(x => x.Date).Select(y => y.TotalPrice).FirstOrDefault();
			return value;
		}

		public decimal TodayTotalPrice()
		{
			using var context = new SignalRContext();
			var value = context.Orders.Where(x=>x.Date == DateTime.Now.Date & x.Description== "Hesap Kapatıldı").Sum(x=> x.TotalPrice);
			return value;
		}

		public int TotalOrder()
		{
			using var context = new SignalRContext();
			var value = context.Orders.Count();
			return value;
		}
	}
}
