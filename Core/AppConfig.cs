/*
* @classdesc AppConfig
* @author Copyright (c) 2017-2020, w.l.hikaru (xiaoguang.wang@rjoy.com)
* @date
* @description
*/

namespace Core
{
    /// <summary>
    /// 系统配置
    /// </summary>
    public class AppConfig 
    {
        /// <summary>
        /// 
        /// </summary>
        public static bool LOG_DEVIVE = false;

        /// <summary>
        /// 
        /// </summary>
        public static bool IsEditorLoadAsset = true;

        /// <summary>
        /// 
        /// </summary>
        public static bool IsDebugBuild { get; set; }
        
    }
}