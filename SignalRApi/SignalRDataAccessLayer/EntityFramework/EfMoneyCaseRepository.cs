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
	public class EfMoneyCaseRepository: IGenericRepository<MoneyCase>,IMoneyCaseDal
	{
		public EfMoneyCaseRepository(SignalRContext context):base(context)
		{
				
		}

		public decimal SumMoneyCase()
		{
			using var context= new SignalRContext();
			var value = context.MoneyCases.Select(x=>x.TotalAmount).FirstOrDefault();
			return value;
		}
	}
}
