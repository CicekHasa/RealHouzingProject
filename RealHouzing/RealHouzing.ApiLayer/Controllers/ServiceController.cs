using Microsoft.AspNetCore.Mvc;
using RealHouzing.BusinessLayer.Abstract;
using RealHouzing.DtoLayer.ServiceDtos;
using RealHouzing.EntityLayer.Concrete;

namespace RealHouzing.ApiLayer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServiceController : ControllerBase
{
    private readonly IServicesService _servicesService;

	public ServiceController(IServicesService servicesService)
	{
		_servicesService= servicesService;
	}

	[HttpGet]
	public IActionResult GetList()
	{
		var values=_servicesService.TGetList();
		return Ok(values);
	}


	[HttpGet("GetServiceById")]
	public IActionResult GetServiceById(int id)
	{
		var value=_servicesService.TGetById(id);
		return Ok(value);
	}

	[HttpDelete]
	public IActionResult DeleteService(int id)
	{
		var value = _servicesService.TGetById(id);
		_servicesService.TDelete(value);
		return Ok();
	}

	[HttpPost]
	public IActionResult AddService(AddServiceDto addServiceDto)
	{
		Service service = new Service()
		{
			Title = addServiceDto.Title,
			Description = addServiceDto.Description,
			IconUrl = addServiceDto.IconUrl
		};
		_servicesService.TInsert(service);
		return Ok();
	}

	[HttpPut]
	public IActionResult UpdateService(UpdateServiceDto updateServiceDto)
	{
		Service service = new Service()
		{
			ServiceID = updateServiceDto.Id,
			Title = updateServiceDto.Title,
			Description = updateServiceDto.Description,
			IconUrl = updateServiceDto.IconUrl
		};
		_servicesService.TUpdate(service);
		return Ok();
	}
}
