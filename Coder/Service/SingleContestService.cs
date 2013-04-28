using Coder.Core.Models.OnlineJudges;
using Coder.Core.Repository;
using Coder.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coder.Core.Models.Commons ;
using Coder.Core.Models.MidTab;
using Coder.Data;

namespace Coder.Service
{
    public class SingleContestService : CrudService<SingleContestModel>, ISingleContestService
    {
        protected readonly IRepository<User_SingleContestModel> u_scRepo;
        public readonly Db db;

        public SingleContestService(IRepository<SingleContestModel> repo, 
            IRepository<User_SingleContestModel> u_scRepo,IDbContextFactory db)
            : base(repo)
        {
            this.u_scRepo = u_scRepo;
            this.db = (Db)db.GetContext();
        }

        public bool addUserToSingleContest(int singleContestId, UserModel user)
        {
            throw new NotImplementedException();
        }

        public List<SingleContestModel> getList()
        {
            try
            {
                return repo.GetAll().ToList<SingleContestModel>();
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public List<SingleContestModel> getNewestList()
        {
            throw new NotImplementedException();
        }

        public List<SingleContestModel> getJoinedList(int uid)
        {
            try
            {
                List<User_SingleContestModel> u_scList  = u_scRepo.Where(o => o.uid == uid)
                        .AsQueryable<User_SingleContestModel>().ToList<User_SingleContestModel>();
                List<SingleContestModel> scList = new List<SingleContestModel>() ;
                
                if(u_scList == null) return null ;

                for(int i=0 ; i<u_scList.Count ; i++)
                {
                    int tempscId = u_scList[i].singleContestId;
                    scList.Add(repo.Where(o => o.singleContestId == tempscId).SingleOrDefault());
                }
                return scList;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// //////////////////涉及到lambda表达式的多表查询
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<SingleContestModel> getUnjoinedList(int uid)
        {
            try
            {
                List<SingleContestModel> unjoinedList = (from sc in db.singleContests
                        where
                           !(from u_sc in db.u_sc where (u_sc.uid == uid) select u_sc.singleContestId)
                           .Contains(sc.singleContestId)
                        select sc).ToList<SingleContestModel>() ;
                return unjoinedList;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<SingleContestModel> getIngList()
        {
            throw new NotImplementedException();
        }

        public List<SingleContestModel> getWaitList()
        {
            throw new NotImplementedException();
        }

        public List<SingleContestModel> getOrderList(string factor)
        {
            throw new NotImplementedException();
        }

        public SingleContestModel getSingleContest(int scId)
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
        public bool isCurSubmitRecodeValid(int scId , int uid , int pid)
        {
            ///
            ///可能会有查询不到的异常
            ///
            SingleContestModel scm = repo.Get(scId) ;
            var b_sc = (from bp_sc in db.bp_sc where bp_sc.baseProblemId == pid 
                                                       && bp_sc.singleContestId==uid select bp_sc).Take(1) ;
            if (b_sc==null || scm==null || !scm.singleContestStatus.Equals("ING"))
                return false; return true;
        }
    }
}
