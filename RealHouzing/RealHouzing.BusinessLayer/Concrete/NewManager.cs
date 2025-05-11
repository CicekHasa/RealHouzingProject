using RealHouzing.BusinessLayer.Abstract;
using RealHouzing.DataAccessLayer.Abstract;
using RealHouzing.EntityLayer.Concrete;

namespace RealHouzing.BusinessLayer.Concrete;

public class NewManager : INewService
{
    private readonly INewDal _newDal;

    public NewManager(INewDal newDal)
    {
        _newDal = newDal;
    }

    public void TDelete(New t)
    {
        _newDal.Delete(t);
    }

    public New TGetById(int id)
    {
        return _newDal.GetById(id);
    }

    public List<New> TGetList()
    {
        return _newDal.GetList();
    }

    public void TInsert(New t)
    {
        _newDal.Insert(t);
    }

    public void TUpdate(New t)
    {
        _newDal.Update(t);
    }
}
