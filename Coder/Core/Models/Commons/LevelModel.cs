﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coder.Core.Models.Commons
{
    public class LevelModel
    {
        [Key]
        public int levelId { get; set; }
        [Required]
        public string levelDescription { get; set; }
    }
}