using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coder.Core.Models.Functions
{
    public class FunctionPlateModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int functionPlateId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(200)]
        public string functionPlateName { get; set; }

    }
}