using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusinessLayer.Abstract
{
    public interface IProductService:IGenericService<Product>
    {
        List<Product> TGetProductListWithCategory();
		int TProductCount();
		int TProductCountByCategoryNameHamburger();
		int TProductCountByCategoryNameIcecek();
		string TProductByMaxPrice();
		string TProductByMinPrice();
		decimal TAvearageHamburgerPrice();
		decimal TProductPriceAvg();
	}
}
