using Microsoft.AspNetCore.Mvc;
using RealHouzing.BusinessLayer.Abstract;

namespace RealHouzing.ApiLayer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

	public CategoryController(ICategoryService categoryService)
	{
		_categoryService= categoryService;
	}

	[HttpGet]
	public IActionResult CategoryList()
	{
		var values=_categoryService.TGetList();
		return Ok(values);
	}

	[HttpDelete]
	public IActionResult DeleteCategory(int id)
	{
		var values=_categoryService.TGetById(id);
		_categoryService.TDelete(values);
		return Ok();
	}
}
