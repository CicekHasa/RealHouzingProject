using Microsoft.AspNetCore.Mvc;
using RealHouzing.BusinessLayer.Abstract;
using RealHouzing.DtoLayer.NewDtos;
using RealHouzing.EntityLayer.Concrete;

namespace RealHouzing.ApiLayer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NewController : ControllerBase
{
    private readonly INewService _newService;

    public NewController(INewService newService)
    {
        _newService = newService;
    }

    [HttpGet]
    public IActionResult GetList()
    {
        var values = _newService.TGetList();
        return Ok(values);
    }

    [HttpGet("GetNewById")]
    public IActionResult GetNewById(int id)
    {
        var value = _newService.TGetById(id);
        return Ok(value);
    }

    [HttpDelete]
    public IActionResult DeleteNew(int id)
    {
        var value = _newService.TGetById(id);
        _newService.TDelete(value);
        return Ok(value);
    }

    [HttpPost]
    public IActionResult AddNew(AddNewDto addNewDto)
    {
        New neww = new New()
        {
            NewTitle = addNewDto.NewTitle,
            NewDescription = addNewDto.NewDescription,
            NewImageUrl = addNewDto.NewImageUrl,
            AuthorName = addNewDto.AuthorName,
            AuthorImage = addNewDto.AuthorImage,
            PublishDate = addNewDto.PublishDate
        };
        _newService.TInsert(neww);
        return Ok(neww);
    }

    [HttpPut]
    public IActionResult UpdateNew(UpdateNewDto updateNewDto)
    {
        //Dto da eklemediğim ve güncellenmesini istemediğim veriler için eski değerlerini atayacağım.
        var oldValue=_newService.TGetById(updateNewDto.Id);
        New neww = new New()
        {
            NewID = updateNewDto.Id,
            NewTitle = updateNewDto.Title,
            NewDescription = updateNewDto.Description,
            NewImageUrl = updateNewDto.NewImageUrl,
            AuthorImage = updateNewDto.AutohorImageUrl,
            AuthorName=oldValue.AuthorName,
            PublishDate=oldValue.PublishDate
        };
        _newService.TUpdate(neww);
        return Ok();
    }
}
