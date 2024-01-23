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
    public class EfTestimonialRepository:IGenericRepository<Testimonial>,ITestimonialDal
    {
        public EfTestimonialRepository(SignalRContext context) : base(context)
        {

        }
    }
}
