using System;
using System.Reflection.PortableExecutable;
namespace Core
{
    
    public class ConfigMgr
    {
        int Count(){
            get;
        }

        /// <summary>
        /// 初始化接口
        /// </summary>
        public void init()
        {

        }

        /// <summary>
        /// 重新加载
        /// </summary>
        public void reload()
        {


        }
        /// <summary>
        /// 清楚配置
        /// </summary>
        public void clear()
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