using RealHouzing.BusinessLayer.Abstract;
using RealHouzing.DataAccessLayer.Abstract;
using RealHouzing.EntityLayer.Concrete;

namespace RealHouzing.BusinessLayer.Concrete;

public class ServiceCategoriesManager : IServiceCategoriesService
{
    private readonly IServiceCategoiresDal _serviceCategoiresDal;
    public ServiceCategoriesManager(IServiceCategoiresDal serviceCategoiresDal)
    {
        _serviceCategoiresDal= serviceCategoiresDal;
    }
    public void TDelete(ServiceCategories t)
    {
        _serviceCategoiresDal.Delete(t);
    }

    public ServiceCategories TGetById(int id)
    {
        return _serviceCategoiresDal.GetById(id);
    }

    public List<ServiceCategories> TGetList()
    {
        return _serviceCategoiresDal.GetList();
    }

    public void TInsert(ServiceCategories t)
    {
        _serviceCategoiresDal.Insert(t);
    }

    public void TUpdate(ServiceCategories t)
    {
        _serviceCategoiresDal.Update(t);
    }
}
