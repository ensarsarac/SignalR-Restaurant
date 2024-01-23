using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.NotificationDto;
using SignalREntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationsController : ControllerBase
	{
		private readonly INotificationService _notificationService;
		private readonly IMapper _mapper;

		public NotificationsController(INotificationService notificationService, IMapper mapper)
		{
			_notificationService = notificationService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult NotificationList()
		{
			return Ok(_notificationService.TGetListAll());
		}

		[HttpGet("NotificationCountByStatusFalse")]
		public IActionResult NotificationCountByStatusFalse()
		{
			return Ok(_notificationService.TNotificationCountByStatusFalse());
		}

		[HttpGet("GetAllNotificationByFalse")]
		public IActionResult GetAllNotificationByFalse()
		{
			return Ok(_notificationService.TGetAllNotificationByFalse());
		}
		[HttpPost]
		public IActionResult CreateNotification(CreateNotificationDto model)
		{
			var value = _mapper.Map<Notification>(model);
			_notificationService.TAdd(value);
			return Ok("Bildirim eklendi");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteNotification(int id)
		{
			var value = _notificationService.TGetById(id);
			_notificationService.TDelete(value);
			return Ok("Bildirim Silindi");
		}
		[HttpPut]
		public IActionResult UpdateNotification(UpdateNotificationDto model)
		{
			var value = _mapper.Map<Notification>(model);
			_notificationService.TUpdate(value);
			return Ok("Kayıt Güncellendi");
		}
		[HttpGet("{id}")]
		public IActionResult GetByIdNotification(int id)
		{
			var value = _notificationService.TGetById(id);
			return Ok(value);
		}
		[HttpGet("NotificationChangeStatusByTrue")]
		public IActionResult NotificationChangeStatusByTrue(int id)
		{
			_notificationService.TNotificationChangeStatusByTrue(id);
			return Ok("Değişiklik yapıldı.");
		}
		[HttpGet("NotificationChangeStatusByFalse")]
		public IActionResult NotificationChangeStatusByFalse(int id)
		{
			_notificationService.TNotificationChangeStatusByFalse(id);
			return Ok("Değişiklik yapıldı.");
		}
	}
	
}
