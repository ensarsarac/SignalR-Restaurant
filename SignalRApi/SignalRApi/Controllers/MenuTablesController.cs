using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.MenuTableDto;
using SignalREntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MenuTablesController : ControllerBase
	{
		private readonly IMenuTableService _menuTableService;
		private readonly IMapper _mapper;

		public MenuTablesController(IMenuTableService menuTableService, IMapper mapper)
		{
			_menuTableService = menuTableService;
			_mapper = mapper;
		}

		[HttpGet("MenuTablesCount")]
		public IActionResult MenuTablesCount()
		{
			return Ok(_menuTableService.TMenuTableCount());
		}
		[HttpGet]
		public IActionResult MenuTableList()
		{
			var values = _mapper.Map<List<ResultMenuTableDto>>(_menuTableService.TGetListAll());
			return Ok(values);
		}
		[HttpGet("MenuTableById")]
		public IActionResult MenuTableById(int id)
		{
			var values = _mapper.Map<ResultMenuTableDto>(_menuTableService.TGetById(id));
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateMenuTable(CreateMenuTableDto model)
		{
			var value = _mapper.Map<MenuTable>(model);
			_menuTableService.TAdd(value);
			return Ok("Başarılı bir şekilde eklendi.");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteMenuTable(int id)
		{
			var value = _menuTableService.TGetById(id);
			_menuTableService.TDelete(value);
			return Ok("Kayıt başarılı bir şekilde silindi");
		}
		[HttpPut]
		public IActionResult UpdateMenuTable(UpdateMenuTableDto model)
		{
			var value = _mapper.Map<MenuTable>(model);
			_menuTableService.TUpdate(value);
			return Ok("Kayıt başarılı bir şekilde güncellendi.");
		}

	}
}
