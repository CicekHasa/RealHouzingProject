using Microsoft.AspNetCore.Mvc;
using RealHouzing.BusinessLayer.Abstract;
using RealHouzing.DtoLayer.ReviewDtos;
using RealHouzing.EntityLayer.Concrete;

namespace RealHouzing.ApiLayer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _reviewService;

	public ReviewController(IReviewService reviewService)
	{
		_reviewService= reviewService;
	}

	[HttpGet]
	public IActionResult GetList()
	{
		var values=_reviewService.TGetList();
		return Ok(values);
	}

	[HttpGet("GetReviewById")]
	public IActionResult GetReviewById(int id)
	{
		var values=_reviewService.TGetById(id);
		return Ok(values);
	}

	[HttpDelete]
	public IActionResult DeleteReview(int id)
	{
		var value = _reviewService.TGetById(id);
		_reviewService.TDelete(value);
		return Ok();
	}

	[HttpPost]
	public IActionResult AddReview(AddReviewDto addReviewDto)
	{
		Review review = new Review()
		{
			NameSurname = addReviewDto.NameSurname,
			Job = addReviewDto.Job,
			Description = addReviewDto.Description,
			ImageUrl = addReviewDto.ImageUrl
		};
		_reviewService.TInsert(review);
		return Ok();
	}

	[HttpPut]
	public IActionResult UpdateReview(UpdateReviewDto updateReviewDto)
	{
		Review review = new Review()
		{
			ReviewID = updateReviewDto.Id,
			NameSurname = updateReviewDto.NameSurname,
			Job = updateReviewDto.Job,
			Description = updateReviewDto.Description,
			ImageUrl = updateReviewDto.ImageUrl
		};
		_reviewService.TUpdate(review);
		return Ok();
	}
}
