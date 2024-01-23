using AutoMapper;
using SignalRDtoLayer.BasketDto;
using SignalRDtoLayer.BookingDto;
using SignalREntityLayer.Entities;
using SignalRWebUI.Dtos.BasketDtos;

namespace SignalRWebApi.Mapping
{
	public class BasketMapping : Profile
	{
		public BasketMapping()
		{
			CreateMap<Basket, ResultBasketDtoWithInclude>().ReverseMap();
			CreateMap<Basket, CreateBasketDto>().ReverseMap();
		}
	}
}
