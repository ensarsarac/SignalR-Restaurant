using Microsoft.EntityFrameworkCore;
using SignalRDataAccessLayer.Abstract;
using SignalRDataAccessLayer.Concrete;
using SignalRDataAccessLayer.Repositories;
using SignalREntityLayer.Entities;
using SignalRWebUI.Dtos.BasketDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDataAccessLayer.EntityFramework
{
    public class EfBasketRepository:IGenericRepository<Basket>,IBasketDal
    {
        public EfBasketRepository(SignalRContext context):base(context)
        {

        }

        public List<ResultBasketDtoWithInclude> GetBasketByMenuTableNumber(int id)
        {
            using var context = new SignalRContext();
            var values = context.Baskets.Where(x => x.AppUserID == id).Include(y => y.Product).Select(z=> new ResultBasketDtoWithInclude
            {
                BasketID = z.BasketID,
                Count= z.Count,
                MenuTableID= z.MenuTableID, 
                Price= z.Price, 
                TotalPrice= z.TotalPrice,
                ProductName=z.Product.ProductName,
            }).ToList();
			return values;
        }

	
	}
}
