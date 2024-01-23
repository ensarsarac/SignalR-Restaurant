using Microsoft.EntityFrameworkCore;
using SignalRDataAccessLayer.Abstract;
using SignalRDataAccessLayer.Concrete;
using SignalRDataAccessLayer.Repositories;
using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDataAccessLayer.EntityFramework
{
    public class EfProductRepository:IGenericRepository<Product>,IProductDal
    {
        public EfProductRepository(SignalRContext context) : base(context)
        {

        }

		public decimal AvearageHamburgerPrice()
		{
			using var context = new SignalRContext();
			var value = context.Products.Where(x=>x.CategoryID == (context.Categories.Where(y=>y.Name=="Hamburger").Select(z=>z.CategoryID).FirstOrDefault())).Average(x=>x.Price);
			return value;
		}

		public List<Product> GetProductListWithCategory()
        {
            SignalRContext context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).ToList();
            return values;
        }

		public string ProductByMaxPrice()
		{
			using var context = new SignalRContext();
			var values = context.Products.Where(x => x.Price == (context.Products.Max(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
			return values;
		}

		public string ProductByMinPrice()
		{
			using var context = new SignalRContext();
			var values = context.Products.Where(x => x.Price == (context.Products.Min(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
			return values;
		}

		public int ProductCount()
		{
			using var context = new SignalRContext();
            return context.Products.Count();
		}
		public int ProductCountByCategoryNameHamburger()
		{
			using var context = new SignalRContext();
			var values = context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.Name == "Hamburger").Select(z => z.CategoryID).FirstOrDefault())).Count();
			return values;
		}

		public int ProductCountByCategoryNameIcecek()
		{
			using var context = new SignalRContext();
			var values = context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.Name == "İçecek").Select(z => z.CategoryID).FirstOrDefault())).Count();
			return values;
		}

		public decimal ProductPriceAvg()
		{
			using var context = new SignalRContext();
			var value = context.Products.Average(x => x.Price);
			return value;
		}
	}
}
