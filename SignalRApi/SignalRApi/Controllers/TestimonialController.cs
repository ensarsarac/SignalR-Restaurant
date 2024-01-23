using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.TestimonialDto;
using SignalREntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto model)
        {
            var value = _mapper.Map<Testimonial>(model);
            _testimonialService.TAdd(value);
            return Ok("Başarılı bir şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            _testimonialService.TDelete(value);
            return Ok("Kayıt başarılı bir şekilde silindi");
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto model)
        {
            var value = _mapper.Map<Testimonial>(model);
            _testimonialService.TUpdate(value);
            return Ok("Kayıt başarılı bir şekilde güncellendi.");
        }
        [HttpGet("GetTestimonialWithId")]
        public IActionResult GetTestimonialWithId(int id)
        {
            var value = _mapper.Map<GetTestimonialDto>(_testimonialService.TGetById(id));
            return Ok(value);
        }
    }
}
