using System.ComponentModel.DataAnnotations;

namespace RealHouzing.DtoLayer.CompanyValueDtos;

public class AddCompanyValueDto
{
    public string MainTitle { get; set; }
    public string SubTitle { get; set; }
    public string Description { get; set; }
    public string ValueTitle1 { get; set; }
    public string ValueTitle2 { get; set; }
    public string ValueTitle3 { get; set; }
    [Range(0, 100, ErrorMessage = "Yüzde değeri 0 ile 100 arasında olmalıdır.")]
    public int Percentage1 { get; set; }
    [Range(0, 100, ErrorMessage = "Yüzde değeri 0 ile 100 arasında olmalıdır.")]
    public int Percentage2 { get; set; }
    [Range(0, 100, ErrorMessage = "Yüzde değeri 0 ile 100 arasında olmalıdır.")]
    public int Percentage3 { get; set; }
}
