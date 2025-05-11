using RealHouzing.BusinessLayer.Abstract;
using RealHouzing.DataAccessLayer.Abstract;
using RealHouzing.EntityLayer.Concrete;

namespace RealHouzing.BusinessLayer.Concrete;

public class ReviewManger : IReviewService
{

    private readonly IReviewDal _reviewDal;

    public ReviewManger(IReviewDal reviewDal)
    {
        _reviewDal= reviewDal;
    }
    public void TDelete(Review t)
    {
       _reviewDal.Delete(t);
    }

    public Review TGetById(int id)
    {
        return _reviewDal.GetById(id);
    }

    public List<Review> TGetList()
    {
        return _reviewDal.GetList();
    }

    public void TInsert(Review t)
    {
       _reviewDal.Insert(t);
    }

    public void TUpdate(Review t)
    {
        _reviewDal.Update(t);
    }
}
