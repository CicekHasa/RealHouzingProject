namespace RealHouzing.EntityLayer.Concrete;

public class Category
{
    public int CategoryID { get; set; }
    public string CategoryName { get; set; }
    //Product sınıfı ile ilişkili bir tablo
    public List<Product> Products { get; set; }
}

