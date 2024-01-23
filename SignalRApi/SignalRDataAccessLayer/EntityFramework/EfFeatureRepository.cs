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
    public class EfFeatureRepository:IGenericRepository<Feature>,IFeatureDal
    {
        public EfFeatureRepository(SignalRContext context) : base(context)
        {

        }
    }
}
