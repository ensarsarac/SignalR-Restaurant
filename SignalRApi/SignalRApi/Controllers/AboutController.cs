using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.AboutDto;
using SignalREntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper =mapper;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _mapper.Map<ResultAboutDto>(_aboutService.TGetListAll().FirstOrDefault());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto model)
        {
            var value = _mapper.Map<About>(model);
            _aboutService.TAdd(value);
            return Ok("Hakkımda kısmı başarılı bir şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            _aboutService.TDelete(value);
            return Ok("Hakkımda kısmı başarılı bir şekilde silindi.");
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto model)
        {
            var value = _mapper.Map<About>(model);
            _aboutService.TUpdate(value);            
            return Ok("Hakkımda kısmı başarılı bir şekilde güncellendi.");
        }
        [HttpGet("GetAboutWithId")]
        public IActionResult GetAboutWithId(int id)
        {
            var value = _mapper.Map<GetAboutDto>(_aboutService.TGetById(id));
            return Ok(value);
        }

    }
}
