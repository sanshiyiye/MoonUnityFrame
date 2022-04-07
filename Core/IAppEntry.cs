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
        IEnumerator OnInit();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator OnStart();
    }
}