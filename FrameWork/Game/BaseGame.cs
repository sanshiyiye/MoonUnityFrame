
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Core
{
    
    /// <summary>
    /// 
    /// </summary>
    public abstract partial class BaseGame : MonoBehaviour,IAppEntry{


        /// <summary>
        ///  启动类单例
        /// </summary>
        public static BaseGame Instance { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public void Awake()
        {
           GameObject.DontDestroyOnLoad(this.gameObject);
           Instance = this;
           AppEngine.Build(gameObject, this, CreateModules());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual  object CreateModules()
        {
            return new List<IModule>
            {

            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int getCount(string name){

            int a = 10;
            
            return a;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerator OnInit();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract  IEnumerator OnStart();
    }
}