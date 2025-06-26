using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        // fireball
        Container.Bind<IFireballBuilder>().To<FireballBuilder>().AsSingle();
        Container.Bind<FireballDirector>().AsSingle();
        Container.Bind<FireballPoolManager>().FromComponentInHierarchy().AsSingle();

        // laser
        Container.Bind<ILaserBuilder>().To<LaserBuilder>().AsSingle();
        Container.Bind<LaserDirector>().AsSingle();
        Container.Bind<LaserPoolManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<LaserFactory>().AsSingle();
    }
}
