using UnityEngine;

public class LaserFactory
{
    private GameObject _laserPrefab;

    public LaserFactory(GameObject laserPrefab)
    {
        _laserPrefab = laserPrefab;
    }

    public ProjectileLaser CreateLaser()
    {
        GameObject laser = Object.Instantiate(_laserPrefab);
        ProjectileLaser logic = laser.GetComponent<ProjectileLaser>();
        logic.Initialized(0.5f, 3f); // You can expose this too
        return logic;
    }
}
