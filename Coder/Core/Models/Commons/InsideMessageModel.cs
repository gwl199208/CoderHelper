﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coder.Core.Models.Commons
{
    public class InsideMessageModel
    {
        [Key]
        public int messageId { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string messagecontent { get; set; }
       /// <summary>
        /// UserModel
        /// </summary>
        [Required]
        public int userId { get; set; }
    }
}