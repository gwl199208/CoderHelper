using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coder.Core.Models.Functions
{
    public class CodeModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int codeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(10)]
        public string codeType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "text")]
        public string codeApi { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column(TypeName = "nvarchar")]
        public string codeComment { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime codeTime { get; set; }

        /// <summary>
        /// FunctionModel
        /// </summary>
        [Required]
        public int functionId { get; set; }
    }
}