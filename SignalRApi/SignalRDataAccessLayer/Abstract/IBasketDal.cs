using SignalREntityLayer.Entities;
using SignalRWebUI.Dtos.BasketDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDataAccessLayer.Abstract
{
    public interface IBasketDal:IGenericDal<Basket>
    {
        List<ResultBasketDtoWithInclude> GetBasketByMenuTableNumber(int id);
    }
}
