using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Coder.Core.Models.OnlineJudges;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coder.Core.Models.Commons
{
    public class CompanyModel
    {
        [Key]
        public int companyId { get; set; }
        [Required]
        [StringLength(100)]
        public string companyName { get; set; }
        /// <summary>
        /// SourceModel
        /// </summary>
        [Required]
        public int sourceId { get; set; }
    }
}