using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.CategoryDto;
using SignalRDtoLayer.SliderDto;
using SignalREntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public SliderController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult SliderList()
        {
            var values = _mapper.Map<ResultSliderDto>(_sliderService.TGetListAll().FirstOrDefault());
            return Ok(values);
        }
		[HttpPost]
		public IActionResult CreateSlider(CreateSliderDto model)
		{
			var value = _mapper.Map<Slider>(model);
			_sliderService.TAdd(value);
			return Ok("Başarılı bir şekilde eklendi.");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteSlider(int id)
		{
			var value = _sliderService.TGetById(id);
			_sliderService.TDelete(value);
			return Ok("Kayıt başarılı bir şekilde silindi");
		}
		[HttpPut]
		public IActionResult UpdateSlider(UpdateSliderDto model)
		{
			var value = _mapper.Map<Slider>(model);
			_sliderService.TUpdate(value);
			return Ok("Kayıt başarılı bir şekilde güncellendi.");
		}
	}
}
