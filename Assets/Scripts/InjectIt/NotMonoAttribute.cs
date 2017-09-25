using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace InjectIt
{
    [AttributeUsage(AttributeTargets.Class)]
    public class NotMonoAttribute : Attribute
    {
    }
}
