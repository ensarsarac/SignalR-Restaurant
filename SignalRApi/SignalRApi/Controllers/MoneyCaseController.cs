using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;

namespace SignalRWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoneyCaseController : ControllerBase
	{
		private readonly IMoneyCaseService _moneyCaseService;

		public MoneyCaseController(IMoneyCaseService moneyCaseService)
		{
			_moneyCaseService = moneyCaseService;
		}

		[HttpGet("SumMoneyCase")]
		public IActionResult SumMoneyCase()
		{
			return Ok(_moneyCaseService.TSumMoneyCase());
		}
	}
}
