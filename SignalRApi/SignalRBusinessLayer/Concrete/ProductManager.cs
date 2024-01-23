using SignalRBusinessLayer.Abstract;
using SignalRDataAccessLayer.Abstract;
using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void TAdd(Product entity)
        {
            _productDal.Add(entity);
        }

        public void TDelete(Product entity)
        {
            _productDal.Delete(entity); 
        }

        public List<Product> TGetListAll()
        {
            return _productDal.GetListAll();
        }

        public Product TGetById(int id)
        {
            return _productDal.GetById(id); 
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }

        public List<Product> TGetProductListWithCategory()
        {
            return _productDal.GetProductListWithCategory();
        }

		public int TProductCount()
		{
            return _productDal.ProductCount();
		}
		public int TProductCountByCategoryNameHamburger()
		{
			return _productDal.ProductCountByCategoryNameHamburger();
		}

		public int TProductCountByCategoryNameIcecek()
		{
			return _productDal.ProductCountByCategoryNameIcecek();
		}

		public string TProductByMaxPrice()
		{
            return _productDal.ProductByMaxPrice();
		}

		public string TProductByMinPrice()
		{
            return _productDal.ProductByMinPrice();
		}

		public decimal TAvearageHamburgerPrice()
		{
            return _productDal.AvearageHamburgerPrice();
		}

		public decimal TProductPriceAvg()
		{
			return _productDal.ProductPriceAvg();
		}
	}
}
