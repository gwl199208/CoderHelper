using Coder.CompileOfOJ.Service;
using Coder.CompilerOfOJ;
using Coder.CompilerOfOJ.Common;
using Coder.CompilerOfOJ.Model;
using Coder.CompilerOfOJ.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Coder.CompileOfOJ
{
    public class Compiler
    {
        readonly CompileService cs = new CompileService();
        
        /// <summary>
        /// 会将runCompiler函数放在一个线程中
        /// 每个runCompiler都会不停的轮巡数据库中的当前题目提交缓存
        /// 然后进行编译输出结果
        /// 
        /// 这里肯定会启动多个线程同时轮巡
        /// </summary>
        public void runCompiler()
        {
            ///
            ///获取当前程序集
            ///
            Assembly assembly = Assembly.GetExecutingAssembly(); 
            ///
            ///从各种语言的xml配置文件中读取其相关的信息
            ///此文件不可丢失
            ///
            var laguageXML = XDocument.Load("../../Resources/laguage.xml");
            var laguages = from laguage in laguageXML.Descendants("laguage")
                         select laguage;

            while (true)
            {
                if (cs.isCompileCacheEmpty())
                    continue;
                ///获取编译所需条件
                ///获取到一个缓存表中的类对象，其所对应的就是一份提交的代码
                ///
                CompileCacheModels compileCache = cs.getCompileCache();
                ///获取最后需要操作的结果对象
                ///
                ResultModels resultModel = null;
                TeamResultModels teamResultModel = null;
                SingleResultModels singleResultModel = null;
                if (0 == compileCache.isSingleContest &&
                    0 == compileCache.isTeamContest)
                    resultModel = cs.getResult(compileCache.resultId);
                else if (0 < compileCache.isSingleContest &&
                         0 == compileCache.isTeamContest)
                    singleResultModel = cs.getSingleResult(compileCache.resultId);
                else if (0 == compileCache.isSingleContest &&
                         0 < compileCache.isTeamContest)
                    teamResultModel = cs.getTeamResult(compileCache.resultId);
                else {
                    //这里有无法向外界展示的异常，但是应该也不会出现！
                }

                
                ///不允许出现代码所用语言类型为空的情况
                ///
                if (String.IsNullOrEmpty(compileCache.codeType))
                { 
                    //这里有异常，内部异常
                    if (resultModel != null)
                    {
                        cs.updateResultWithDelegate(r => r.resut_id == compileCache.resultId, r =>
                        {
                            r.result_status = Resource.RESULT_INNER_ERROR;
                        });
                    }
                    else if (teamResultModel != null)
                    {
                        cs.updateTeamResultWithDelegate(r => r.teamResutId == compileCache.resultId, r =>
                        {
                            r.teamResultStatus = Resource.RESULT_INNER_ERROR;
                        });
                    }
                    else if (singleResultModel != null)
                    {
                        cs.updateSingleResultWithDelegate(r => r.singleResutId == compileCache.resultId, r =>
                        {
                            r.singleResultStatus = Resource.RESULT_INNER_ERROR;
                        });
                    }
                    else { }

                }

                ///获取当前编译所需的语言信息并根据信息找到其对应代码执行
                ///
                XElement laguage;
                try
                {
                    laguage = (from ls in laguages
                               where ls.Attribute("name").Value.Equals(compileCache.codeType.ToUpper())
                               select ls).Take(1).Single();
                    string temCodeClassName = laguage.Attribute("codeClass").Value ;
                    string temFieldName = laguage.Attribute("field").Value ;

                    ///各语言信息中所对应代码所在的类不能为空，代码所对应的方法也不允许为空
                    ///
                    if (String.IsNullOrEmpty(temCodeClassName)
                     || String.IsNullOrEmpty(  temFieldName  ))
                    { 
                        //这里有异常

                    }

                    ///
                    ///
                    //这一步应该用反射，但是当前运气比较衰
                    //铭记一下，在这里干了一件比较2b的事情，在CodeCompileImp中没有把函数搞成public
                    //浪费2个多小时，真是该扇自己两个大耳括子
                    Object temCodeObject = assembly.CreateInstance(temCodeClassName);
                    MethodInfo temFieldInfo = temCodeObject.GetType().GetMethod(temFieldName);
                    BindingFlags flag = BindingFlags.Public | BindingFlags.Instance;

                    ///执行函数的输入参数的构造
                    ///cacheCodeId传过去是为了将本条记录再执行完编译处理后从零时表中删除
                    ///
                    object[] parameters = new object[] {
                        compileCache.cacheCodeFileName  ,  compileCache.uid             ,
                        compileCache.problemId          ,  compileCache.isSingleContest ,
                        compileCache.isTeamContest      ,  compileCache.submitTime      ,
                        compileCache.codePriority       ,  compileCache.cacheCodeId     ,
                        compileCache.resultId           ,  compileCache.contentId
                        };

                    CompileResultModel returnValue = (CompileResultModel)temFieldInfo.Invoke(temCodeObject, 
                            flag, Type.DefaultBinder, parameters, null);
                    //后续操作，善后
                    //1.将当前需要写出的数据写出到相应的表中
                    //2.将当前记录所对应的所有本地文件删除
                    //3.删除缓存表当前处理的记录
                    //这里有异常，内部异常
                    if (resultModel != null)
                    {
                        cs.updateResultWithDelegate(r => r.resut_id == compileCache.resultId, r =>
                        {
                            r.result_time = returnValue.resultTime;
                            r.result_memory = (int)returnValue.resultMemory;
                            r.result_status = returnValue.resultStatus.Trim();
                            r.result_language = returnValue.resultLanguage;
                            r.result_codeLength = returnValue.resultCodeLength;
                            r.baseProblemId = returnValue.problemId;
                        });
                        //对用户代码的存储策略
                        //////////////////////////
                    }
                    else if (teamResultModel != null)
                    {
                        cs.updateTeamResultWithDelegate(r => r.teamResutId == compileCache.resultId, r =>
                        {
                            r.teamResultTime = returnValue.resultTime;
                            r.teamResultMemory = (int)returnValue.resultMemory;
                            r.teamResultStatus = returnValue.resultStatus;
                            r.teamResultStatus = returnValue.resultLanguage;
                            r.teamResultCodeLength = returnValue.resultCodeLength;
                            r.baseProblemId = returnValue.problemId;
                        });
                    }
                    else if (singleResultModel != null)
                    {
                        cs.updateSingleResultWithDelegate(r => r.singleResutId == compileCache.resultId, r =>
                        {
                            r.singleResultTime = returnValue.resultTime;
                            r.singleResultMemory = (int)returnValue.resultMemory;
                            r.singleResultStatus = returnValue.resultStatus;
                            r.singleResultLanguage = returnValue.resultLanguage;
                            r.singleResultCodeLength = returnValue.resultCodeLength;
                            r.baseProblemId = returnValue.problemId;
                        });
                    }
                    else 
                    { }
                    ///删除一条结果对应的本地文件
                    ///
                    bool directory_b = Directory.Exists(returnValue.resultPath);
                    if (directory_b)
                    {
                        DirectoryInfo di = new DirectoryInfo(returnValue.resultPath);
                        di.Delete(true);
                    }
                    ///删除一条结果对应的记录
                    ///
                    cs.delCurrentCompileCache();
                }
                catch (Exception e)
                {
                    //这里有异常
                }
            }    
        }
    }
}
