using UnityEngine;

public class LaserBuilder : ILaserBuilder
{
    private float speed;
    private float lifeTime;

    public void SetSpeed()
    {
        this.speed = 20; // Customize for laser
    }

    public void SetLifeTime()
    {
        this.lifeTime = 1.5f; // Customize for laser
    }

    public GameObject Build(GameObject laserPrefab)
    {
        GameObject newLaser = Object.Instantiate(laserPrefab);
        ProjectileLaser laserComponent = newLaser.GetComponent<ProjectileLaser>();
        laserComponent.Initialized(speed, lifeTime);
        return newLaser;
    }
}
