using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

namespace InjectIt
{
    public static class Factory
    {
        public static void Inject<T>(ref T obj)
        {
            var type = obj.GetType();
            Debug.Log("type is " + type);

            var inject = typeof(InjectItAttribute);

            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            Debug.Log("field count " + fields.Length);

            foreach (var field in fields)
            {
                if (Attribute.IsDefined(field, inject))
                {
                    Debug.Log("field type " + field);
                    var dependency = Activator.CreateInstance(DIContainer.dicBinder[field.FieldType.ToString()]);
                    field.SetValue(obj, dependency);
                }
            }
        }

        public static void ExecuteMethod(string methodName)
        {
            if (DIContainer.dicMethodInjected.ContainsKey(methodName))
            {
                var obj = DIContainer.dicMethodObj[methodName];
                var dependency = DIContainer.dicMethodParam[methodName];
                DIContainer.dicMethodInjected[methodName].Invoke(obj, dependency.ToArray());
            }
        }
    }
}
