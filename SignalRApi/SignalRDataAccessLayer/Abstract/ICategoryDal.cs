using SignalREntityLayer.Entities;

namespace SignalRDataAccessLayer.Abstract
{
    public interface ICategoryDal:IGenericDal<Category>
    {
         int CategoryCount();
         int ActiveCategoryCount();
         int PassiveCategoryCount();
        
    }
}
