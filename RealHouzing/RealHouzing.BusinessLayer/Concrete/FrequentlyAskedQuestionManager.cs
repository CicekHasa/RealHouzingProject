using RealHouzing.BusinessLayer.Abstract;
using RealHouzing.DataAccessLayer.Abstract;
using RealHouzing.EntityLayer.Concrete;

namespace RealHouzing.BusinessLayer.Concrete;

public class FrequentlyAskedQuestionManager : IFrequentlyAskedQuestionService
{
    private readonly IFrequentlyAskedQuestionDal _frequentlyAskedQuestionDal;

    public FrequentlyAskedQuestionManager(IFrequentlyAskedQuestionDal frequentlyAskedQuestionDal)
    {
        _frequentlyAskedQuestionDal = frequentlyAskedQuestionDal;
    }

    public void TDelete(FrequentlyAskedQuestion t)
    {
        _frequentlyAskedQuestionDal.Delete(t);
    }

    public FrequentlyAskedQuestion TGetById(int id)
    {
        return _frequentlyAskedQuestionDal.GetById(id);
    }

    public List<FrequentlyAskedQuestion> TGetList()
    {
        return _frequentlyAskedQuestionDal.GetList();
    }

    public void TInsert(FrequentlyAskedQuestion t)
    {
        _frequentlyAskedQuestionDal.Insert(t);
    }

    public void TUpdate(FrequentlyAskedQuestion t)
    {
        _frequentlyAskedQuestionDal.Update(t);
    }
}
