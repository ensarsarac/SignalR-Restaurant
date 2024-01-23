using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.MessageDto;
using SignalREntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessageController : ControllerBase
	{
		private readonly IMessageService _messageService;
		private readonly IMapper _mapper;

		public MessageController(IMessageService messageService, IMapper mapper)
		{
			_messageService = messageService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult MessageList()
		{
			var values = _mapper.Map<List<ResultMessageDto>>(_messageService.TGetListAll());
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateMessage(CreateMessageDto model)
		{
			var value = _mapper.Map<Message>(model);
			_messageService.TAdd(value);
			return Ok("Başarılı bir şekilde eklendi.");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteMessage(int id)
		{
			var value = _messageService.TGetById(id);
			_messageService.TDelete(value);
			return Ok("Kayıt başarılı bir şekilde silindi");
		}
		[HttpPut]
		public IActionResult UpdateMessage(UpdateMessageDto model)
		{
			var value = _mapper.Map<Message>(model);
			_messageService.TUpdate(value);
			return Ok("Kayıt başarılı bir şekilde güncellendi.");
		}
		[HttpGet("{id}")]
		public IActionResult GetMessageWithId(int id)
		{
			var value = _mapper.Map<ResultMessageDto>(_messageService.TGetById(id));
			return Ok(value);
		}
	
	}
}
