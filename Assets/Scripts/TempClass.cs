using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InjectIt;

public class TempClass : TempInterface
{
    public void Print()
    {
        Debug.Log("Hello from temp class");
    }
}
