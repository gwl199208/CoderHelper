using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coder.Core.Models.Commons
{
    public class PowerViewModel
    {
        [Key]
        public int powerViewId { get; set; }
        [Required]
        [StringLength(20)]
        public string powerViewName { get; set; }
        /// <summary>
        /// powerArray:先缓缓 有特定格式来着
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar")]
        public object powerArrray { get; set; }
    }
}