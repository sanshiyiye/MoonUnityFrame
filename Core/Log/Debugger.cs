/*
* @classdesc Debugger
* @author Copyright (c) 2017-2020, w.l.hikaru (xiaoguang.wang@rjoy.com)
* @date
* @description
*/

using System;

namespace Core.Log
{
    /// <summary>
    /// 
    /// </summary>
    public class Debuger
    {
        /// <summary>
        /// Check if a object null，条件不满足打印Error，不会中断当前调用
        /// </summary>
        public static bool Check(object obj, string formatStr = null, params object[] args)
        {
            if (obj != null) return true;

            if (string.IsNullOrEmpty(formatStr))
                formatStr = "[Check Null] Failed!";

            Logger.Error(LogLevel.SYS,"[!!!]" + formatStr, args);
            return false;
        }
        
        /// <summary>
        /// 条件不满足打印Error，不会中断当前调用
        /// </summary>
        public static bool Check(bool result, string formatStr = null, params object[] args)
        {
            if (result) return true;

            if (string.IsNullOrEmpty(formatStr))
                formatStr = "Check Failed!";

            Logger.Error(LogLevel.SYS,"[!!!]" + formatStr, args);
            return false;
        }
        
        /// <summary>
        /// 条件不满足会中断当前调用
        /// </summary>
        public static void Assert(bool result)
        {
            Assert(result, null);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="msg"></param>
        /// <param name="args"></param>
        /// <exception cref="Exception"></exception>
        public static void Assert(bool result, string msg, params object[] args)
        {
            if (!result)
            {
                string formatMsg = $"[Error]{DateTime.Now.ToString("HH:mm:ss.fff")} Assert Failed! ";
                if (!string.IsNullOrEmpty(msg))
                {
                    if (args != null && args.Length > 0)
                        msg = string.Format(msg, args);
                    formatMsg += msg;
                }

                //Log.LogErrorWithStack(formatMsg, 2); //Exception会打印error，这里不再打印error
                throw new Exception(formatMsg); // 中断当前调用
            }
        }
        
        /// <summary>
        /// 当前值是否!=0
        /// </summary>
        public static void Assert(int result)
        {
            Assert(result != 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        public static void Assert(Int64 result)
        {
            Assert(result != 0);
        }
        
        /// <summary>
        /// 检查参数是否为null，条件不满足会中断当前调用
        /// </summary>
        public static void Assert(object obj)
        {
            Assert(obj != null);
        }

       
    }

}