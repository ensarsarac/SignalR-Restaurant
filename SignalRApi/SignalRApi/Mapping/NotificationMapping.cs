using AutoMapper;
using SignalRDtoLayer.NotificationDto;
using SignalREntityLayer.Entities;

namespace SignalRWebApi.Mapping
{
	public class NotificationMapping : Profile
	{
		public NotificationMapping()
		{
			CreateMap<Notification, ResultNotificationDto>().ReverseMap();
			CreateMap<Notification, CreateNotificationDto>().ReverseMap();
			CreateMap<Notification, UpdateNotificationDto>().ReverseMap();
		}
	}
}
