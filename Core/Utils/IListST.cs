namespace Core.Utils
{
    /// <summary>
    /// List扩展结构
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IListST <T> where T : class 
    {
        /// <summary>
        /// 获取长度
        /// </summary>
        /// <returns></returns>
        int GetLength();
        /// <summary>
        /// 清空List数据
        /// </summary>
        void Clear();
        /// <summary>
        /// 是否为空
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();
        /// <summary>
        /// 添加元素到List
        /// </summary>
        /// <param name="item"></param>
        void Append(T item);
        /// <summary>
        /// 在某个位置插入
        /// </summary>
        /// <param name="item"></param>
        /// <param name="i"></param>
        void Insert(T item, int i);
        /// <summary>
        /// 删除某个位置的元素
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        T Delete(int i);
        /// <summary>
        /// 获取某个位置的元素
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        T GetElem(int i);
        /// <summary>
        /// 获取某个元素的位置
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        int Locate(T value);
    }
}