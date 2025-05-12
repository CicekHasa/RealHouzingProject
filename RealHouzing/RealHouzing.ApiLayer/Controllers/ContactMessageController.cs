using Microsoft.AspNetCore.Mvc;
using RealHouzing.BusinessLayer.Abstract;
using RealHouzing.DtoLayer.ContactMessageDtos;
using RealHouzing.EntityLayer.Concrete;

namespace RealHouzing.ApiLayer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactMessageController : ControllerBase
{
    private readonly IContactMessageService _contactMessageService;

	public ContactMessageController(IContactMessageService contactMessageService)
	{
		_contactMessageService= contactMessageService;
	}

	[HttpGet]
	public IActionResult GetList()
	{
		var values=_contactMessageService.TGetList();
		return Ok(values);
	}

	[HttpGet("GetContactMessageById")]
	public IActionResult GetContactMessageById(int id)
	{
		var value=_contactMessageService.TGetById(id);
		return Ok(value);
	}

	[HttpDelete]
	public IActionResult DeleteContactMessage(int id)
	{
		var value = _contactMessageService.TGetById(id);
		_contactMessageService.TDelete(value);
		return Ok();
	}

	[HttpPost]
	public IActionResult AddContactMessage(AddContactMessageDto addContactMessageDto)
	{
		ContactMessage contactMessage = new ContactMessage()
		{
			FullName = addContactMessageDto.FullName,
			Subject = addContactMessageDto.Subject,
			Mail = addContactMessageDto.Mail,
			Phone = addContactMessageDto.Phone,
			Message = addContactMessageDto.Message
		};
		_contactMessageService.TInsert(contactMessage);
		return Ok();
	}

	[HttpPut]
	public IActionResult UpdateContactMessage(UpdateContactMessageDto updateContactMessageDto)
	{
		var oldValue = _contactMessageService.TGetById(updateContactMessageDto.Id);
		ContactMessage contactMessage = new ContactMessage()
		{
			//Id vermediğiniz durumda Update yerine Insert işlemi gerçekleştirir.
			ContactMessageID= updateContactMessageDto.Id,
			FullName=oldValue.FullName,
			Subject=oldValue.Subject,
			Mail = updateContactMessageDto.Mail,
			Phone = updateContactMessageDto.Phone,
			Message=oldValue.Message
		};
		_contactMessageService.TUpdate(contactMessage);
		return Ok();
	}
}
