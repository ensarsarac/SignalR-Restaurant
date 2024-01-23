using AutoMapper;
using SignalRDtoLayer.MenuTableDto;
using SignalREntityLayer.Entities;

namespace SignalRWebApi.Mapping
{
	public class MenuTableMapping : Profile
	{
		public MenuTableMapping()
		{
			CreateMap<MenuTable,ResultMenuTableDto>().ReverseMap();
			CreateMap<MenuTable,CreateMenuTableDto>().ReverseMap();
			CreateMap<MenuTable,UpdateMenuTableDto>().ReverseMap();
		}
	}
}
