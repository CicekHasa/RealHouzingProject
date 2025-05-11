using RealHouzing.BusinessLayer.Abstract;
using RealHouzing.DataAccessLayer.Abstract;
using RealHouzing.EntityLayer.Concrete;

namespace RealHouzing.BusinessLayer.Concrete;

public class CompanyValueManager : ICompanyValueService
{
    private readonly ICompanyValueDal _companyValueDal;

    public CompanyValueManager(ICompanyValueDal companyValueDal)
    {
        _companyValueDal = companyValueDal;
    }

    public void TDelete(CompanyValue t)
    {
        _companyValueDal.Delete(t);
    }

    public CompanyValue TGetById(int id)
    {
        return _companyValueDal.GetById(id);
    }

    public List<CompanyValue> TGetList()
    {
        return _companyValueDal.GetList();
    }

    public void TInsert(CompanyValue t)
    {
        _companyValueDal.Insert(t);
    }

    public void TUpdate(CompanyValue t)
    {
        _companyValueDal.Update(t);
    }
}
