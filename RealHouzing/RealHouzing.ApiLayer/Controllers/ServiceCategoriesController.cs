using Microsoft.AspNetCore.Mvc;
using RealHouzing.BusinessLayer.Abstract;
using RealHouzing.DtoLayer.ServiceCategoriesDtos;
using RealHouzing.EntityLayer.Concrete;

namespace RealHouzing.ApiLayer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServiceCategoriesController : ControllerBase
{
    private readonly IServiceCategoriesService _serviceCategoriesService;
    public ServiceCategoriesController(IServiceCategoriesService serviceCategoriesService)
    {
        _serviceCategoriesService = serviceCategoriesService;
    }

    [HttpGet]
    public IActionResult GetServiceCategoriesList()
    {
        var values = _serviceCategoriesService.TGetList();
        return Ok(values);
    }

    [HttpGet("GetServiceCategoriesById")]
    public IActionResult GetServiceCategoriesById(int id)
    {
        var values=_serviceCategoriesService.TGetById(id);
        return Ok(values);
    }

    [HttpPost]
    public IActionResult AddServiceCategories(AddServiceCategoriesDto addServiceCategoriesDto)
    {
        ServiceCategories serviceCategories = new ServiceCategories()
        {
            Title = addServiceCategoriesDto.Title,
            ImageUrl = addServiceCategoriesDto.ImageUrl
        };
        _serviceCategoriesService.TInsert(serviceCategories);
        return Ok();
    }

    [HttpDelete]
    public IActionResult DeleteServiceCategories(int id)
    {
        var values = _serviceCategoriesService.TGetById(id);
        _serviceCategoriesService.TDelete(values);
        return Ok();
    }

    [HttpPut]
    public IActionResult UpdateServiceCategories (UpdateServiceCategoriesDtos updateServiceCategoriesDtos)
    {
        ServiceCategories serviceCategories = new ServiceCategories()
        {
            ServiceCategoriesID= updateServiceCategoriesDtos.Id,
            Title = updateServiceCategoriesDtos.Title,
            ImageUrl= updateServiceCategoriesDtos.ImageUrl
        };
        _serviceCategoriesService.TUpdate(serviceCategories);
        return Ok();
    }
}
