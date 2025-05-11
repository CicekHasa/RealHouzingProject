using RealHouzing.BusinessLayer.Abstract;
using RealHouzing.DataAccessLayer.Abstract;
using RealHouzing.EntityLayer.Concrete;

namespace RealHouzing.BusinessLayer.Concrete;

public class FeatureCardManager : IFeatureCardService
{
    private readonly IFeatureCardDal _featureCardDal;

    public FeatureCardManager(IFeatureCardDal featureCardDal)
    {
        _featureCardDal= featureCardDal;
    }

    public void TDelete(FeatureCard t)
    {
       _featureCardDal.Delete(t);
    }

    public FeatureCard TGetById(int id)
    {
       return _featureCardDal.GetById(id);
    }

    public List<FeatureCard> TGetList()
    {
        return _featureCardDal.GetList();
    }

    public void TInsert(FeatureCard t)
    {
        _featureCardDal.Insert(t);
    }

    public void TUpdate(FeatureCard t)
    {
       _featureCardDal.Update(t);
    }
}
