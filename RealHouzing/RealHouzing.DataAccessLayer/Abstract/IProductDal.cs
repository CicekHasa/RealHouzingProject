using RealHouzing.EntityLayer.Concrete;
namespace RealHouzing.DataAccessLayer.Abstract;

public interface IProductDal : IGenericDal<Product>
{
    List<Product> GetProductsWithCategories();
}

