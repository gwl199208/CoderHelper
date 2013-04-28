using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coder.Core.Service
{
    public interface IReadyForCompileService
    {
        /// <summary>
        /// /////////////////////////
        /// </summary>
        /// <param name="codeType"></param>
        void CreatFile(string codeType) ;
    }
}
