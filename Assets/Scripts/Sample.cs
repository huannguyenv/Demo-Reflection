using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    TempInterface sample;
    // Use this for initialization
    void Start()
    {
        ContainerContext.s_Instance.ToObject(sample);
        sample = ContainerContext.s_Instance.GetDi();
        sample.Print();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
