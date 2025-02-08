using RealHouzing.DataAccessLayer.Abstract;
using RealHouzing.DataAccessLayer.Repository;
using RealHouzing.EntityLayer.Concrete;

namespace RealHouzing.DataAccessLayer.Entity_Framewrok;

public class EfProductDal:GenericRepository<Product>,IProductDal
{

}
