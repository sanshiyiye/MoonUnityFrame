/*
* @classdesc MEvent
* @author Copyright (c) 2017-2020, w.l.hikaru (xiaoguang.wang@rjoy.com)
* @date
* @description
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    struct EventRecord
    {
        
        public string Name;
        public string Group;
    }
    
    /// <summary>
    /// Event
    /// </summary>
    public class XEvent : Singleton<XEvent>
    {
        public const string DefaultGroup = "Default";
        private Dictionary<Action<object>, List<EventRecord>> mDict_Infos =
            new Dictionary<Action<object>, List<EventRecord>>();
        
        private Dictionary<string,Dictionary<string,List<Action<object>>>> mDict_Handlers =
            new Dictionary<string, Dictionary<string, List<Action<object>>>>();
        
        public static IEventTicket Register(string name, Action<object> handler,string eventGroup = DefaultGroup)
        {
            return GetInstance().RegisterEvent(name,handler,eventGroup);
        }

        private IEventTicket RegisterEvent(string name, Action<object> handler, string eventGroup)
        {
            if(mDict_Infos.ContainsKey(handler))
            {
                if (mDict_Infos[handler].Any(r => r.Name == name && r.Group.Equals(eventGroup)))
                    return new EventTicket()
                    {
                        Handler = handler,
                        Name = name,
                        Group = eventGroup
                    };
            }
            
                
            if (!mDict_Handlers.ContainsKey(eventGroup))
            {
                mDict_Handlers.Add(eventGroup,new Dictionary<string, List<Action<object>>>());
            }
            if (!mDict_Handlers[eventGroup].ContainsKey(name))
            {
                mDict_Handlers[eventGroup].Add(name,new List<Action<object>>());
            }

            if (!mDict_Handlers[eventGroup][name].Contains(handler))
            {
                mDict_Handlers[eventGroup][name].Add(handler);
            }
            if (!mDict_Infos.ContainsKey(handler))
            {
                mDict_Infos.Add(handler,new List<EventRecord>());
            }
            mDict_Infos[handler].Add(new EventRecord()
            {
                Name = name,
                Group = eventGroup
            });
            return new EventTicket
            {
                Name = name, 
                Handler =  handler,
                Group = eventGroup
            };
        }

        public static void Remove(Action<object> handler)
        {
            GetInstance().RemoveEvent(handler);
        }

        public static void Call(string eventName, object param = null, string eventGroup = DefaultGroup)
        {
            GetInstance().CallEvent(eventName,param,eventGroup);
        }

        public static void Remove(Action<object> handler, string name, string @group)
        {
            GetInstance().RemoveEvent(handler,name,group);
        }

        private void RemoveEvent(Action<object> handler)
        {
            if (mDict_Infos.TryGetValue(handler, out var records))
            {
                foreach (var item in records)
                {
                    if (mDict_Handlers.TryGetValue(item.Group, out var h_n))
                    {
                        if (h_n.TryGetValue(item.Name, out var handers))
                        {
                            handers.Remove(handler);
                            if(handers.Count == 0)
                                h_n.Remove(item.Name);
                            
                        }

                        if (h_n.Count == 0)
                        {
                            mDict_Handlers.Remove(item.Group);
                        }
                    }
                }
                mDict_Infos.Remove(handler);
            }
        }
        
        private void RemoveEvent(Action<object> handler, string name, string @group)
        {
            if(mDict_Handlers.TryGetValue(group, out var h_n))
            {
                if (h_n.TryGetValue(name, out var handers))
                {
                    handers.Remove(handler);
                    if(handers.Count == 0)
                        h_n.Remove(name);
                }

                if (h_n.Count == 0)
                {
                    mDict_Handlers.Remove(group);
                }
            }
            if(mDict_Infos.TryGetValue(handler, out var records))
            {
                foreach (var item in records)
                {
                    if (item.Group == group && item.Name == name)
                    {
                        records.Remove(item);
                        break;
                    }
                    
                }
                if (records.Count == 0)
                {
                    mDict_Infos.Remove(handler);
                }
            }
        }

        private void CallEvent(string eventName, object param, string eventGroup)
        {
            
            if (mDict_Handlers.TryGetValue(eventGroup, out var h_n))
            {
                if (h_n.TryGetValue(eventName, out var handlers))
                {
                    // 先注册先触发
                    for (int i = handlers.Count -1; i >=0 ; i--)
                    {
                        handlers[i]?.Invoke(param);
                    }
                }
            }
        }
    }
}