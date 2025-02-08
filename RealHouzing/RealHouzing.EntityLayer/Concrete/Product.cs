namespace RealHouzing.EntityLayer.Concrete;

public class Product
{
    public int ProductID { get; set; }
    public string ProductTitle { get; set; }
    public decimal ProductPrice { get; set; }
    public string ProductType{ get; set; }
    public string ProductAdress{ get; set; }
    public int BedRoomCount{ get; set; }
    public int BathCount{ get; set; }
    public int Square{ get; set; }
    public string CoverImageUrl { get; set; }
    //Category tablosu ile ilişkili bir tablo olacak
    public Category Category { get; set; }
    //Asp.Net Core 6.0 dan sonra ilişikili tablonun id sini oluşturmaya gerek yok otomatik algılıyor ama aşağı ekleyeceğim!
    public int CategoryID { get; set; }
}
