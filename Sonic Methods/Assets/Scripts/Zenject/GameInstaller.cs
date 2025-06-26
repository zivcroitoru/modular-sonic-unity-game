using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IFireballBuilder>().To<FireballBuilder>().AsSingle();
        Container.Bind<FireballDirector>().AsSingle();
        Container.Bind<FireballPoolManager>().FromComponentInHierarchy().AsSingle();
    }
}
