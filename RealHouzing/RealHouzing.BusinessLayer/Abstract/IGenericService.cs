namespace RealHouzing.BusinessLayer.Abstract;

public interface IGenericService<T> where T : class
{
    void TInsert(T t);
    void TUpdate(T t);
    void TDelete(T t);
    T TGetById(int id);
    List<T> TGetList();
}
