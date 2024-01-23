using SignalREntityLayer.Entities;

namespace SignalRWebUI.Dtos.BasketDtos
{
    public class ResultBasketDtoWithInclude
    {
        public int BasketID { get; set; }
        public decimal Price { get; set; }
        public decimal Count { get; set; }
        public decimal TotalPrice { get; set; }
        public string ProductName{ get; set; }
        public int MenuTableID { get; set; }
		public int AppUserID { get; set; }
	}
}
