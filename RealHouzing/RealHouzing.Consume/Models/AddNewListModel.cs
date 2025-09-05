namespace RealHouzing.Consume.Models;

public class AddNewListModel
{
    public string NewTitle { get; set; }
    public string NewDescription { get; set; }
    public string NewImageUrl { get; set; }
    public string AuthorName { get; set; }
    public string AuthorImage { get; set; }
    public DateTime PublishDate { get; set; }
}
