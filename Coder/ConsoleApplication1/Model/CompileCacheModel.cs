using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coder.CompileOfOJ.Model
{
    /// <summary>
    /// 临时源码根据上传的规则自动存储到相应的位置
    /// 并且在本表中存储其文件名，上传时间，类型，处理优先级（比赛优先于个人）
    /// 在编译模块选择编译的时候，首先取优先级高且时间在最前边的处理
    /// </summary>
    public class CompileCacheModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int cacheCodeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(15)]
        public string codeType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar")]
        public String cacheCodeFileName { get; set; }

        /// <summary>
        ///代码提交时间 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime submitTime { get; set; }
        /// <summary>
        ///代码优先级 
        /// </summary>
        [Required]
        public int codePriority { get; set; }
    }
}
