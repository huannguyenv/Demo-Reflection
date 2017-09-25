using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using System.Linq;

namespace InjectIt
{
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

            var injectAttribute = typeof(InjectItAttribute);
            var notMonoAttribute = typeof(NotMonoAttribute);
            //
            var assembly = Assembly.GetExecutingAssembly();

            var types = assembly.GetTypes();

            //
            GameObject[] allObject = FindObjectsOfType<GameObject>();

            foreach (var obj in allObject)
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

                    MethodInfo[] methods = comp.GetType().GetMethods(m_Flag);
                    if (methods.Length > 0)
                    {
                        foreach (MethodInfo method in methods)
                        {
                            if (Attribute.IsDefined(method, injectAttribute))
                            {
                                if (!method.GetParameters().Any())
                                {
                                    Debug.LogWarningFormat("Method {0} not contain any dependency", method);
                                }
                                else
                                {
                                    var parameters = method.GetParameters();
                                    var paramDependency = new List<object>();

                                    foreach (var param in parameters)
                                    {
                                        var dependency = Activator.CreateInstance(DIContainer.dicBinder[param.ParameterType.ToString()]);
                                        paramDependency.Add(dependency);
                                    }
                                    DIContainer.dicMethodInjected.Add(method.Name, method);
                                    DIContainer.dicMethodObj.Add(method.Name, comp);
                                    DIContainer.dicMethodParam.Add(method.Name, paramDependency);
                                }
                            }
                        }
                    }

                }
            }




        }
    }
}

