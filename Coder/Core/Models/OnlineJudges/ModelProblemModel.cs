﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coder.Core.Models.OnlineJudges
{
    public class ModelProblemModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int modelId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(200)]
        public string modelName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "text")]
        public string modelInput { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "text")]
        public string modelOutput { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar")]
        public string modelSampleInput { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar")]
        public string modelSampleOutput { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar")]
        public string modelContent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "text")]
        public string modelExplaination { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "text")]
        [StringLength(10)]
        public string modelCode { get; set; }
    }
}