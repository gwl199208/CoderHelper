using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coder.Core.Models.OnlineJudges
{
    public class SourceModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int sourceId { get; set; }

        /// <summary>
        /// CompanyModel
        /// </summary>
        [Required]
        public int  companyId { get; set; }
        /// <summary>
        /// UserModel
        /// </summary>
        [Required]
        public int  userId { get; set; }
    }
}