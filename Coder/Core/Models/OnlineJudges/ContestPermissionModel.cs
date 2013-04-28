using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coder.Core.Models.OnlineJudges
{
    public class ContestPermissionModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int permissionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(16)]
        public string password { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public bool ischeck { get; set; }
        /// <summary>
        /// condition ：筛选条件
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar")]
        public string condition { get; set; }
    }
}