using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoInstaller : Installer
{
    public override void InstallBinding()
    {
        DIContainer.Bind<TempInterface, TempClass>();
        DIContainer.Bind<AnotherInterface, AnotherClass>();
    }
}
