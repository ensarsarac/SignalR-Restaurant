using AutoMapper;
using SignalRDtoLayer.MessageDto;
using SignalREntityLayer.Entities;

namespace SignalRWebApi.Mapping
{
	public class MessageMapping : Profile
	{
		public MessageMapping()
		{
			CreateMap<Message, ResultMessageDto>().ReverseMap();
			CreateMap<Message, CreateMessageDto>().ReverseMap();
			CreateMap<Message, UpdateMessageDto>().ReverseMap();
		}
	}
}
