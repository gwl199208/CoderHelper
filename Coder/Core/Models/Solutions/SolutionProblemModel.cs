using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coder.Core.Models.Solutions
{
    public class SolutionProblemModel
    {
        [Key]
        public int solutionProbelmId { get; set; }
        [Required]
        public DateTime solutionProblemTime { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string solutionProblemDescription { get; set; }
        /// <summary>
        /// TypeModel
        /// </summary>
        [Required]
        public int typeId { get; set; }
    }
}