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
    public class EfBookingRepository:IGenericRepository<Booking>,IBookingDal
    {
        public EfBookingRepository(SignalRContext context) : base(context)
        {

        }

		public void BookingApproved(int id)
		{
			using var context = new SignalRContext();
			var value = context.Bookings.Find(id);
			value.Status = "Rezervasyon Onaylandı";
			context.SaveChanges();
		}

		public void BookingCanceled(int id)
		{
			using var context = new SignalRContext();
			var value = context.Bookings.Find(id);
			value.Status = "Rezervasyon İptal Edildi";
			context.SaveChanges();
		}
	}
}
