using System;
using System.Collections;

namespace Core
{
    /// <summary>
    /// 
    /// </summary>
    public class AppEngine
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inRoot"></param>
        /// <param name="inEtry"></param>
        /// <param name="createModules"></param>
        public static void Build(object inRoot, IAppEntry inEtry, object createModules)
        {
            // Init
            // OnInit
            // OnPrelad
            // start
            // Onstart
            ConfigMgr.getInstance().Init();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator Init()
        {
            yield return null;
            
        }
    }
}