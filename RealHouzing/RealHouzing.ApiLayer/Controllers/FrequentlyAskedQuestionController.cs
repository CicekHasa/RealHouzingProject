using Microsoft.AspNetCore.Mvc;
using RealHouzing.BusinessLayer.Abstract;
using RealHouzing.DtoLayer.FrequentlyAskedQuestionDtos;
using RealHouzing.EntityLayer.Concrete;

namespace RealHouzing.ApiLayer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FrequentlyAskedQuestionController : ControllerBase
{
    private readonly IFrequentlyAskedQuestionService _frequentlyAskedQuestionService;

    public FrequentlyAskedQuestionController(IFrequentlyAskedQuestionService frequentlyAskedQuestionService)
    {
        _frequentlyAskedQuestionService = frequentlyAskedQuestionService;
    }

    [HttpGet]
    public IActionResult GetList()
    {
        var values = _frequentlyAskedQuestionService.TGetList();
        return Ok(values);
    }

    [HttpGet("GetQuestionsById")]
    public IActionResult GetQuestionsById(int id)
    {
        var value = _frequentlyAskedQuestionService.TGetById(id);
        return Ok(value);
    }

    [HttpDelete]
    public IActionResult DeleteQuestion(int id)
    {
        var value = _frequentlyAskedQuestionService.TGetById(id);
        _frequentlyAskedQuestionService.TDelete(value);
        return Ok();
    }

    [HttpPost]
    public IActionResult AddQuestion(AddFrequentlyAskedQuestionDto addFrequentlyAskedQuestionDto)
    {
        FrequentlyAskedQuestion frequentlyAskedQuestion = new FrequentlyAskedQuestion
        {
            Question = addFrequentlyAskedQuestionDto.Question,
            Answer = addFrequentlyAskedQuestionDto.Answer
        };
        _frequentlyAskedQuestionService.TInsert(frequentlyAskedQuestion);
        return Ok();
    }

    [HttpPut]
    public IActionResult UpdateQuestion(UpdateFrequentlyAskedQuestionDto updateFrequentlyAskedQuestionDto)
    {
        FrequentlyAskedQuestion frequentlyAskedQuestion = new FrequentlyAskedQuestion()
        {
            FrequentlyAskedQuestionID = updateFrequentlyAskedQuestionDto.Id,
            Question = updateFrequentlyAskedQuestionDto.Question,
            Answer = updateFrequentlyAskedQuestionDto.Answer
        };
        _frequentlyAskedQuestionService.TUpdate(frequentlyAskedQuestion);
        return Ok();
    }
}
