using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDataAccessLayer.Abstract
{
    public interface IDiscountDal:IGenericDal<Discount>
    {
        void DiscountChangeStatus(int id);
        void DiscountChangeStatusFalse(int id);
    }
}
