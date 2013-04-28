using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coder.Core.Models.MidTab
{
    public class BaseProblem_SingleContestModel
    {
        [Key, Column(Order = 0)]
        public int baseProblemId { get; set; }
        [Key, Column(Order = 1)]
        public int singleContestId { get; set; }
    }
}
