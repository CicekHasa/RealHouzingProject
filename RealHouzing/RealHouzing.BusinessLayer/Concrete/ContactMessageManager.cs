using RealHouzing.BusinessLayer.Abstract;
using RealHouzing.DataAccessLayer.Abstract;
using RealHouzing.EntityLayer.Concrete;
namespace RealHouzing.BusinessLayer.Concrete;

public class ContactMessageManager : IContactMessageService
{
    private readonly IContactMessageDal _contactMessageDal;

    public ContactMessageManager(IContactMessageDal contactMessageDal)
    {
        _contactMessageDal = contactMessageDal;
    }

    public void TDelete(ContactMessage t)
    {
        _contactMessageDal.Delete(t);
    }

    public ContactMessage TGetById(int id)
    {
        return _contactMessageDal.GetById(id);
    }

    public List<ContactMessage> TGetList()
    {
        return _contactMessageDal.GetList();
    }

    public void TInsert(ContactMessage t)
    {
        _contactMessageDal.Insert(t);
    }

    public void TUpdate(ContactMessage t)
    {
        _contactMessageDal.Update(t);
    }
}
