using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coder.Core.Models.OnlineJudges
{
    public class SingleContestModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int singleContestId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(200)]
        public string singleContestName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime singleContestBegintime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int singleContestTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int singleContestPersonNum { get; set; }
        /// <summary>
        /// 比赛状态
        /// </summary>
        [Required]
        public string singleContestStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string singleContestDescription { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(10)]
        public string singleContestLevel { get; set; }

        /// <summary>
        /// 比赛的头
        /// UserModel
        /// </summary>
        public int  singleContestLeaderId { get; set; }
        /// <summary>
        /// ContestPermissionModel
        /// </summary>
        [Required]
        public int contestPermissionId { get; set; }
        /// <summary>
        /// RuleModel
        /// </summary>
        [Required]
        public int ruleId { get; set; }
    }
}