using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;



namespace Coder.Core.Models.Solutions
{
    public class SolutionModel
    {
        [Key]
        public int solutionId { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string solutionContent { get; set; }

        [Required]
        [StringLength(30)]
        [Column(TypeName = "nvarchar")]
        public string author { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime solutionTime { get; set; }

        /// <summary>
        ///SolutionProblemModel 
        /// </summary>
        [Required]
        public int solutionProblemId { set; get; }
    }
}