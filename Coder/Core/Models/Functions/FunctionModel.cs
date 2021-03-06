﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coder.Core.Models.Functions
{
    public class FunctionModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int functionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(200)]
        public string functionName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar")]
        public string functionDescription { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(10)]
        public string functionType { get; set; }

        /// <summary>
        /// FunctionPlateModel
        /// </summary>
        [Required]
        public int functionPlateId { get; set; }
    }
}