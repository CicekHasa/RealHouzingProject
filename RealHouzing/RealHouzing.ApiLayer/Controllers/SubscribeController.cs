using Microsoft.AspNetCore.Mvc;
using RealHouzing.BusinessLayer.Abstract;
using RealHouzing.DtoLayer.SubscribeDtos;
using RealHouzing.EntityLayer.Concrete;

namespace RealHouzing.ApiLayer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscribeController : ControllerBase
{
    private readonly ISubscribeService _subscribeService;

	public SubscribeController(ISubscribeService subscribeService)
	{
		_subscribeService= subscribeService;
	}

	[HttpGet]
	public IActionResult GetList()
	{
		var values=_subscribeService.TGetList();
		return Ok(values);
	}

	[HttpGet("GetSubscribeById")]
	public IActionResult GetSubscribeById(int id)
	{
		var value=_subscribeService.TGetById(id);
		return Ok(value);
	}

	[HttpDelete]
	public IActionResult DeleteSubscribe(int id)
	{
		var value = _subscribeService.TGetById(id);
		_subscribeService.TDelete(value);
		return Ok();
	}

	[HttpPost]
	public IActionResult AddSubscribe(AddSubscribeDto addSubscribeDto) 
	{
		Subscribe subscribe = new Subscribe()
		{
			Email = addSubscribeDto.Email
		};
		_subscribeService.TInsert(subscribe);
		return Ok();
	}

	[HttpPut]
	public IActionResult UpdateSubscribe(UpdateSubscribeDto updateSubscribeDto)
	{
		Subscribe subscribe = new Subscribe()
		{
			SubscribeID=updateSubscribeDto.Id,
			Email=updateSubscribeDto.Email
		};
		_subscribeService.TUpdate(subscribe);
		return Ok();
	}
}
