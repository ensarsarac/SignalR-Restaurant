using SignalREntityLayer.Entities;

namespace SignalRDataAccessLayer.Abstract
{
    public interface IProductDal:IGenericDal<Product>
    {
        List<Product> GetProductListWithCategory();
        int ProductCount();
		int ProductCountByCategoryNameHamburger();
		int ProductCountByCategoryNameIcecek();
        string ProductByMaxPrice();
        string ProductByMinPrice();
        decimal AvearageHamburgerPrice();
        decimal ProductPriceAvg();
	}
}
