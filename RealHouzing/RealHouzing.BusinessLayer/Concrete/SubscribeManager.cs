using RealHouzing.BusinessLayer.Abstract;
using RealHouzing.DataAccessLayer.Abstract;
using RealHouzing.EntityLayer.Concrete;

namespace RealHouzing.BusinessLayer.Concrete;

public class SubscribeManager : ISubscribeService
{
    private readonly ISubscribeDal _subscribeDal;

    public SubscribeManager(ISubscribeDal subscribeDal)
    {
        _subscribeDal= subscribeDal;
    }

    public void TDelete(Subscribe t)
    {
        _subscribeDal.Delete(t);
    }

    public Subscribe TGetById(int id)
    {
        return _subscribeDal.GetById(id);
    }

    public List<Subscribe> TGetList()
    {
        return _subscribeDal.GetList();
    }

    public void TInsert(Subscribe t)
    {
        _subscribeDal.Insert(t);
    }

    public void TUpdate(Subscribe t)
    {
        _subscribeDal.Update(t);
    }
}
