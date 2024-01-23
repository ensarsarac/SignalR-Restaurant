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
    public class EfSliderRepository:IGenericRepository<Slider>,ISliderDal
    {
        public EfSliderRepository(SignalRContext context):base(context)
        {

        }
    }
}
