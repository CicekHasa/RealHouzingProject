using Microsoft.EntityFrameworkCore;
using RealHouzing.DataAccessLayer.Abstract;
using RealHouzing.DataAccessLayer.Concrete;
using RealHouzing.DataAccessLayer.Repository;
using RealHouzing.EntityLayer.Concrete;

namespace RealHouzing.DataAccessLayer.Entity_Framewrok;

public class EfProductDal : GenericRepository<Product>, IProductDal
{
    public List<Product> GetProductsWithCategories()
    {
        using var context = new Context();
        var values = context.Products.Include(x => x.Category).ToList();
        return values;
    }
}
