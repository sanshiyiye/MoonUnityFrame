namespace Core.Event
{
    /// <summary>
    /// 
    /// </summary>
    public delegate void CallBack();
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public delegate void CallBack<T>(T t);
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="T1"></typeparam>
    public delegate void CallBack<T, T1>(T t, T1 t1);
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public delegate void CallBack<T, T1, T2>(T t, T1 t1, T2 t2);
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    public delegate void CallBack<T, T1, T2, T3>(T t, T1 t1, T2 t2, T3 t3);
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="R"></typeparam>
    public delegate R CallBackR<R>();
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="R"></typeparam>
    /// <typeparam name="T"></typeparam>
    public delegate R CallBackR<R, T>(T t);
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="R"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="T1"></typeparam>
    public delegate R CallBackR<R, T, T1>(T t, T1 t1);
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="R"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public delegate R CallBackR<R, T, T1, T2>(T t, T1 t1, T2 t2);
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="R"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    public delegate R CallBackR<R, T, T1, T2, T3>(T t, T1 t1, T2 t2, T3 t3);
}