using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.DiscountDto;
using SignalREntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {

        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var values = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto model)
        {
            model.Status = false;
            var value = _mapper.Map<Discount>(model);
            _discountService.TAdd(value);
            return Ok("Başarılı bir şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            _discountService.TDelete(value);
            return Ok("Kayıt başarılı bir şekilde silindi");
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto model)
        {
            var value = _mapper.Map<Discount>(model);
            _discountService.TUpdate(value);
            return Ok("Kayıt başarılı bir şekilde güncellendi.");
        }
        [HttpGet("GetDiscountWithId")]
        public IActionResult GetDiscountWithId(int id)
        {
            var value = _mapper.Map<GetDiscountDto>(_discountService.TGetById(id));
            return Ok(value);
        }

		[HttpGet("DiscountChangeStatus")]
		public IActionResult DiscountChangeStatus(int id)
		{
             _discountService.TDiscountChangeStatus(id);
			return Ok("İndirim Aktif Edildi.");
		}

		[HttpGet("DiscountChangeStatusFalse")]
		public IActionResult DiscountChangeStatusFalse(int id)
		{
			_discountService.TDiscountChangeStatusFalse(id);
			return Ok("İndirim İptal Edildi.");
		}

	}
}
