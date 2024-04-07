/*
* @classdesc Singleton
* @author Copyright (c) 2017-2020, w.l.hikaru (xiaoguang.wang@rjoy.com)
* @date
* @description
*/

namespace Core
{
    /// <summary>
    /// 
    /// </summary>
    public class Singleton<T> where T : new()
    {

        private static T m_Instance;


        private static object m_Lock = new object();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static T GetInstance()
        {
            
            lock (m_Lock)
            {
                if (m_Instance == null)
                {
                    m_Instance = new T();
                }
                return m_Instance;
            }
            
        }
        
    }
}