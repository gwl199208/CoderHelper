using Coder.CompileOfOJ.Service;
using Coder.CompilerOfOJ.Model;
using Coder.CompilerOfOJ.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Coder.CompilerOfOJ.Common
{
    /// <summary>
    /// 代码的编译类
    /// </summary>
    /// 每个线程代码通过调用本类相应的函数进行代码编译,
    /// 并且返回一个执行结果
    /// 
    public class CodeCompileImp
    {
        readonly CompileService cs = new CompileService();
        /// <summary>
        /// 对c语言的代码进行编译
        /// 所需输入参数：
        ///         源码路径、空间限制、时间限制、谁做的题、
        ///     做的哪道题、是否属于个人赛、是否属于团体赛
        ///     提交时间、编译优先级、记录在缓存表中的标识
        /// </summary>
        /// <param name="cacheCodeFileName"></param>
        /// <param name="uid"></param>
        /// <param name="problemId"></param>
        /// <param name="isSingleContest"></param>
        /// <param name="isTeamContest"></param>
        /// <param name="submitTime"></param>
        /// <param name="codePriority"></param>
        /// <param name="cacheCodeId"></param>
        /// <param name="resultId"></param>
        /// <param name="contestId"></param>
        /// <returns></returns>
        public CompileResultModel runCodeOfC(
            string cacheCodeFileName ,  int      uid             ,
            int    problemId         ,  int      isSingleContest ,
            int    isTeamContest     ,  DateTime submitTime      ,
            int    codePriority      ,  int      cacheCodeId     ,
            int    resultId          ,  int      contestId       )
        {
            //源码进行编译时所需命令参数
            string commond = " -o " + cacheCodeFileName + resultId + ".exe "                 
                 + cacheCodeFileName + resultId + ".c";
            //实际运行结果文件所需命令参数
            string runCommond = null;
            //运行后可执行文件路径
            string executableFilePath = cacheCodeFileName + resultId + ".exe";
            return runCode(cacheCodeFileName ,   uid     ,
                    problemId         ,  isSingleContest ,
                    isTeamContest     ,  submitTime      ,
                    codePriority      ,  cacheCodeId     ,
                    resultId          ,  contestId       ,
                    Resource.LANGUE_C ,  Resource.COMPILER_C ,
                    commond, runCommond, executableFilePath);
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cacheCodeFileName"></param>
        /// <param name="uid"></param>
        /// <param name="problemId"></param>
        /// <param name="isSingleContest"></param>
        /// <param name="isTeamContest"></param>
        /// <param name="submitTime"></param>
        /// <param name="codePriority"></param>
        /// <param name="cacheCodeId"></param>
        /// <param name="resultId"></param>
        /// <param name="contestId"></param>
        /// <returns></returns>
        public CompileResultModel runCodeOfCPlusPlus(
            string cacheCodeFileName   , int       uid             ,
            int    problemId           , int       isSingleContest ,
            int    isTeamContest       , DateTime  submitTime      ,
            int    codePriority        , int       cacheCodeId     ,
            int    resultId            , int       contestId       )
        {
            //源码进行编译时所需命令参数
            string commond = " -o " + cacheCodeFileName + resultId + ".exe "                 
                 + cacheCodeFileName + resultId + ".cpp";
            //实际运行结果文件所需命令参数
            string runCommond = null;                                                              
            //运行后可执行文件路径
            string executableFilePath = cacheCodeFileName + resultId + ".exe";
            return runCode(cacheCodeFileName, uid,
                    problemId, isSingleContest,
                    isTeamContest, submitTime,
                    codePriority, cacheCodeId,
                    resultId, contestId,
                    Resource.LANGUE_CPLUSPLUS, Resource.COMPILER_CPLUSPLUS,
                    commond, runCommond, executableFilePath);
        }

        public CompileResultModel runCodeOfJava(
            string cacheCodeFileName, int uid,
            int problemId, int isSingleContest,
            int isTeamContest, DateTime submitTime,
            int codePriority, int cacheCodeId,
            int resultId, int contestId)
        {
            //源码进行编译时所需命令参数
            string commond = cacheCodeFileName + resultId + "\\Main.java";
            //实际运行结果文件所需命令参数
            string runCommond = "-cp "+cacheCodeFileName + resultId + " Main > " 
                + cacheCodeFileName + resultId + Resource.EXTENTION; ;
            //运行后可执行文件路径
            string executableFilePath = "java";
            return runCode(cacheCodeFileName, uid,
                    problemId, isSingleContest,
                    isTeamContest, submitTime,
                    codePriority, cacheCodeId,
                    resultId, contestId,
                    Resource.LANGUE_JAVA, Resource.COMPILER_JAVA,
                    commond, runCommond, executableFilePath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cacheCodeFileName"></param>
        /// <param name="uid"></param>
        /// <param name="problemId"></param>
        /// <param name="isSingleContest"></param>
        /// <param name="isTeamContest"></param>
        /// <param name="submitTime"></param>
        /// <param name="codePriority"></param>
        /// <param name="cacheCodeId"></param>
        /// <param name="resultId"></param>
        /// <param name="contestId"></param>
        /// <param name="p"></param>
        /// <param name="commond"></param>
        /// <param name="runCommond"></param>
        /// /// <param name="executableFilePath"></param>
        /// <returns></returns>
        private CompileResultModel runCode(string cacheCodeFileName, int uid, 
                        int problemId,int isSingleContest, int isTeamContest, 
                      DateTime submitTime, int codePriority, int cacheCodeId,
                  int resultId, int contestId, string langue,string compiler,
                string commond, string runCommond, string executableFilePath)
        {
            CompileResultModel compileResult = new CompileResultModel()
            {
                resultLanguage = langue,                                                //第一处不同
                userId = uid,
                problemId = problemId,
                resultId = resultId,
                contestId = contestId,
                resultPath = cacheCodeFileName + resultId 
            };
            BaseProblemModels problem = cs.getProblem(problemId);

            baseCheck(isSingleContest, isTeamContest, compileResult);
            ///检查代码是否安全,若安全将代码长度写入结果对象
            ///
            long codeLength = 0;
            if (!checkSourceCode(cacheCodeFileName, cacheCodeId.ToString(), langue, out codeLength))
            {
                compileResult.resultStatus = Resource.RESULT_DANGEROUS;
                return compileResult;
            }

            ///源码进行编译
            ///
            string ErrorStr = null;
            string OutputStr = null;
            if (!compileSourceCode(commond, compiler,
                                  out ErrorStr, out OutputStr))
            {
                compileResult.resultStatus = Resource.RESULT_COMPILE_ERROR;
                return compileResult;
            }

            ///分析编译结果
            /// 先对java特殊处理一下
            if (langue != Resource.LANGUE_JAVA && !File.Exists(executableFilePath))
            { compileResult.resultStatus = Resource.RESULT_COMPILE_ERROR; return compileResult; }

            ///执行编译结果
            ///
            string standardInFilePath = Resource.ROOT_STANDARD_IN_PATH + problemId + Resource.EXTENTION;
            string standardOutFilePath = Resource.ROOT_STANDARD_OUT_PATH + problemId + Resource.EXTENTION;
            //实际运行结果文件
            string runExeName = executableFilePath;
            string outputFilePath = cacheCodeFileName + resultId + Resource.EXTENTION;

            if (!File.Exists(standardOutFilePath) || problem == null)
            //每道题必有运行结果,所以肯定对应着相应的标准输出文件
            { compileResult.resultStatus = Resource.RESULT_INNER_ERROR; return compileResult; }

            if (!runEXE(runExeName, standardInFilePath, outputFilePath, runCommond,
                                             problem, out ErrorStr, compileResult))
            {
                compileResult.resultStatus = Resource.RESULT_RUNTIME_ERROR;
                return compileResult;
            }

            ///
            /// 
            ///看看是否超时或者超内存
            if (compileResult.resultTime > problem.time_limit)
            { compileResult.resultStatus = Resource.RESULT_TIME_LIMIT_EXCEED; return compileResult; }
            if (compileResult.resultMemory > problem.memory_limit)
            { compileResult.resultStatus = Resource.RESULT_MEMORY_LIMIT_EXCEED; return compileResult; }
            
            ///分析运行结果
            ///
            if (!fileCompare(standardOutFilePath, outputFilePath, compileResult))
            {
                compileResult.resultStatus = Resource.RESULT_INNER_ERROR;
                return compileResult;
            }

            return compileResult;
        }

        private static void baseCheck(int isSingleContest, int isTeamContest, CompileResultModel compileResult)
        {
            if (isSingleContest != 0) compileResult.contestType = Convert.ToInt16(Resource.CONTEST_SINGLE);
            if (isTeamContest != 0) compileResult.contestType = Convert.ToInt16(Resource.CONTEST_TEAM);
            if (isTeamContest == 0 && isSingleContest == 0)
                compileResult.contestType = Convert.ToInt16(Resource.CONTEST_NOT_A);
        }

        
        /// <summary>
        /// 工具函数,检查代码的安全性
        /// </summary>
        /// <param name="codeFilePath">源码所在目录</param>
        /// <param name="codeFileName">源码名</param>
        /// <param name="codeLength"></param>
        /// <returns></returns>
        private bool checkSourceCode(string codeFilePath, string codeFileName , 
                                     string langue      , out long codeLength )
        {
            codeLength = 0;
            return true;
        }
        /// <summary>
        /// 工具函数,对代码进行编译
        /// </summary>
        /// <param name="cacheCodeFileName"></param>
        /// <param name="cacheCodeId"></param>
        /// <param name="compiler"></param>
        /// <param name="ErrorStr"></param>
        /// <param name="OutputStr"></param>
        /// <returns></returns>
        private bool compileSourceCode(string commond , string compiler, 
                              out string errorStr, out string outputStr)
        {
            try
            {
                Process proCompile = new Process();
                proCompile.StartInfo.UseShellExecute = false;
                proCompile.StartInfo.FileName = compiler;
                proCompile.StartInfo.CreateNoWindow = true;
                proCompile.StartInfo.ErrorDialog = false;
                proCompile.StartInfo.RedirectStandardError = true;
                proCompile.StartInfo.RedirectStandardOutput = true;
                proCompile.StartInfo.Arguments = commond;
                proCompile.Start();
                errorStr = proCompile.StandardError.ReadToEnd();
                outputStr = proCompile.StandardOutput.ReadToEnd();
                proCompile.Close();
                proCompile.Dispose();
                if (String.IsNullOrEmpty(errorStr))
                    return true;  return false; 
            }
            catch (Exception e) { errorStr = Resource.ERROR_COMPILER; outputStr = null; return false; }
        }

        readonly StringBuilder _systemOutString = new StringBuilder();
        readonly StringBuilder _currentOutString = new StringBuilder();
        /// <summary>
        /// 运行编译结果
        /// </summary>
        /// <param name="runExeName">所调运的可执行文件名</param>
        /// <param name="inputFilePath">运行结果输入文件</param>
        /// <param name="outputFilePath">运行结果输出文件</param>
        /// <param name="runCommond">运行时参数</param>
        /// <param name="timeLimit"></param>
        /// <param name="errorStr">运行中断时候的流错误</param>
        /// <param name="compileResult">储存运行结果</param>
        /// <returns></returns>
        private bool runEXE(string runExeName , string inputFilePath , 
                string outputFilePath ,string runCommond, 
                BaseProblemModels problem, 
                out string errorStr, CompileResultModel compileResult)
        {
            string temOutPut ;
            try
            {
                //新建运行可执行文件的进程
                var excute = new Process
                {
                    StartInfo =
                    {
                        FileName = runExeName,
                        //WindowStyle = ProcessWindowStyle.Hidden,
                        UseShellExecute = false,
                        //CreateNoWindow = true,
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        ErrorDialog = false,
                        Arguments = runCommond
            
                    }
                };
                //若有标准输入文件,从该输入文件读入输入信息
                string inputString = null ;
                try{
                    using (FileStream fs = new FileStream(inputFilePath, FileMode.Open))
                    {
                        using (StreamReader reader = new StreamReader(fs, Encoding.UTF8))
                        {
                            inputString = reader.ReadToEnd();
                        }
                    }
                }
                catch(Exception e) {}
                //运行过程
                TimeSpan begin = System.DateTime.Now.TimeOfDay;
                excute.Start();
                compileResult.resultMemory = (excute.PeakWorkingSet64 >> 10);
                if (!String.IsNullOrEmpty(inputString)) { excute.StandardInput.Write(inputString); }
                temOutPut = excute.StandardOutput.ReadToEnd();
                
                while (!excute.HasExited)
                {
                    Thread.Sleep(100);
                }
                TimeSpan end = System.DateTime.Now.TimeOfDay;
                errorStr = excute.StandardError.ReadToEnd();

                compileResult.resultTime = (int)end.Subtract(begin).TotalMilliseconds;
                
                excute.Close();
                excute.Dispose();
                //运行过程结束

                //把java作为例外处理
                //if (compileResult.resultLanguage.Equals(Resource.LANGUE_JAVA)) 
                //{ return true; }
                //若存在运行结果将运行结果写入指定输出路径
                if (String.IsNullOrEmpty(temOutPut))
                { compileResult.resultStatus = Resource.RESULT_RUNTIME_ERROR; return false; }
                using (FileStream fs = new FileStream(outputFilePath, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(fs, Encoding.UTF8))
                    {
                        writer.Write(temOutPut);
                    }
                }
                return true;
            }//try end
            catch (Exception e){ errorStr = Resource.ERROR_RUN; return false; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="standardOutputFile">标准输出文件</param>
        /// <param name="realOutputFile">实际输出文件</param>
        /// <param name="compileResult">一条结果记录</param>
        /// <returns></returns>
        private bool fileCompare(string standardOutputFile, string realOutputFile,
                                                 CompileResultModel compileResult)
        {
            bool returnFlag = false;
            //  判断相同的文件是否被参考两次。
            if(standardOutputFile == realOutputFile)
            {   
                compileResult.resultStatus = Resource.RESULT_INNER_ERROR;
                return true;    
            }

            int standardOutByte = 0;
            int realOutByte = 0;

            try
            {
                using (FileStream fsStandardOutput = new FileStream(standardOutputFile, FileMode.Open),
                fsRealOutput = new FileStream(realOutputFile, FileMode.Open))
                {
                    //  检查文件大小。如果两个文件的大小并不相同,则视为不相同或格式错误。
                    if (fsStandardOutput.Length != fsRealOutput.Length)
                    {
                        //将流指针位置归0
                        fsStandardOutput.Seek(0, 0);
                        fsRealOutput.Seek(0, 0);
                        using (StreamReader srStandardOutput = new StreamReader(fsStandardOutput),
                               srRealOutput = new StreamReader(fsRealOutput))
                        {
                            if (srStandardOutput.ReadToEnd().Trim()
                            .Equals(srRealOutput.ReadToEnd().Trim()))
                            {
                                compileResult.resultStatus = Resource.RESULT_PRESENTATION_ERROR;
                                returnFlag = true;
                            }
                            else
                            {
                                compileResult.resultStatus = Resource.RESULT_COMPILE_ERROR;
                                returnFlag = true;
                            }
                            srStandardOutput.Close();
                            srRealOutput.Close();
                        }
                    }
                    else
                    {
                        //  逐一比较两个文件的每一个字节,直到发现不相符或已到达文件尾端为止。
                        do
                        {
                            standardOutByte = fsStandardOutput.ReadByte();
                            realOutByte = fsRealOutput.ReadByte();
                        } while
                            ((standardOutByte == realOutByte) && (standardOutByte != -1));
                        if ((standardOutByte - realOutByte) == 0)
                        {
                            compileResult.resultStatus = Resource.RESULT_ACCEPTED;
                            returnFlag = true;
                        }
                        else
                        {
                            //将流指针位置归0然后再读
                            fsStandardOutput.Seek(0,0);
                            fsRealOutput.Seek(0, 0);
                            using (StreamReader srStandardOutput = new StreamReader(fsStandardOutput),
                                   srRealOutput = new StreamReader(fsRealOutput))
                            {
                                Console.WriteLine(srStandardOutput.ReadToEnd().Trim());
                                Console.WriteLine(srRealOutput.ReadToEnd().Trim());
                                if (srStandardOutput.ReadToEnd().Trim()
                                .Equals(srRealOutput.ReadToEnd().Trim()))
                                {
                                    compileResult.resultStatus = Resource.RESULT_PRESENTATION_ERROR;
                                    returnFlag = true;
                                }
                                else
                                {
                                    compileResult.resultStatus = Resource.RESULT_COMPILE_ERROR;
                                    returnFlag = true;
                                }
                                srStandardOutput.Close();
                                srRealOutput.Close();
                            }

                        }
                    }
                    fsStandardOutput.Close();
                    fsRealOutput.Close();
                }
                return returnFlag;
            }
            catch (Exception e) { return false; }
        }
    }
}
