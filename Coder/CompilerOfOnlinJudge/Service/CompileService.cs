using Coder.CompileOfOJ.Dbo;
using Coder.CompilerOfOJ;
using Coder.Data;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Coder.CompileOfOJ.Service
{
    public class CompileService
    {
        readonly CompileLtoSDataContext context = new CompileLtoSDataContext();
        /// <summary>
        /// 获得一条当前操作的做题结果缓存记录
        /// </summary>
        /// <returns></returns>
        public CompileCacheModels getCompileCache()
        {
            var compileCache = (from c in context.CompileCacheModels select c).Take(1) ;
            if (compileCache != null) return compileCache.Single(); return null;
        }
        /// <summary>
        /// 将当前所操作的结果缓存记录从表中删除
        /// </summary>
        /// <returns></returns>
        public bool delCurrentCompileCache()
        {
            try
            {
                var compileCache = (from c in context.CompileCacheModels select c).Take(1);
                if (compileCache != null)
                {
                    context.CompileCacheModels.DeleteOnSubmit(compileCache.Single());
                    context.SubmitChanges();
                }
                return true;
            }
            catch(Exception e){return false ;}
        }

        public bool isCompileCacheEmpty()
        {
            //context.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, context.CompileCacheModels);
            var compileCache = (from c in context.CompileCacheModels select c).Take(1);
            if (compileCache.Count() <= 0) return true; return false;
        }
        
        /// <summary>
        /// 获取单个题目对象
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public BaseProblemModels getProblem(int pid) 
        {
            try
            {
                return context.BaseProblemModels.Single(c => c.pid == pid);
            }
            catch (Exception e) { return null; }
        }
        /// <summary>
        /// 获取单个结果对象
        /// </summary>
        /// <param name="resultId"></param>
        /// <returns></returns>
        public ResultModels getResult(int resultId)
        {
            try
            {
                return context.ResultModels.Single(c => c.resut_id == resultId);
            }
            catch (Exception e) { return null; }
        }
        /// <summary>
        /// 获取单个个人赛结果对象
        /// </summary>
        /// <param name="resultId"></param>
        /// <returns></returns>
        public SingleResultModels getSingleResult(int resultId)
        {
            try
            {
                return context.SingleResultModels.Single(c => c.singleResutId == resultId);
            }
            catch (Exception e) { return null; }
        }
        /// <summary>
        /// 获取单个团队赛结果对象
        /// </summary>
        /// <param name="resultId"></param>
        /// <returns></returns>
        public TeamResultModels getTeamResult(int resultId)
        {
            try
            {
                return context.TeamResultModels.Single(c => c.teamResutId == resultId);
            }
            catch (Exception e) { return null; }
        }


        public bool updateProblemWithDelegate(Expression<Func<BaseProblemModels, bool>> predicate, 
                                                   Action<BaseProblemModels> action)
        {
            try
            {
                var problem = context.BaseProblemModels.SingleOrDefault(predicate);
                action(problem);
                context.SubmitChanges();
                return true;
            }
            catch (Exception e) { return false; }
        }

        public bool updateResultWithDelegate(Expression<Func<ResultModels, bool>> predicate,
                                                   Action<ResultModels> action)
        {
            try
            {
                var result = context.ResultModels.SingleOrDefault(predicate);
                action(result);
                context.SubmitChanges();
                return true;
            }
            catch (Exception e) { return false; }
        }

        public bool updateSingleResultWithDelegate(Expression<Func<SingleResultModels, bool>> predicate,
                                                   Action<SingleResultModels> action)
        {
            try
            {
                var singleResult = context.SingleResultModels.SingleOrDefault(predicate);
                action(singleResult);
                context.SubmitChanges();
                return true;
            }
            catch (Exception e) { return false; }
        }

        public bool updateTeamResultWithDelegate(Expression<Func<TeamResultModels, bool>> predicate,
                                                   Action<TeamResultModels> action)
        {
            try
            {
                var teamResult = context.TeamResultModels.SingleOrDefault(predicate);
                action(teamResult);
                context.SubmitChanges();
                return true;
            }
            catch (Exception e) { return false; }
        }
    }
}
