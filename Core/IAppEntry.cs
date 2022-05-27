using System.Collections;

namespace Core
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAppEntry 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        void OnInit();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        void OnStart();

        /// <summary>
        /// 
        /// </summary>
        void CheckUpdate();
    }
}