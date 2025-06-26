using UnityEngine;
using Zenject; 

public class LaserFactory
{
    private readonly ILaserBuilder builder;

    // Zenject will inject the correct builder automatically
    [Inject]
    public LaserFactory(ILaserBuilder builder)
    {
        this.builder = builder;
    }

    public GameObject CreateLaser(GameObject laserPrefab)
    {
        builder.SetSpeed();
        builder.SetLifeTime();
        return builder.Build(laserPrefab);
    }
}
