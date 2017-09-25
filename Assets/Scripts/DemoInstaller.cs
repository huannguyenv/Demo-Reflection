using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InjectIt;

public class DemoInstaller : Installer
{
    public override void InstallBinding()
    {
        DIContainer.Bind<TempInterface, NewClass>();
        DIContainer.Bind<AnotherInterface, AnotherClass>();
    }
}
