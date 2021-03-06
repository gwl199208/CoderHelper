﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coder.Core.Models.Commons
{
    public class CommentModel
    {
        [Key]
        public int commentId { get; set; }
        [Required]
        [StringLength(10)]
        public string commentPlate { get; set; }
        [Required]
        public int plateElementId { get; set; }
        [Required]
        [StringLength(200)]
        public string commentContent { get; set; }
        /// <summary>
        /// UserModel
        /// </summary>
        [Required]
        public int userId { get; set; }
    }
}