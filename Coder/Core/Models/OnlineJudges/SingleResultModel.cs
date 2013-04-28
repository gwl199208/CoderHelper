using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coder.Core.Models.OnlineJudges
{
    public class SingleResultModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int singleResutId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string singleResultStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int singleResultMemory { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int singleResultTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(10)]
        public string singleResultLanguage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime singleResultSubmitTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int singleResultCodeLength { get; set; }

        /// <summary>
        /// SingleContestModel
        /// </summary>
        [Required]
        public int singleContestId { get; set; }
        /// <summary>
        ///  BaseProblemModel 
        /// </summary>
        [Required]
        public int baseProblemId { get; set; }
        /// <summary>
        /// UserModel
        /// </summary>
        [Required]
        public int userId { get; set; }
    }
}