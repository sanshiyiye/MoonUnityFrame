/*
* @classdesc TextTools
* @author Copyright (c) 2017-2020, w.l.hikaru (xiaoguang.wang@rjoy.com)
* @date
* @description
*/

using System;
using System.Diagnostics;
using System.Text;

namespace Core.Utils
{
    /// <summary>
    /// 字符相关的实用函数。
    /// </summary>
    public static partial class TextUtility
    {
        private static ITextHelper s_TextHelper = null;

        /// <summary>
        /// 设置字符辅助器。
        /// </summary>
        /// <param name="textHelper">要设置的字符辅助器。</param>
        public static void SetTextHelper(ITextHelper textHelper)
        {
            s_TextHelper = textHelper;
        }

        /// <summary>
        /// 获取格式化字符串。
        /// </summary>
        /// <typeparam name="T">字符串参数的类型。</typeparam>
        /// <param name="format">字符串格式。</param>
        /// <param name="arg">字符串参数。</param>
        /// <returns>格式化后的字符串。</returns>
        public static string Format<T>(string format, params T[] arg)
        {
            if (format == null)
            {
                throw new GameException("Format is invalid.");
            }

            if (s_TextHelper == null)
            {
                return string.Format(format, arg);
            }

            return s_TextHelper.Format(format, arg);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string GetExceptionTrack(Exception e)
        {
            StringBuilder builder = new StringBuilder(120);
            builder.Append("Error:" + e.Message).Append("\r\n");
            if (!string.IsNullOrEmpty(e.StackTrace))
            {
                builder.Append(e.StackTrace);
            }
            return builder.ToString();
        }
        
        private static StackTrace StackTrace
        {
            get { return new StackTrace(3, true); }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="instackTrace"></param>
        /// <returns></returns>
        public  static string TrackFormatting(StackTrace instackTrace = null)
        {
            instackTrace = instackTrace ?? StackTrace;
            return instackTrace.ToString();

        }
        
        private static string GetBriefnessTrack(StackFrame frame)
        {
            var dcName = frame.GetMethod().DeclaringType.Name;
            var mName = frame.GetMethod().Name;
            var param = GetParameters(frame.GetMethod());
            var rPath = frame.GetFileName();
            if (string.IsNullOrEmpty(rPath))
            {
                rPath = frame.GetNativeImageBase().ToString();
            }
            
            var num = frame.GetFileLineNumber();
            return string.Format("{0}:{1}({2}) (at {3}:{4,3})",
                dcName,
                mName,
                param,
                rPath,
                num);
        }
        
        
        private static string GetParameters(System.Reflection.MethodBase methodBase)
        {
            StringBuilder builder = new StringBuilder(1);
            foreach (var item in methodBase.GetParameters())
            {
                builder.Append(item.ParameterType.Name);
            }
            return builder.ToString();
        }

        private static string GetRelativePath(string path)
        {
            if (string.IsNullOrEmpty(path)) return "";
            path = path.Substring(path.IndexOf("Assets"));
            path = path.Replace('\\', '/');
            return path;
        }
        
    }

}