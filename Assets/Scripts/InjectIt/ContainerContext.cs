using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using System.Linq;

public class ContainerContext : MonoBehaviour
{
    public Installer[] installList;

    public static ContainerContext s_Instance;

    private BindingFlags m_Flag;

    private void Awake()
    {

        m_Flag = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        foreach (var installer in installList)
        {
            installer.InstallBinding();
        }

        s_Instance = this;

        var tempAttribue = typeof(TempAttribute);
        var injectAttribute = typeof(InjectItAttribute);
        var notMonoAttribute = typeof(NotMonoAttribute);
        //
        var assembly = Assembly.GetExecutingAssembly();

        var types = assembly.GetTypes();

        //foreach(var type in types)
        //{
        //    if(Attribute.IsDefined(type, notMonoAttribute))
        //    {
        //        Debug.Log("Type not mono " + type.ToString());
        //        FieldInfo[] fields = type.GetFields(m_Flag);
        //        foreach (FieldInfo field in fields)
        //        {
        //            if (Attribute.IsDefined(field, injectAttribute))
        //            {
        //                var fieldType = field.FieldType;

        //                var firstConstructor = DIContainer.dicBinder[fieldType.ToString()].GetConstructors()[0];
        //                var instance = firstConstructor.Invoke(null);
        //                var dependency = Activator.CreateInstance(DIContainer.dicBinder[fieldType.ToString()]);
        //                Debug.Log("Dependency type " + dependency.GetType());
        //                field.SetValue(instance, dependency);
        //            }
        //        }
        //    }
        //}

        //
        GameObject[] allObject = FindObjectsOfType<GameObject>();

        foreach(var obj in allObject)
        {
            if (obj.GetComponent<MonoBinding>())
            {
                var comp = obj.GetComponent<MonoBinding>();

                FieldInfo[] fields = comp.GetType().GetFields(m_Flag);

                foreach (FieldInfo field in fields)
                {
                    if (Attribute.IsDefined(field, injectAttribute))
                    {
                        var fieldType = field.FieldType;
                        Debug.Log("field type is " + fieldType.ToString());
                        var dependency = Activator.CreateInstance(DIContainer.dicBinder[fieldType.ToString()]);

                        field.SetValue(comp, dependency);
                    }
                }
            }
        }

        

        
    }
}

public class DemoAttribute : Attribute
{

}
