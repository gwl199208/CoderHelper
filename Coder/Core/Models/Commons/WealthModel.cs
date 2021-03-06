﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Coder.Core.Models.OnlineJudges;

namespace Coder.Core.Models.Commons
{
    public class WealthModel
    {
        [Key]
        public int wealthId { get; set; }
        [Required]
        public int money { get; set; }
        [Required]
        public int point { get; set; }
        [StringLength(100)]
        public string honor { get; set; }
        /// <summary>
        /// UserModel
        /// </summary>
        [Required]
        public int userId { get; set; }
        /// <summary>
        /// TeamModel
        /// </summary>
        public int teamId { get; set; }
    }
}