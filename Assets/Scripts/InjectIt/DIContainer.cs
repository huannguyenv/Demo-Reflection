using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class DIContainer
{
    public static Dictionary<string, Type> dicBinder = new Dictionary<string, Type>();


    public static void Bind<T, U>()
    {
        if (dicBinder.ContainsKey(typeof(T).ToString()))
        {
            Debug.Log("key exist, cannot binding new value");
            return;
        }
        else
        {
            dicBinder.Add(typeof(T).ToString(), typeof(U));
        }
    }
}
