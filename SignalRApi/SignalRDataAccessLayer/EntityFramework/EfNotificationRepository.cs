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
	public class EfNotificationRepository:IGenericRepository<Notification>,INotificationDal
	{
		public EfNotificationRepository(SignalRContext context):base(context)
		{

		}

		public List<Notification> GetAllNotificationByFalse()
		{
			using var context = new SignalRContext();
			return context.Notifications.Where(x => x.Status == false).ToList();
		}

		public void NotificationChangeStatusByFalse(int id)
		{
			using var context = new SignalRContext();
			var value = context.Notifications.Where(x => x.NotificationID == id).FirstOrDefault();
			value.Status = false;
			context.SaveChanges();
		}

		public void NotificationChangeStatusByTrue(int id)
		{
			using var context = new SignalRContext();
			var value = context.Notifications.Where(x => x.NotificationID == id).FirstOrDefault();
			value.Status = true;
			context.SaveChanges();
		}

		public int NotificationCountByStatusFalse()
		{
			using var context = new SignalRContext();
			return context.Notifications.Where(x=>x.Status == false).Count();
		}
	}
}
