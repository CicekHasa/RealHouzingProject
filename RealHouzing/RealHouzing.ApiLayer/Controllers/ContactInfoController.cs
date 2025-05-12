using Microsoft.AspNetCore.Mvc;
using RealHouzing.BusinessLayer.Abstract;
using RealHouzing.DtoLayer.ContactInfoDtos;
using RealHouzing.EntityLayer.Concrete;

namespace RealHouzing.ApiLayer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactInfoController : ControllerBase
{
    private readonly IContactInfoService _contactInfoService;

    public ContactInfoController(IContactInfoService contactInfoService)
    {
        _contactInfoService = contactInfoService;
    }

    [HttpGet]
    public IActionResult GetList()
    {
        var values = _contactInfoService.TGetList();
        return Ok(values);
    }

    [HttpDelete]
    public IActionResult DeleteContactInfo(int id)
    {
        var value = _contactInfoService.TGetById(id);
        _contactInfoService.TDelete(value);
        return Ok();
    }

    [HttpPost]
    public IActionResult AddContactInfo(AddContactInfoDto addContactInfoDto)
    {
        ContactInfo contactInfo = new ContactInfo()
        {
            AdressIconUrl = addContactInfoDto.AdressIconUrl,
            Adress_1 = addContactInfoDto.Adress_1,
            Adress_2 = addContactInfoDto.Adress_2,
            MailIconUrl = addContactInfoDto.MailIconUrl,
            Mail_1 = addContactInfoDto.Mail_1,
            Mail_2 = addContactInfoDto.Mail_2,
            PhoneIconUrl = addContactInfoDto.PhoneIconUrl,
            Phone_1 = addContactInfoDto.Phone_1,
            Phone_2 = addContactInfoDto.Phone_2
        };
        _contactInfoService.TInsert(contactInfo);
        return Ok();
    }

    [HttpPut]
    public IActionResult UpdateContactInfo(UpdateContactInfoDto updateContactInfoDto)
    {
        var oldValue = _contactInfoService.TGetById(updateContactInfoDto.Id);
        ContactInfo contactInfo = new ContactInfo()
        {
            ContactInfoID = updateContactInfoDto.Id,
            Mail_1 = updateContactInfoDto.Mail_1,
            Mail_2 = updateContactInfoDto.Mail_2,
            MailIconUrl = oldValue.MailIconUrl,
            AdressIconUrl = oldValue.AdressIconUrl,
            Adress_1 = updateContactInfoDto.Adress_1,
            Adress_2 = updateContactInfoDto.Adress_2,
            PhoneIconUrl = oldValue.PhoneIconUrl,
            Phone_1 = updateContactInfoDto.Phone_1,
            Phone_2 = updateContactInfoDto.Phone_2
        };
        _contactInfoService.TUpdate(contactInfo);
        return Ok();
    }
}
