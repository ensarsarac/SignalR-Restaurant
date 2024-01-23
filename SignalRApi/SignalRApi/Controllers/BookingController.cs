using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.BookingDto;
using SignalREntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _mapper.Map<List<ResultBookingDto>>(_bookingService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto model)
        {
            var value = _mapper.Map<Booking>(model);
            _bookingService.TAdd(value);
            return Ok("Başarılı bir şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            _bookingService.TDelete(value);
            return Ok("Kayıt başarılı bir şekilde silindi");
        }
        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto model)
        {
            var value = _mapper.Map<Booking>(model);
            _bookingService.TUpdate(value);
            return Ok("Kayıt başarılı bir şekilde güncellendi.");
        }
        [HttpGet("GetBookingWithId")]
        public IActionResult GetBookingWithId(int id)
        {
            var value = _mapper.Map<GetBookingDto>(_bookingService.TGetById(id));
            return Ok(value);
        }

		[HttpGet("BookingApproved")]
		public IActionResult BookingApproved(int id)
		{
            _bookingService.TBookingApproved(id);
			return Ok("Rezervasyon Onaylandı");
		}
		[HttpGet("BookingCanceled")]
		public IActionResult BookingCanceled(int id)
		{
			_bookingService.TBookingCanceled(id);
			return Ok("Rezervasyon İptal Edildi");
		}

	}
}
