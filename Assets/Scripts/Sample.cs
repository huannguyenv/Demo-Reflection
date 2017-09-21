using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBinding
{
    [InjectIt]
    TempInterface sample;
    // Use this for initialization
    void Start()
    {
        var not = new NotMono();
        Factory.Inject<NotMono>(ref not);
        not.TempMethod();
        sample.Print();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
