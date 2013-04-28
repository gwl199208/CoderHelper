using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coder.Core.Models.OnlineJudges
{
    public class ListModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int listId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(10)]
        public string listType { get; set; }

        /// <summary>
        /// UserModel
        /// </summary>
        [Required]
        public int userId { get; set; }
        /// <summary>
        /// BaseProblemModel 
        /// </summary>
        [Required]
        public int baseProblemId { get; set; }
    }
}