using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InjectIt;

public class Sample : MonoBinding
{
    [InjectIt]
    TempInterface sample;
    // Use this for initialization
    void Start()
    {
        //var not = new NotMono();
        //Factory.Inject<NotMono>(ref not);
        //not.TempMethod();

        //sample.Print();
        //Factory.ExecuteMethod("Test");
        //Test(sample);
    }

    // Update is called once per frame
    void Update()
    {

    }

    [InjectIt]
    public void Test(TempInterface temp)
    {
        temp.Print();
    }
}
