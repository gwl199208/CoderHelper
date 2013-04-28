using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coder.CompilerOfOJ.Model
{
    public class CompileResultModel
    {
        /// <summary>
        /// DANGEROUS   ：危险代码
        /// COMPILE_ERROR   ：编译错误
        /// </summary>
        public string resultStatus { get; set; }
        public long resultMemory { get; set; }
        public int resultTime { get; set; }
        public string resultLanguage { get; set; }
        public int resultCodeLength { get; set; }
        /// <summary>
        /// 对应一条记录存储结果的路径
        /// </summary>
        public string resultPath { get; set; }
        /// <summary>
        /// 对应结果表的id
        /// </summary>
        public int resultId { get; set; }
        /// <summary>
        /// 比赛类型，0不是比赛，1是个人赛，2是团体赛
        /// </summary>
        public int contestType { get; set; }
        /// <summary>
        /// 若是比赛的话对应比赛表中的id
        /// </summary>
        public int contestId { get; set; }
        /// <summary>
        /// 对应题目表中的id
        /// </summary>
        public int problemId { get; set; }
        /// <summary>
        /// 对应用户表中的id
        /// </summary>
        public int userId { get; set; }
    }
}
