using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coder.Core.Models.OnlineJudges
{
    public class TeamResultModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int teamResutId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string teamResultStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int teamResultMemory { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int teamResultTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(10)]
        public string teamResultLanguage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime teamResultSubmitTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int teamResultCodeLength { get; set; }
        /// <summary>
        /// TeamContestModel 
        /// </summary>
        [Required]
        public int teamContestId { get; set; }
        /// <summary>
        /// BaseProblemModel 
        /// </summary>
        [Required]
        public int baseProblemId { get; set; }
        /// <summary>
        /// TeamModel
        /// </summary>
        [Required]
        public int teamId { get; set; }
        /// <summary>
        /// UserModel
        /// </summary>
        [Required]
        public int userId { get; set; }
    }
}