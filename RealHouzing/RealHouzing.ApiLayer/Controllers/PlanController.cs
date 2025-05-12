using Microsoft.AspNetCore.Mvc;
using RealHouzing.BusinessLayer.Abstract;
using RealHouzing.DtoLayer.PlanDtos;
using RealHouzing.EntityLayer.Concrete;

namespace RealHouzing.ApiLayer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlanController : ControllerBase
{
    private readonly IPlanService _planService;

	public PlanController(IPlanService planService)
	{
		_planService= planService;
	}

	[HttpGet]
	public IActionResult GetList()
	{
		var values=_planService.TGetList();
		return Ok(values);
	}

	[HttpGet("GetPlanById")]
	public IActionResult GetPlanById(int id)
	{
		var value=_planService.TGetById(id);
		return Ok(value);
	}

	[HttpDelete]
	public IActionResult DeletePlan(int id)
	{
		var value = _planService.TGetById(id);
		_planService.TDelete(value);
		return Ok();
	}

	[HttpPost]
	public IActionResult AddPlan(AddPlanDto addPlanDto)
	{
		Plan plan = new Plan
		{
			Title = addPlanDto.Title,
			PriceText = addPlanDto.PriceText,
			IconUrl = addPlanDto.IconUrl,
			ListingCount = addPlanDto.ListingCount,
			FeatureListingCount = addPlanDto.FeatureListingCount,
			RefundPercentage = addPlanDto.RefundPercentage
		};
		_planService.TInsert(plan);
		return Ok();
	}

	[HttpPut]
	public IActionResult UpdatePlan(UpdatePlanDto updatePlanDto)
	{
		var oldValue=_planService.TGetById(updatePlanDto.Id);
		Plan plan = new Plan()
		{
			PlanID = updatePlanDto.Id,
			Title = oldValue.Title,
			PriceText = updatePlanDto.PriceText,
			IconUrl = oldValue.IconUrl,
			ListingCount = updatePlanDto.ListingCount,
			FeatureListingCount = updatePlanDto.FeatureListingCount,
			RefundPercentage = updatePlanDto.RefundPercentage
		};
		_planService.TUpdate(plan);
		return Ok();
	}
}
