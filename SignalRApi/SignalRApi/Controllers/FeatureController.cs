using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.FeatureDto;
using SignalREntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService FeatureService, IMapper mapper)
        {
            _featureService = FeatureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _mapper.Map<ResultFeatureDto>(_featureService.TGetListAll().FirstOrDefault());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto model)
        {
            var value = _mapper.Map<Feature>(model);
            _featureService.TAdd(value);
            return Ok("Başarılı bir şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var value = _featureService.TGetById(id);
            _featureService.TDelete(value);
            return Ok("Kayıt başarılı bir şekilde silindi");
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto model)
        {
            var value = _mapper.Map<Feature>(model);
            _featureService.TUpdate(value);
            return Ok("Kayıt başarılı bir şekilde güncellendi.");
        }
        [HttpGet("GetFeatureWithId")]
        public IActionResult GetFeatureWithId(int id)
        {
            var value = _mapper.Map<GetFeatureDto>(_featureService.TGetById(id));
            return Ok(value);
        }
    }
}
