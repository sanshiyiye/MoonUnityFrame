using System;
using System.Diagnostics;

// using System.Reflection.PortableExecutable;
namespace Core
{
    
    /// <summary>
    /// 
    /// </summary>
    public class ConfigMgr : Singleton<ConfigMgr>
    {

        /// <summary>
        /// 初始化接口
        /// </summary>
        public void Init()
        {
            Console.WriteLine("1111111122222");
        }

        /// <summary>
        /// 重新加载
        /// </summary>
        public void Reload()
        {


        }
        /// <summary>
        /// 清楚配置
        /// </summary>
        public void Clear()
        {

        }
        /// <summary>
        /// 按照名称获取配置文件
        /// </summary>
        /// <param name="name">配置名称</param>
        /// <returns></returns>
        public IConfig getConfigByName(String name)
        {
            
            return null;
        }
          
    }
}