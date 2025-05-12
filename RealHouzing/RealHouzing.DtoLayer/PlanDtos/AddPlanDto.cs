using System.ComponentModel.DataAnnotations;

namespace RealHouzing.DtoLayer.PlanDtos;

public class AddPlanDto
{
    public string Title { get; set; }
    public string PriceText { get; set; }
    public string IconUrl { get; set; }
    public int ListingCount { get; set; }
    public int FeatureListingCount { get; set; }
    [Range(0, 100, ErrorMessage = "Yüzde değeri 0 ile 100 arasında olmalıdır.")]
    public int RefundPercentage { get; set; }
}
