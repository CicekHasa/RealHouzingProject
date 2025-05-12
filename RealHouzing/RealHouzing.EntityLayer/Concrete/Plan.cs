namespace RealHouzing.EntityLayer.Concrete;

public class Plan
{
    public int PlanID { get; set; }
    public string Title { get; set; }
    public string PriceText { get; set; }
    public string IconUrl { get; set; }
    public int ListingCount { get; set; }
    public int FeatureListingCount { get; set; }
    public int RefundPercentage { get; set; }
}
