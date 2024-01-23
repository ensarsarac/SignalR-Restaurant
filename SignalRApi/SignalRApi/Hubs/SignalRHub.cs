using Microsoft.AspNetCore.SignalR;
using SignalRBusinessLayer.Abstract;
using SignalRDataAccessLayer.Abstract;
using SignalRDataAccessLayer.Concrete;
using SignalRDataAccessLayer.EntityFramework;
using System.Text.Json.Serialization;

namespace SignalRWebApi.Hubs
{
	public class SignalRHub : Hub
	{
		SignalRContext context = new SignalRContext();
		private readonly ICategoryService _categoryService;
		private readonly IProductService _productService;
		private readonly IOrderService _orderService;
		private readonly IMoneyCaseService _moneyCaseService;
		private readonly IMenuTableService _menuTableService;
		private readonly IBookingService _bookingService;
		private readonly INotificationService _notificationService;

		public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
		{
			_categoryService = categoryService;
			_productService = productService;
			_orderService = orderService;
			_moneyCaseService = moneyCaseService;
			_menuTableService = menuTableService;
			_bookingService = bookingService;
			_notificationService = notificationService;
		}
		public static int clientCount { get; set; } = 0;

		public async Task SendStatistic()
		{
			var value = _categoryService.TCategoryCount();
			var value2 = _categoryService.TActiveCategoryCount();
			var value3 = _categoryService.TPassiveCategoryCount();
			await Clients.All.SendAsync("ReceiveCategoryCount",value);
			await Clients.All.SendAsync("ReceiveActiveCategoryCount", value2);
			await Clients.All.SendAsync("ReceivePassiveCategoryCount", value3);

			//product statistic
			var productvalue = _productService.TProductCount();
			await Clients.All.SendAsync("ReceiveProductCount", productvalue);
			var productvalue1 = _productService.TProductCountByCategoryNameHamburger();
			await Clients.All.SendAsync("ReceiveHamburgerCount", productvalue1);
			var productvalue2 = _productService.TProductCountByCategoryNameIcecek();
			await Clients.All.SendAsync("ReceiveDrinkCount", productvalue2);
			var productvalue3 = _productService.TProductPriceAvg();
			await Clients.All.SendAsync("ProductPriceAvg", productvalue3);
			var productvalue4 = _productService.TProductByMaxPrice();
			await Clients.All.SendAsync("MaxPriceProduct", productvalue4);
			var productvalue5 = _productService.TProductByMinPrice();
			await Clients.All.SendAsync("MinPriceProduct", productvalue5);
			var productvalue6 = _productService.TAvearageHamburgerPrice();
			await Clients.All.SendAsync("AvearageHamburgerPrice", productvalue6);

			//order
			var ordervalue = _orderService.TTotalOrder();
			await Clients.All.SendAsync("TotalOrder", ordervalue);
			var ordervalue1 = _orderService.TActiveOrderCount();
			await Clients.All.SendAsync("ActiveTotalOrder", ordervalue1);
			var ordervalue2 = _orderService.TLastOrderPrice();
			await Clients.All.SendAsync("LastOrderPrice", ordervalue2.ToString("0.00")+" ₺");
			var ordervalue3 = _moneyCaseService.TSumMoneyCase();
			await Clients.All.SendAsync("SumMoneyCase", ordervalue3.ToString("0.00") + " ₺");
			var ordervalue4 = _orderService.TTodayTotalPrice();
			await Clients.All.SendAsync("TodayTotalPrice", ordervalue4.ToString("0.00") + " ₺");
			//menu table
			var menutablecount = _menuTableService.TMenuTableCount();
			await Clients.All.SendAsync("MenuTableCount", menutablecount);

		}
	
		public async Task DashboardStatistic()
		{
			var moneyCase = _moneyCaseService.TSumMoneyCase();
			await Clients.All.SendAsync("ReceiverDashboardStatistic", moneyCase.ToString("0.00")+" ₺");
			var activeOrder = _orderService.TActiveOrderCount();
			await Clients.All.SendAsync("ActiveOrderCount", activeOrder);
			var menuTable = _menuTableService.TMenuTableCount();
			await Clients.All.SendAsync("MenuTableCount", menuTable);
			var menutableprogress = _menuTableService.TMenuTableCount();
			await Clients.All.SendAsync("MenuTableProgress", menutableprogress);
			var productavgprice = _productService.TProductPriceAvg();
			await Clients.All.SendAsync("ProductAvg	", productavgprice);
		}
	
		public async Task GetBookingList()
		{
			var value = _bookingService.TGetListAll();
			await Clients.All.SendAsync("ReceiverBookingList", value);
		}

		public async Task SendNotification()
		{
			var value = _notificationService.TNotificationCountByStatusFalse();
			await Clients.All.SendAsync("NotificationCountByStatusFalse", value);

			var value2 = _notificationService.TNotificationCountByStatusFalse();
			await Clients.All.SendAsync("NotificationCountByStatusFalse2", value2);

			var values = _notificationService.TGetAllNotificationByFalse();
			await Clients.All.SendAsync("GetAllNotificationByFalse", values);
		}

		public async Task MenuTableStatus()
		{
			var values = _menuTableService.TGetListAll();
			await Clients.All.SendAsync("ReceiverMenuTableStatus", values);
		}
		
		public async Task SendMessage(string user,string message)
		{
			await Clients.All.SendAsync("ReceiveMessage",user,message);
		}

		public override async Task OnConnectedAsync()
		{
			clientCount++;
			await Clients.All.SendAsync("ReceiveClientCount", clientCount);
			await base.OnConnectedAsync();
		}
		public override async Task OnDisconnectedAsync(Exception? exception)
		{
			clientCount--;
			await Clients.All.SendAsync("ReceiveClientCount", clientCount);
			await base.OnDisconnectedAsync(exception);
		}

	}
}
