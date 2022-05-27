using System;

namespace Core.Log
{

    /// <summary>
    /// 
    /// </summary>
    public enum LogHandlerType : byte
    {
       
        /// <summary>
        /// 
        /// </summary>
        SYS, 
        
    }
    /// <summary>
    /// 日志回调接口
    /// </summary>
    public interface ILogHandler
    {
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="messages"></param>
        void Log( string format, object[] messages);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="messages"></param>
        void Warn( string format, object[] messages);

        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="format"></param>
        /// <param name="messages"></param>
        void Error( string format, object[] messages);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="exception"></param>
        void LogLogException( string format, Exception exception);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="trace"></param>
        void LogTrace(string format, string trace= null);
    }
}