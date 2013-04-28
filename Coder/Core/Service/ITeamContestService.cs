using Coder.Core.Models.Commons;
using Coder.Core.Models.OnlineJudges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coder.Core.Service
{
    public interface ITeamContestService : ICrudService<TeamContestModel>
    {
        bool addUserToTeam(int teamContestId , UserModel user);
        List<TeamContestModel> getNewestList();
        List<TeamContestModel> getList();
        List<TeamContestModel> getJoinedList(int uid);
        List<TeamContestModel> getUnjoinedList(int uid);
        List<TeamContestModel> getIngList();
        List<TeamContestModel> getOrderList(string factor);
        bool isCurSubmitRecodeValid(int tcId, int uid, int pid);
        bool saveTeamContestResult(TeamResultModel tsm);
    }
}
