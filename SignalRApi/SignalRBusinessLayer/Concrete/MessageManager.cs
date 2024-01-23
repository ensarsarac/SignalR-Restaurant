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
	public class MessageManager : IMessageService
	{
		private readonly IMessageDal _messageDal;

		public MessageManager(IMessageDal messageDal)
		{
			_messageDal = messageDal;
		}

		public void TAdd(Message entity)
		{
			_messageDal.Add(entity);
		}

		public void TDelete(Message entity)
		{
			_messageDal.Delete(entity);
		}

		public Message TGetById(int id)
		{
			return _messageDal.GetById(id);
		}

		public List<Message> TGetListAll()
		{
			return _messageDal.GetListAll();
		}

		public void TUpdate(Message entity)
		{
			_messageDal.Update(entity);
		}
	}
}
