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
    public class EfDiscountRepository:IGenericRepository<Discount>,IDiscountDal
    {
        public EfDiscountRepository(SignalRContext context) : base(context)
        {

        }

		public void DiscountChangeStatus(int id)
		{
			using var context = new SignalRContext();
			var value = context.Discounts.Find(id);
			value.Status = true;
			context.SaveChanges();
		}

		public void DiscountChangeStatusFalse(int id)
		{
			using var context = new SignalRContext();
			var value = context.Discounts.Find(id);
			value.Status = false;
			context.SaveChanges();
		}
	}
}
