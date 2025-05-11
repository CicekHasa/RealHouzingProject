using Microsoft.AspNetCore.Mvc;
using RealHouzing.BusinessLayer.Abstract;
using RealHouzing.DtoLayer.CompanyValueDtos;
using RealHouzing.EntityLayer.Concrete;

namespace RealHouzing.ApiLayer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyValueController : ControllerBase
{
    private readonly ICompanyValueService _companyValueService;

	public CompanyValueController(ICompanyValueService companyValueService)
	{
		_companyValueService= companyValueService;
	}

	[HttpGet]
	public IActionResult GetList()
	{
		var values=_companyValueService.TGetList();
		return Ok(values);
	}

	[HttpGet("GetCompanyValueById")]
	public IActionResult GetCompanyValueById(int id)
	{
		var value=_companyValueService.TGetById(id);
		return Ok(value);
	}

	[HttpDelete]
	public IActionResult DeleteCompanyValue(int id)
	{
		var value = _companyValueService.TGetById(id);
		_companyValueService.TDelete(value);
		return Ok();
	}

	[HttpPost]
	public IActionResult AddCompanyValue(AddCompanyValueDto addCompanyValueDto)
	{
		CompanyValue companyValue = new CompanyValue()
		{
			MainTitle = addCompanyValueDto.MainTitle,
			SubTitle = addCompanyValueDto.SubTitle,
			Description = addCompanyValueDto.Description,
			ValueTitle1 = addCompanyValueDto.ValueTitle1,
			ValueTitle2 = addCompanyValueDto.ValueTitle2,
			ValueTitle3 = addCompanyValueDto.ValueTitle3,
			Percentage1 = addCompanyValueDto.Percentage1,
			Percentage2 = addCompanyValueDto.Percentage2,
			Percentage3 = addCompanyValueDto.Percentage3
		};
		_companyValueService.TInsert(companyValue);
		return Ok();
	}

	[HttpPut]
	public IActionResult UpdateCompanyValue(UpdateCompanyValueDto updateCompanyValueDto)
	{
		CompanyValue companyValue = new CompanyValue()
		{
			CompanyValueID = updateCompanyValueDto.Id,
			MainTitle = updateCompanyValueDto.MainTitle,
			SubTitle = updateCompanyValueDto.SubTitle,
			Description = updateCompanyValueDto.Description,
			ValueTitle1 = updateCompanyValueDto.ValueTitle1,
			ValueTitle2 = updateCompanyValueDto.ValueTitle2,
			ValueTitle3 = updateCompanyValueDto.ValueTitle3,
			Percentage1 = updateCompanyValueDto.Percentage1,
			Percentage2 = updateCompanyValueDto.Percentage2,
			Percentage3 = updateCompanyValueDto.Percentage3
		};
		_companyValueService.TUpdate(companyValue);
		return Ok();
	}
}
