using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Coder.Core.Models.OnlineJudges;

namespace Coder.Core.Models.Commons
{
    public class RuleModel
    {
        [Key]
        public int ruleId { get; set; }
        [StringLength(15)]
        public string ruleMoney { get; set; }
        [StringLength(15)]
        public string rulePoint { get; set; }
        [StringLength(30)]
        public string ruleHonor { get; set; }
        [Required]
        public string ruleInfo { get; set; }
        /// <summary>
        /// PowerViewModel
        /// </summary>
        [Required]
        public int powerViewId { get; set; }
    }
}