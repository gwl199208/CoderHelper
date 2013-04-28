using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coder.Core.Service
{
    //怎样保证文件名不会重复，还有文件的据对绑定
    /// <summary>
    /// 对上传文件管理，系统定制文件路径
    /// </summary>
    public interface IFileManagerService
    {
        bool saveFile(string filename, byte[] byt, string fileType);
        bool deleteFile(string FileName, string fileType);
        long getFileLenth(string FileName, string fileType);
        byte[] readFileBtyes(string fileName, int offset, 
                    out int length, string fileType, string fileRoot);
    }
}
