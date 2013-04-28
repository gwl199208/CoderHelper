using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coder.Core.Models.OnlineJudges
{
    public class ResultModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int resut_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string result_status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int result_memory { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int result_time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(10)]
        public string result_language { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime result_submitTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int result_codeLength { get; set; }

        /// <summary>
        /// UserModel
        /// </summary>
        [Required]
        public int userId { get; set; }
        /// <summary>
        /// ResultCodeModel
        /// </summary>
        [Required]
        public int resultCodeId { get; set; }
        /// <summary>
        /// BaseProblemModel
        /// </summary>
        [Required]
        public int baseProblemId { get; set; }
    }
}