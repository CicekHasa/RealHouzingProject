using Microsoft.AspNetCore.Mvc;
using RealHouzing.BusinessLayer.Abstract;
using RealHouzing.DtoLayer.ProductDtos;
using RealHouzing.EntityLayer.Concrete;

namespace RealHouzing.ApiLayer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
	public ProductController(IProductService productService)
	{
		_productService= productService;
	}
	[HttpGet]
	public IActionResult GetProductList()
	{
		var values=_productService.TGetList();
		return Ok(values);
	}
	[HttpGet("ProductListWithCategories")]
	public IActionResult ProductListWithCategories()
	{
		var values=_productService.TGetProductsWithCategories();
		return Ok(values);
	}
	[HttpPost]
	public IActionResult AdddProduct(AddProductDto addProductDto)
	{
		Product product = new Product()
		{
			ProductTitle = addProductDto.ProductTitle,
			ProductPrice = addProductDto.ProductPrice,
			ProductType = addProductDto.ProductType,
			ProductAdress = addProductDto.ProductAdress,
			BedRoomCount = addProductDto.BedRoomCount,
			BathCount = addProductDto.BathCount,
			Square = addProductDto.Square,
			CoverImageUrl = addProductDto.CoverImageUrl,
			CategoryID = addProductDto.CategoryID
		};
		_productService.TInsert(product);
		return Ok();
	}
	[HttpDelete]
	public IActionResult DeleteProduct(int id)
	{
		var values=_productService.TGetById(id);
		_productService.TDelete(values);
		return Ok();
	}
	[HttpGet("GetProductById")]
	public IActionResult GetProductById(int id)
	{
		var values = _productService.TGetById(id);
		return Ok(values);
	}
	[HttpPut]
	public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
	{
		Product product = new Product()
		{
			ProductID = updateProductDto.ProductID,
			ProductTitle = updateProductDto.ProductTitle,
			ProductPrice = updateProductDto.ProductPrice,
			ProductType = updateProductDto.ProductType,
			ProductAdress = updateProductDto.ProductAdress,
			BedRoomCount = updateProductDto.BedRoomCount,
			BathCount = updateProductDto.BathCount,
			Square = updateProductDto.Square,
			CoverImageUrl = updateProductDto.CoverImageUrl,
			CategoryID = updateProductDto.CategoryID
		};
		_productService.TUpdate(product);
		return Ok();
	}
}
