using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LaserDirector
{
    private ILaserBuilder _builder;

    [Inject] // Injects the builder via Zenject
    public LaserDirector(ILaserBuilder builder)
    {
        _builder = builder;
    }

    public GameObject Construct(GameObject laserPrefab)
    {
        _builder.SetSpeed();
        _builder.SetLifeTime();
        return _builder.Build(laserPrefab);
    }
}
