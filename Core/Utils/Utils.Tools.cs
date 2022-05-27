/*
* @classdesc Tools
* @author Copyright (c) 2017-2020, w.l.hikaru (xiaoguang.wang@rjoy.com)
* @date
* @description
*/

using System;
using System.IO;

namespace Core.Utils
{
    /// <summary>
    /// 工具类
    /// </summary>
    public class Tools
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inPath"></param>
        /// <returns></returns>
        public static bool HasWriteAccessToFolder(string inPath)
        {
            try
            {
                string filepath = Path.Combine(inPath, Path.GetRandomFileName());
                using(FileStream fs = new FileStream(filepath, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    StreamWriter writer = new StreamWriter(fs);
                    writer.Write("1");
                }
                File.Delete(filepath);
                return true;
            }
            catch 
            {
                return false;
            }

        }
    }
}