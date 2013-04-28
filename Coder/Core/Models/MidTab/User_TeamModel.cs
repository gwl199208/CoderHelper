using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coder.Core.Models.MidTab
{
    public class User_TeamModel
    {
        [Key, Column(Order = 0)]
        public int uid { get; set; }
        [Key, Column(Order = 1)]
        public int teamId { get; set; }
    }
}
