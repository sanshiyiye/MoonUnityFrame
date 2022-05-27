using System;
using System.Collections.Generic;
using Core.Log;
using Core.Utils;

namespace Core
{
    /// <summary>
    /// 
    /// </summary>
    public class AppEngine
    {
        private static IAppEntry mEntry;

        private static List<IModule> mModules;

        /// <summary>
        ///  
        /// </summary>
        /// <param name="inRoot"></param>
        /// <param name="inEtry"></param>
        /// <param name="inModules"></param>
        public static void Build(object inRoot, IAppEntry inEtry, List<IModule> inModules)
        {
            
            mEntry = inEtry;
            mModules = inModules;
            // 初始化
            Init();
            mEntry.CheckUpdate();
            mEntry.OnStart();
        }


        /// <summary>
        /// 引擎逻辑初始化
        /// </summary>
        /// <returns></returns>
        public static void Init()
        {
            if (AppConfig.LOG_DEVIVE)
            {
                Logger.Info(LogLevel.SYS,
                    "====================================================================================");
                Logger.Info(LogLevel.SYS, "Application.platform = {0}", Game.appliction.Platform);
                Logger.Info(LogLevel.SYS, "Application.dataPath = {0} , WritePermission: {1}",
                    Game.appliction.DataPath, Tools.HasWriteAccessToFolder(Game.appliction.DataPath));
                Logger.Info(LogLevel.SYS, "Application.streamingAssetsPath = {0} , WritePermission: {1}",
                    Game.appliction.StreamingAssetsPath,
                    Tools.HasWriteAccessToFolder(Game.appliction.StreamingAssetsPath));
                Logger.Info(LogLevel.SYS, "Application.temporaryCachePath = {0} , WritePermission: {1}",
                    Game.appliction.TemporaryCachePath,
                    Tools.HasWriteAccessToFolder(Game.appliction.TemporaryCachePath));
                Logger.Info(LogLevel.SYS, "Application.unityVersion = {0}", Game.appliction.UnityVersion);
                Logger.Info(LogLevel.SYS, "SystemInfo.deviceModel = {0}", Game.appliction.DeviceModel);
                Logger.Info(LogLevel.SYS, "SystemInfo.deviceUniqueIdentifier = {0}",
                    Game.appliction.DeviceUniqueIdentifier);
                Logger.Info(LogLevel.SYS, "SystemInfo.graphicsDeviceVersion = {0}",
                    Game.appliction.GraphicsDeviceVersion);
                Logger.Info(LogLevel.SYS,
                    "====================================================================================");
            }

            OnInit();
        }

        private static  void OnInit()
        {
            InitModules(mModules);
            if (mEntry != null)
            {
                mEntry.OnInit();
            }

        }

        private static void InitModules(List<IModule> modules)
        {
            var startInitTime = 0f;
            var startMem = 0f;
            var length = modules.Count;
            if (AppConfig.LOG_DEVIVE)
            {
                startInitTime = DateTime.Now.Millisecond;
                startMem = GC.GetTotalMemory(false);
            }
           
            for (int i = 0; i < length; i++)
            {
                modules[i].Init();
               
            }

            if (AppConfig.LOG_DEVIVE)
            {
                var nowMem = GC.GetTotalMemory(false);
                Logger.Info(LogLevel.SYS, "System Memory: {0}, Use Time: {1}, Total Memory: {2}", nowMem - startMem,
                    DateTime.Now.Millisecond - startInitTime, nowMem);
            }
        }

 
    }
}