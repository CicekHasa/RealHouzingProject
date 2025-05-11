using Microsoft.AspNetCore.Mvc;
using RealHouzing.BusinessLayer.Abstract;
using RealHouzing.DtoLayer.FeatureCardDtos;
using RealHouzing.EntityLayer.Concrete;

namespace RealHouzing.ApiLayer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeatureCardController : ControllerBase
{
    private readonly IFeatureCardService _featureCardService;

	public FeatureCardController(IFeatureCardService featureCardService)
	{
		_featureCardService= featureCardService;
	}

	[HttpGet]
	public IActionResult GetList()
	{
		var values=_featureCardService.TGetList();
		return Ok(values);
	}

	[HttpGet("GetFeatureCardById")]
	public IActionResult GetFeatureCardById(int id)
	{
		var values=_featureCardService.TGetById(id);
		return Ok(values);
	}

	[HttpDelete]
	public IActionResult DeleteFeatureCard(int id)
	{
		var values = _featureCardService.TGetById(id);
		_featureCardService.TDelete(values);
		return Ok(values);
	}

	[HttpPost]
	public IActionResult AddFeatureCard(AddFeatureCardDto addFeatureCardDto)
	{
		FeatureCard featureCard = new FeatureCard()
		{
			Title = addFeatureCardDto.Title,
			Description = addFeatureCardDto.Description,
			IconUrl = addFeatureCardDto.IconUrl
		};
		_featureCardService.TInsert(featureCard);
		return Ok();
	}

	[HttpPut]
	public IActionResult UpdateFeatureCard(UpdateFeatureCardDto updateFeatureCardDto)
	{
		FeatureCard featureCard = new FeatureCard()
		{
			FeatureCardID = updateFeatureCardDto.Id,
			Title = updateFeatureCardDto.Title,
			Description = updateFeatureCardDto.Description,
			IconUrl = updateFeatureCardDto.IconUrl
		};
		_featureCardService.TUpdate(featureCard);
		return Ok();
	}
}
