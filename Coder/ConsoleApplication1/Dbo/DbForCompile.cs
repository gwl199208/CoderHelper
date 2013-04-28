using Coder.CompileOfOJ.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coder.CompileOfOJ.Dbo
{
    public class DbForCompile : DbContext
    {
        public DbForCompile(string strCon)
            : base(strCon)
        {
        }
        public DbSet<CompileCacheModel> compileCache { get; set; }
    }
}
