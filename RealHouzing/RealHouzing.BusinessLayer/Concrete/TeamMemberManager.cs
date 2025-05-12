using RealHouzing.BusinessLayer.Abstract;
using RealHouzing.DataAccessLayer.Abstract;
using RealHouzing.EntityLayer.Concrete;
namespace RealHouzing.BusinessLayer.Concrete;

public class TeamMemberManager : ITeamMemberService
{
    private readonly ITeamMemberDal _teamMemberDal;

    public TeamMemberManager(ITeamMemberDal teamMemberDal)
    {
        _teamMemberDal = teamMemberDal;
    }

    public void TDelete(TeamMember t)
    {
        _teamMemberDal.Delete(t);
    }

    public TeamMember TGetById(int id)
    {
        return _teamMemberDal.GetById(id);
    }

    public List<TeamMember> TGetList()
    {
        return _teamMemberDal.GetList();
    }

    public void TInsert(TeamMember t)
    {
        _teamMemberDal.Insert(t);
    }

    public void TUpdate(TeamMember t)
    {
        _teamMemberDal.Update(t);
    }
}
