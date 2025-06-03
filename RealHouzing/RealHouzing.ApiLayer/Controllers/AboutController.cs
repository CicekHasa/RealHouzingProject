using Microsoft.AspNetCore.Mvc;
using RealHouzing.BusinessLayer.Abstract;
using RealHouzing.DtoLayer.AboutDtos;
using RealHouzing.EntityLayer.Concrete;

namespace RealHouzing.ApiLayer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AboutController : ControllerBase
{
    private readonly IAboutService _aboutService;

    public AboutController(IAboutService aboutService)
    {
        _aboutService = aboutService;
    }

    [HttpGet]
    public IActionResult GetList()
    {
        var value = _aboutService.TGetList();
        return Ok(value);
    }

    [HttpGet("GetListById")]
    public IActionResult GetListById(int id)
    {
        var value = _aboutService.TGetById(id);
        return Ok(value);
    }

    [HttpDelete]
    public IActionResult DeleteAbout(int id)
    {
        var value = _aboutService.TGetById(id);
        _aboutService.TDelete(value);
        return Ok();
    }

    [HttpPost]
    public IActionResult AddAbout(AddAboutDto addAboutDto)
    {
        About about = new About
        {
            Title = addAboutDto.Title,
            SubTitle = addAboutDto.SubTitle,
            Description = addAboutDto.Description,
            Feature_1 = addAboutDto.Feature_1,
            Feature_2 = addAboutDto.Feature_2,
            Feature_3 = addAboutDto.Feature_3,
            Feature_4 = addAboutDto.Feature_4,
            Feature_5 = addAboutDto.Feature_5,
            Feature_6 = addAboutDto.Feature_6,
            ImageUrl = addAboutDto.ImageUrl
        };
        _aboutService.TInsert(about);
        return Ok();
    }

    [HttpPut]
    public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
    {
        var oldValue = _aboutService.TGetById(updateAboutDto.Id);
        About about = new About()
        {
            AboutID = updateAboutDto.Id,
            Title = oldValue.Title,
            SubTitle = oldValue.SubTitle,
            Description = oldValue.Description,
            Feature_1 = updateAboutDto.Feature_1,
            Feature_2 = updateAboutDto.Feature_2,
            Feature_3 = updateAboutDto.Feature_3,
            Feature_4 = updateAboutDto.Feature_4,
            Feature_5 = updateAboutDto.Feature_5,
            Feature_6 = updateAboutDto.Feature_6,
            ImageUrl = oldValue.ImageUrl
        };
        _aboutService.TUpdate(about);
        return Ok();
    }
}
