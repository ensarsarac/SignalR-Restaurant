using AutoMapper.Internal;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BookingDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class AdminBookingController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public AdminBookingController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7037/api/Booking");
			if (responseMessage.IsSuccessStatusCode)
			{
				var readData = await responseMessage.Content.ReadAsStringAsync();
				var jsonData = JsonConvert.DeserializeObject<List<ResultBookingdto>>(readData);
				return View(jsonData);
			}
			return View();
		}
		[HttpGet]
		public IActionResult CreateBooking()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateBooking(CreateBookingDto model)
		{
			model.Status = "Rezervasyon Alındı";
			string mailContent = $"{model.Date} tarihli rezervasyonunuz alınmıştır sizi bilgilendireceğiz.";
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(model);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7037/api/Booking",content);
			if (responseMessage.IsSuccessStatusCode)
			{
				sendMail(model.Mail, mailContent);
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> DeleteBooking(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7037/api/Booking/{id}");
			if(responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> UpdateBooking(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7037/api/Booking/GetBookingWithId?id={id}");
			if(responseMessage.IsSuccessStatusCode)
			{
				var readData = await responseMessage.Content.ReadAsStringAsync();
				var jsonData = JsonConvert.DeserializeObject<UpdateBookingDto>(readData);
				return View(jsonData);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateBooking(UpdateBookingDto model)
		{
			model.Status = "Rezervasyon Alındı";
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(model);
			StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage = await client.PutAsync($"https://localhost:7037/api/Booking",content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> BookingApproved(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7037/api/Booking/BookingApproved?id={id}");
			var responseMessage2 = await client.GetAsync($"https://localhost:7037/api/Booking/GetBookingWithId?id={id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var readData = await responseMessage2.Content.ReadAsStringAsync();
				var jsonData = JsonConvert.DeserializeObject<ResultBookingdto>(readData);
				string content = $"Sayın {jsonData.Name}, {jsonData.Date.ToShortDateString()} tarihli rezervasyonunuz onaylanmıştır.";
				sendMail(jsonData.Mail, content);
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> BookingCanceled(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7037/api/Booking/BookingCanceled?id={id}");
			var responseMessage2 = await client.GetAsync($"https://localhost:7037/api/Booking/GetBookingWithId?id={id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var readData = await responseMessage2.Content.ReadAsStringAsync();
				var jsonData = JsonConvert.DeserializeObject<ResultBookingdto>(readData);
				string content = $"Sayın {jsonData.Name}, {jsonData.Date.ToShortDateString()} tarihli rezervasyonunuz iptal edilmiştir.";
				sendMail(jsonData.Mail, content);
				return RedirectToAction("Index");
			}
			return View();
		}


		public void sendMail(string mail, string content)
		{
			var email = new MimeMessage();
			MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "ensar.src94@gmail.com");
			email.From.Add(mailboxAddressFrom);

			MailboxAddress mailboxAddressTo = new MailboxAddress("Rezervasyon Bilgileri", mail);
			email.To.Add(mailboxAddressTo);

			email.Subject = "Rezervasyon Durumu";
			email.Body = new TextPart(TextFormat.Html) { Text = content };

			var smtp = new MailKit.Net.Smtp.SmtpClient();
			smtp.Connect("smtp.gmail.com", 587, false);
			smtp.Authenticate("ensar.src94@gmail.com", "eqjq wijb bsxs cgaq");
			smtp.Send(email);
			smtp.Disconnect(true);
		}

	}
}
