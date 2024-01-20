/*
* @classdesc EventTicket
* @author Copyright (c) 2017-2020, w.l.hikaru (xiaoguang.wang@rjoy.com)
* @date
* @description
*/

using System;

namespace Core
{
    public interface IEventTicket : IDisposable
    {
        void UnRegister();
    }
    public class EventTicket : IEventTicket
    {
        public Action<object> Handler;

        public string Name;
        
        public string Group;
        
        public void Dispose()
        {
            this.UnRegister();
        }

        public void UnRegister()
        {
            XEvent.Remove(Handler, Name, Group);
        }
    }
}