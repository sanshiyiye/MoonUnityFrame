/*
* @classdesc Logger
* @author Copyright (c) 2017-2020, w.l.hikaru (xiaoguang.wang@rjoy.com)
* @date
* @description
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.Log
{

    /// <summary>
    /// 
    /// </summary>
    public enum LogType : byte
    {
        /// <summary>
        /// 
        /// </summary>
        CORE = 1,
        /// <summary>
        /// 
        /// </summary>
        SYS = 2,
        /// <summary>
        /// 
        /// </summary>
        FRAME = 4,
        /// <summary>
        /// 
        /// </summary>
        UI = 8,
        /// <summary>
        /// 
        /// </summary>
        SCENE = 16,
        /// <summary>
        /// 
        /// </summary>
        CHANNEL1 = 32,
        /// <summary>
        /// 
        /// </summary>
        CHANNEL2 = 64,
        /// <summary>
        /// 
        /// </summary>
        CHANNEL3 = 128

    }
    /// <summary>
    /// 日志工具
    /// </summary>
    public partial class Logger
    {
        private static StringBuilder s_logStr = new StringBuilder();

        /// <summary>
        /// 
        /// </summary>
        private static bool mEnableLog = false;
        
        /// <summary>
        /// 
        /// </summary>
        private static Dictionary<LogType,ILogHandler> mLogHandler;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inType"></param>
        /// <param name="inLogHandler"></param>
        public static void AddLogHandler(LogType inType,ILogHandler inLogHandler)
        {
            if (mLogHandler == null )
            {
                mLogHandler = new Dictionary<LogType, ILogHandler>(3);
            }

            if (mLogHandler.TryGetValue(inType, out ILogHandler handler))
            {
                return;
            }
            mLogHandler.Add(inType,inLogHandler);
        }
        
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lv"></param>
        /// <param name="content"></param>
        /// <param name="param"></param>
        public static void Info(byte lv,string content ,params object[] param)
        {
            
            if (mLogHandler == null || !mEnableLog)
                return;
            foreach (var handler in mLogHandler.Values)
            {
                handler.Log(content,param);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lv"></param>
        /// <param name="content"></param>
        /// <param name="param"></param>
        public static void Error(byte lv, string content, params object[] param)
        {
            if (mLogHandler == null || !mEnableLog)
                return;
            foreach (var handler in mLogHandler.Values)
            {
                handler.Error(content,param);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        public static void Trace(string content)
        {
            if (mLogHandler == null || !mEnableLog)
                return;
            foreach (var handler in mLogHandler.Values)
            {
                handler.LogTrace(content);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static int mOpenSwitch = 0;
        
  
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enable"></param>
        /// <param name="initvalue"></param>
        /// <param name="logHandlers"></param>
        public static void init(bool enable, byte initvalue, Dictionary<LogType,ILogHandler> logHandlers = null)
        {

            mEnableLog = enable;
            mOpenSwitch = initvalue;
            mLogHandler = logHandlers;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="invalue"></param>
        public static void open(byte invalue)
        {
            mOpenSwitch = mOpenSwitch ^ (1 << invalue);
        }
        
        
        
    }
}