using Coder.CompileOfOJ.Dbo;
using Coder.CompileOfOJ.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coder.CompileOfOJ.Service
{
    public class CompileService
    {
        public readonly DbForCompile db = new DbForCompile("server=localhost;Initial catalog=Coder.Db2;User ID=sa; Password=123456;");
    

        public CompileCacheModel getCompileCache()
        {
            return (CompileCacheModel)(from c in db.compileCache
                                               select c).Take(1);

        }

    }
}
