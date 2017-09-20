using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using System.Linq;

public class ContainerContext : MonoBehaviour
{
    public static ContainerContext s_Instance;

    public Dictionary<Type, Type> dic = new Dictionary<Type, Type>();
    public List<Type> list = new List<Type>();
    public Dictionary<Type, object> dicObject = new Dictionary<Type, object>();

    private void Awake()
    {

        s_Instance = this;

        var tempAttribue = typeof(TempAttribute);
        var assembly = Assembly.GetExecutingAssembly();

        var types = assembly.GetTypes();


        foreach(var type in types)
        {
            if (Attribute.IsDefined(type, tempAttribue))
            {
                //Debug.Log("type is " + type);
                list.Add(type);
                dic.Add(type, typeof(TempClass));
               // dic.Add(type, TempClass );
            }
        }
    }

    public void SetDi(Type interfaceType)
    {
        dicObject.Add(interfaceType, Activator.CreateInstance(dic[interfaceType]));
    }

    public object GetDi(Type interfaceType)
    {
        return dicObject[interfaceType.GetType()] = interfaceType;
    }

    public object ToObject(Type type)
    {
        return type as object;
    }
}

public class DemoAttribute : Attribute
{

}
