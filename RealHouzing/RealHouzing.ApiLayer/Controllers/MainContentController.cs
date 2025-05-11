using Microsoft.AspNetCore.Mvc;
using RealHouzing.BusinessLayer.Abstract;
using RealHouzing.DtoLayer.MainContentDtos;
using RealHouzing.EntityLayer.Concrete;

namespace RealHouzing.ApiLayer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MainContentController : ControllerBase
{
    private readonly IMainContentService _mainContentService;

    public MainContentController(IMainContentService mainContentService)
    {
        _mainContentService = mainContentService;
    }

    [HttpGet]
    public IActionResult GetList()
    {
        var values = _mainContentService.TGetList();
        return Ok(values);
    }

    [HttpGet("GetMainContentById")]
    public IActionResult GetMainContentById(int id)
    {
        var values = _mainContentService.TGetById(id);
        return Ok(values);
    }

    [HttpDelete]
    public IActionResult DeleteMainContent(int id)
    {
        var value = _mainContentService.TGetById(id);
        _mainContentService.TDelete(value);
        return Ok();
    }

    [HttpPost]
    public IActionResult AddMainContent(AddMainContentDto addMainContentDto)
    {
        MainContent mainContent = new MainContent()
        {
            ContentTitle = addMainContentDto.Title,
            ContentDescription = addMainContentDto.Description,
            ContentImageUrl = addMainContentDto.ImageUrl
        };
        _mainContentService.TInsert(mainContent);
        return Ok();
    }

    [HttpPut]
    public IActionResult UpdateMainContent(UpdateMainContentDto updateMainContentDto)
    {
        MainContent mainContent = new MainContent()
        {
            MainContentID = updateMainContentDto.Id,
            ContentTitle = updateMainContentDto.Title,
            ContentDescription = updateMainContentDto.Description,
            ContentImageUrl = updateMainContentDto.ImageUrl
        };
        _mainContentService.TUpdate(mainContent);
        return Ok();
    }
}
