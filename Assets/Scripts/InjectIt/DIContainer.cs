using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

namespace InjectIt
{
    public static class DIContainer
    {
        public static Dictionary<string, Type> dicBinder = new Dictionary<string, Type>();

        public static Dictionary<string, MethodInfo> dicMethodInjected = new Dictionary<string, MethodInfo>();
        public static Dictionary<string, List<object>> dicMethodParam = new Dictionary<string, List<object>>();
        public static Dictionary<string, object> dicMethodObj = new Dictionary<string, object>();


        public static void Bind<T, U>()
        {
            if (dicBinder.ContainsKey(typeof(T).ToString()))
            {
                Debug.LogWarning("key exist, cannot binding new value");
                return;
            }
            else
            {
                if (typeof(T).IsAssignableFrom(typeof(U)))
                {
                    dicBinder.Add(typeof(T).ToString(), typeof(U));
                }
                else
                {
                    Debug.LogErrorFormat("value {0} is not assignable from {1}", typeof(U), typeof(T).ToString());
                    return;
                }
            }
        }

        public static void ReBind<T, U>()
        {
            if (dicBinder.ContainsKey(typeof(T).ToString()))
            {
                dicBinder[typeof(T).ToString()] = typeof(U);
                Debug.Log(String.Format("Rebind {0} with {1}", typeof(T).ToString(), typeof(U)));
            }
            else
            {
                Debug.LogWarning(String.Format("Can not find key {0}, add new pair key {0} and value {1}"
                    , typeof(T).ToString(), typeof(U)));
                dicBinder.Add(typeof(T).ToString(), typeof(U));
            }
        }


    }
}
