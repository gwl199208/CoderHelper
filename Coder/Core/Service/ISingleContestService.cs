using Coder.Core.Models.Commons;
using Coder.Core.Models.OnlineJudges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coder.Core.Service
{
    public interface ISingleContestService : ICrudService<SingleContestModel>
    {
        bool addUserToSingleContest(int singleContestId, UserModel user);
        List<SingleContestModel> getList();
        List<SingleContestModel> getNewestList();
        List<SingleContestModel> getJoinedList(int uid);
        List<SingleContestModel> getUnjoinedList(int uid);
        List<SingleContestModel> getIngList();
        List<SingleContestModel> getWaitList();
        List<SingleContestModel> getOrderList(string factor);

        SingleContestModel getSingleContest(int scId);
        bool isCurSubmitRecodeValid(int scId, int uid, int pid);
    }
}
