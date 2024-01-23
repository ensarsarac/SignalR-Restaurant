using SignalREntityLayer.Entities;
using SignalRWebUI.Dtos.BasketDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusinessLayer.Abstract
{
    public interface IBasketService:IGenericService<Basket>
    {
        List<ResultBasketDtoWithInclude> TGetBasketByMenuTableNumber(int id);
    }
}
