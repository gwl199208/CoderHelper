using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coder.Core.Models.Commons
{
    public class CommonModel
    {
        [Key]
        public int commonId { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string commonContent { get; set; }
    }
}