﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coder.Core.Models.OnlineJudges
{
    public class TeamModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int teamId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(200)]
        public string teamName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar")]
        public string teamMotto { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar")]
        public string teamDescription { get; set; }

        /// <summary>
        /// WealthModel
        /// </summary>
        [Required]
        public int wealthId { get; set; }
    }
}