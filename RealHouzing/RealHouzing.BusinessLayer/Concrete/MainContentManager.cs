using RealHouzing.BusinessLayer.Abstract;
using RealHouzing.DataAccessLayer.Abstract;
using RealHouzing.EntityLayer.Concrete;

namespace RealHouzing.BusinessLayer.Concrete;

public class MainContentManager : IMainContentService
{
    private readonly IMainContentDal _mainContentDal;
    public MainContentManager(IMainContentDal mainContentDal)
    {
        _mainContentDal= mainContentDal;
    }
    public void TDelete(MainContent t)
    {
        _mainContentDal.Delete(t);
    }

    public MainContent TGetById(int id)
    {
        return _mainContentDal.GetById(id);
    }

    public List<MainContent> TGetList()
    {
        return _mainContentDal.GetList();
    }

    public void TInsert(MainContent t)
    {
       _mainContentDal.Insert(t);
    }

    public void TUpdate(MainContent t)
    {
        _mainContentDal.Update(t);
    }
}
