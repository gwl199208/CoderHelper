using Coder.Core.Models.OnlineJudges;
using System;
using System.Collections.Generic;
using System.Linq;
using Coder.Core.Service;
using System.Text;
using System.Threading.Tasks;
using Coder.Core.Models.Commons;
using Coder.Core.Repository;
using Coder.Core.Models.MidTab;
using Coder.Data;

namespace Coder.Service
{
    public class TeamContestService : CrudService<TeamContestModel>, ITeamContestService
    {
        protected readonly IRepository<User_TeamContestModel> u_scRepo;
        public readonly Db db;
        public TeamContestService(IRepository<TeamContestModel> repo,
            IRepository<User_TeamContestModel> u_scRepo, IDbContextFactory db)
            : base(repo)
        {
            this.u_scRepo = u_scRepo;
            this.db = (Db)db.GetContext();
        }

        bool ITeamContestService.addUserToTeam(int teamContestId, UserModel user)
        {
            throw new NotImplementedException();
        }

        List<TeamContestModel> ITeamContestService.getList()
        {
            try
            {
                return repo.GetAll().ToList<TeamContestModel>();
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public List<TeamContestModel> getNewestList()
        {
            throw new NotImplementedException();
        }

        public List<TeamContestModel> getJoinedList(int uid)
        {
            throw new NotImplementedException();
        }

        public List<TeamContestModel> getUnjoinedList(int uid)
        {
            throw new NotImplementedException();
        }

        public List<TeamContestModel> getIngList()
        {
            throw new NotImplementedException();
        }

        public List<TeamContestModel> getOrderList(string factor)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 检查当前提交记录是否有效
        /// 既当前的个人赛是否正在进行时
        /// 当前个人赛中是否包含相应题目
        /// 用户是否被允许参加当前个人赛
        /// 后期这里可以被优化掉
        /// 只要能确保提交的肯定有效
        /// </summary>
        /// <param name="scId"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        public bool isCurSubmitRecodeValid(int tcId, int uid, int pid)
        {
            ///
            ///可能会有查询不到的异常
            ///
            TeamContestModel tcm = repo.Get(tcId);
            var b_sc = (from bp_tc in db.bp_tc
                        where bp_tc.baseProblemId == pid
                                && bp_tc.teamContestId == uid
                        select bp_tc).Take(1);
            if (b_sc == null && tcm == null || !tcm.teamContestStatus.Equals("ING"))
                return false; return true;
        }
        
        
        public bool saveTeamContestResult(TeamResultModel tsm)
        {
            try {
                db.teamResults.Add(tsm);
                db.SaveChanges();
                return true;
            }
            catch (Exception e) { return false; }
        }
        
    }
}
