using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Coder.Core.Models.OnlineJudges;

namespace Coder.Core.Models.Commons
{
    public class UserModel
    {
        [Key]
        public int uid { get; set; }
        [Required]
        [StringLength(30)]
        public string username { get; set; }

        [Required]
        [StringLength(16)]
        public string password { get; set; }

        [Required]
        [StringLength(5)]
        public string sex { get; set; }

        [StringLength(30)]
        public string school { get; set; }

        [StringLength(30)]
        public string email { get; set; }

        public DateTime birthday { get; set; }

        [Required]
        [StringLength(30)]
        public string nickname { get; set; }

        [StringLength(100)]
        public string motto { get; set; }
        [Required]
        public DateTime lastVisited { get; set; }
        [Required]
        public int solvedNumber { get; set; }
        [Required]
        public int submitNumber { get; set; }
        /// <summary>
        /// PowerViewModel
        /// </summary>
        [Required]
        public int powerViewId { get; set; }
        /// <summary>
        /// TeamModel
        /// </summary>
        [Required]
        public int teamId { get; set; }
        /// <summary>
        /// LevelModel
        /// </summary>
        [Required]
        public int levelId { get; set; }
        /// <summary>
        /// WealthModel
        /// </summary>
        [Required]
        public int wealthId { get; set; }
        /// <summary>
        /// SourceModel
        /// </summary>
        [Required]
        public int sourceId { get; set; }
    }
}