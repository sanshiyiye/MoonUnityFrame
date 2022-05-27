namespace Core.Utils
{
    /// <summary>
    ///
    /// </summary>
    public abstract class BaseApplication
    {
        /// <summary>
        /// 数据存放路径
        /// </summary>
        private string mDataPath;

        /// <summary>
        /// 
        /// </summary>
        public string DataPath {
            get
            {
                return mDataPath;
            }
            set
            {
                mDataPath = value;
            } 
        }

        /// <summary>
        /// 平台类型(int)
        /// </summary>
        private int mPlatform;

        /// <summary>
        /// 
        /// </summary>
        public int Platform
        {
            get
            {
                return mPlatform;
            }

            set
            {
                mPlatform = value;
            }
        }

        /// <summary>
        /// 包资源路径
        /// </summary>
        private string mStreamingAssetsPath;

        /// <summary>
        /// 
        /// </summary>
        public string StreamingAssetsPath
        {
            get
            {
                return mStreamingAssetsPath;
            }
            set
            {
                mStreamingAssetsPath = value;
            }
        }
        /// <summary>
        /// 持久化路径
        /// </summary>
        private string mPersistentDataPath;

        /// <summary>
        /// 
        /// </summary>
        public string PersistentDataPath
        {
            get
            {
                return mPersistentDataPath;
            }
            set
            {
                mPersistentDataPath = value;
            }
        }
        /// <summary>
        /// 临时cache版本
        /// </summary>
        private string mTemporaryCachePath;

        /// <summary>
        /// 
        /// </summary>
        public string TemporaryCachePath
        {
            get
            {
                return mTemporaryCachePath;
            }

            set
            {
                mTemporaryCachePath = value;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        private string mUnityVersion;

        /// <summary>
        /// 
        /// </summary>
        public string UnityVersion
        {
            get
            {
                return mUnityVersion;
            }

            set
            {
                mUnityVersion = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string mDeviceModel;

        /// <summary>
        /// 
        /// </summary>
        public string DeviceModel
        {
            get
            {
                return mDeviceModel;
            }
            set
            {
                mDeviceModel = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private string mDeviceUniqueIdentifier;

        /// <summary>
        /// 
        /// </summary>
        public string DeviceUniqueIdentifier
        {
            get
            {
                return mDeviceUniqueIdentifier;
            }
            set
            {
                mDeviceUniqueIdentifier = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private string mGraphicsDeviceVersion;

        /// <summary>
        /// 
        /// </summary>
        public string GraphicsDeviceVersion
        {
            get
            {
                return mGraphicsDeviceVersion;
            }
            set
            {
                mGraphicsDeviceVersion = value;
            }
        }
    }
}