using Coder.Core.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coder.Resources;

namespace Coder.Service
{
    public class FileManagerService : IFileManagerService
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="byt"></param>
        /// <param name="fileType">文件在系统中具体是哪一类</param>
        /// <returns></returns>
        public bool saveFile(string filename, byte[] byt, string fileType)
        {
            try
            {
                string UploadPath = CommonStr.constantFileUploadRoot + "//" + fileType + "//";
                if (!Directory.Exists(UploadPath))
                {
                    Directory.CreateDirectory(UploadPath);
                }
                FileStream fs = new FileStream(UploadPath + filename, FileMode.Append, FileAccess.Write);
                fs.Write(byt, 0, byt.Length);
                fs.Close();
                fs.Dispose();
                return true;
            }
            catch (Exception err)
            {
                try
                {
                    string UploadPath = CommonStr.constantFileUploadRoot + "//" + fileType + "//";
                    string DelFileName = UploadPath + filename;
                    if (File.Exists(DelFileName))
                    {
                        File.Delete(DelFileName);
                    }
                }
                catch (Exception err2)
                {
                    return false;
                }
                return false;
            }
        }
        public bool deleteFile(string FileName, string fileType)
        {
            try
            {
                string UploadPath = CommonStr.constantFileUploadRoot + "//" + fileType + "//";
                string DelFileName = UploadPath + FileName;
                if (File.Exists(DelFileName))
                {
                    File.Delete(DelFileName);
                }
                return true;
            }
            catch(Exception err)
            {
                return false;
            }
        }
        /// <summary>
        /// 获取文件的长度
        /// </summary>
        /// <param name="FileName">文件名</param>
        /// <param name="fileType">文件在系统中具体是哪一类</param>
        /// <returns></returns>
        public long getFileLenth(string FileName, string fileType)
        {
            try
            {
                string UploadPath = CommonStr.constantFileUploadRoot + "//" + fileType + "//";
                string FilePath = UploadPath + FileName;
                if (File.Exists(FilePath))
                {
                    FileInfo f = new FileInfo(FilePath);
                    long Len = f.Length;
                    return Len;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }
        ///   <summary>   
        ///   下载文件   
        ///   </summary>   
        ///   <param   name="fileName">文件的名字,不含路径</param>   
        ///   <param   name="offset">偏移量</param>   
        ///   <param   name="length">读取字节的长度</param>   
        ///   <param name="fileType">文件在系统中具体是哪一类</param>
        ///   <param name="fileType">文件所属目录</param>
        ///   <returns>如果正确则返回字节数组</returns>   
        public byte[] readFileBtyes(string fileName, int offset,
                    out int length, string fileType, string fileRoot)
        {
            length = 0;
            fileName = fileRoot + "\\" + fileType + "\\" + fileName;

            if (!System.IO.File.Exists(fileName))
            {
                return null;
            }

            byte[] bts = new byte[1024*5];
            FileStream fs = null;

            try
            {
                fs = File.OpenRead(fileName);
                fs.Seek(offset, SeekOrigin.Begin);
                length = fs.Read(bts, 0, bts.Length);
                fs.Close();
                if (length > 0)
                {
                    return bts;
                }
            }
            catch (Exception err)
            {
                if (fs != null)
                {
                    fs.Close();
                }
                return null;
            }
            return null;
        }

    }
}
