﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coder.Core.Models.OnlineJudges
{
    public class BaseProblemModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int pid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(200)]
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "text")]
        public string content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "text")]
        public string input { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "text")]
        public string output { get; set; }
        /// <summary>
        /// 用户可见的样例输入
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar")]
        public string sampleInput { get; set; }
        /// <summary>
        /// 用户可见的样例输出
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar")]
        public string sampleOutput { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int memory_limit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int time_limit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int accepteds { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int submiteds { get; set; }

        /// <summary>
        /// SourceModel
        /// </summary>
        [Required]
        public int sourceId { get; set; }
        /// <summary>
        /// ModelProblemModel
        /// </summary>
        [Required]
        public int modelProblemId { get; set; }
    }
}