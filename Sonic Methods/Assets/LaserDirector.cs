using UnityEngine;

public class LaserDirector
{
    private ILaserBuilder _builder;

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
