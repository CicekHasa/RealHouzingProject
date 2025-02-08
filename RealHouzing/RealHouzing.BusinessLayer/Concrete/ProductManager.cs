using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using RealHouzing.BusinessLayer.Abstract;
using RealHouzing.DataAccessLayer.Abstract;
using RealHouzing.EntityLayer.Concrete;

namespace RealHouzing.BusinessLayer.Concrete;

public class ProductManager : IProductService
{
    private readonly IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public void TDelete(Product t)
    {
        _productDal.Delete(t);
    }

    public Product TGetById(int id)
    {
        return _productDal.GetById(id);
    }

    public List<Product> TGetList()
    {
        return _productDal.GetList();
    }

    public void TInsert(Product t)
    {
        _productDal.Insert(t);
    }

    public void TUpdate(Product t)
    {
        _productDal.Update(t);
    }
}
