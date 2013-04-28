using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coder.Core.Models.OnlineJudges
{
    public class TeamContestModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int teamContestId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(200)]
        public string teamContestName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime teamContestBegintime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int teamContestTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int teamContestPersonnum { get; set; }
        /// <summary>
        /// 比赛状态
        /// </summary>
        [Required]
        public string teamContestStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar")]
        public string teamContestDescription { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(10)]
        public string teamContestLevel { get; set; }

        /// <summary>
        /// 团队赛的头
        /// UserModel
        /// </summary>
        [Required]
        public int teamContestLeaderId { get; set; }
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