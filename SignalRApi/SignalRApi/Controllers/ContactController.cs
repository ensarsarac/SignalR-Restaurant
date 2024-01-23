using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.ContactDto;
using SignalREntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _mapper.Map<ResultContactDto>(_contactService.TGetListAll().FirstOrDefault());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto model)
        {
            var value = _mapper.Map<Contact>(model);
            _contactService.TAdd(value);
            return Ok("Başarılı bir şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetById(id);
            _contactService.TDelete(value);
            return Ok("Kayıt başarılı bir şekilde silindi");
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto model)
        {
            var value = _mapper.Map<Contact>(model);
            _contactService.TUpdate(value);
            return Ok("Kayıt başarılı bir şekilde güncellendi.");
        }
        [HttpGet("GetContactWithId")]
        public IActionResult GetContactWithId(int id)
        {
            var value = _mapper.Map<GetContactDto>(_contactService.TGetById(id));
            return Ok(value);
        }
    }
}
