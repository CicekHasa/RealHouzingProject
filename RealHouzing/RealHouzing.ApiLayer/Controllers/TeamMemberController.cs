using Microsoft.AspNetCore.Mvc;
using RealHouzing.BusinessLayer.Abstract;
using RealHouzing.DtoLayer.TeamMemberDtos;
using RealHouzing.EntityLayer.Concrete;

namespace RealHouzing.ApiLayer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeamMemberController : ControllerBase
{
    private readonly ITeamMemberService _teamMemberService;

	public TeamMemberController(ITeamMemberService teamMemberService)
	{
		_teamMemberService = teamMemberService;
	}

	[HttpGet]
	public IActionResult GetList()
	{
		var values = _teamMemberService.TGetList();
		return Ok(values);
	}

	[HttpGet("GetTeamMemberById")]
	public IActionResult GetTeamMemberById(int id)
	{
		var value = _teamMemberService.TGetById(id);
		return Ok(value);
	}

	[HttpDelete]
	public IActionResult DeleteTeamMember(int id)
	{
		var value = _teamMemberService.TGetById(id);
		_teamMemberService.TDelete(value);
		return Ok();
	}

	[HttpPost]
	public IActionResult AddTeamMember(AddTeamMemberDto addTeamMemberDto)
	{
		TeamMember teamMember = new TeamMember()
		{
			MemberName = addTeamMemberDto.NameSurname,
			Department = addTeamMemberDto.Department,
			MemberImageUrl = addTeamMemberDto.ImageUrl
		};
		_teamMemberService.TInsert(teamMember);
		return Ok();
	}

	[HttpPut]
	public IActionResult UpdateTeamMember(UpdateTeamMemberDto updateTeamMemberDto)
	{
		TeamMember teamMember = new TeamMember()
		{
			TeamMemberID = updateTeamMemberDto.Id,
			MemberName = updateTeamMemberDto.NameSurname,
			Department = updateTeamMemberDto.Department,
			MemberImageUrl = updateTeamMemberDto.ImageUrl
		};
		_teamMemberService.TUpdate(teamMember);
		return Ok();
	}
}
