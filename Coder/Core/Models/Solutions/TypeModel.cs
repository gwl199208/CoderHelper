using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coder.Core.Models.Solutions
{
    public class TypeModel
    {
        [Key]
        public int typeId { get; set; }
        [Required]
        [StringLength(20)]
        public string typeName { get; set; }
    }
}