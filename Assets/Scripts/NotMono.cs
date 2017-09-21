using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[NotMono]
public class NotMono
{
    [InjectIt]
    AnotherInterface temp;

    public void TempMethod()
    {
        temp.Print();
    }
}
