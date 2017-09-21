using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public static class Factory
{
    public static void Inject<T>(ref T obj)
    {
        var type = obj.GetType();
        Debug.Log("type is " + type);

        var inject = typeof(InjectItAttribute);

        FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        Debug.Log("field count " + fields.Length);

        foreach(var field in fields)
        {
            if (Attribute.IsDefined(field, inject))
            {
                Debug.Log("field type " + field);
                var dependency = Activator.CreateInstance(DIContainer.dicBinder[field.FieldType.ToString()]);
                field.SetValue(obj, dependency);
            }
        }
    }
}
