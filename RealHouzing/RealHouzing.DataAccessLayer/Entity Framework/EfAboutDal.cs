using RealHouzing.DataAccessLayer.Abstract;
using RealHouzing.DataAccessLayer.Repository;
using RealHouzing.EntityLayer.Concrete;

namespace RealHouzing.DataAccessLayer.Entity_Framework;

public class EfAboutDal:GenericRepository<About>, IAboutDal
{
}
