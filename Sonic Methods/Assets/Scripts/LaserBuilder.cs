using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Builder class for creating Laser projectiles with specific settings
public class LaserBuilder : ILaserBuilder
{
    private float speed;      // How fast the laser moves
    private float lifeTime;   // How long the laser exists

    // Set the lifetime to 2 seconds (could be parameterized)
    public void SetLifeTime()
    {
        this.lifeTime = 2;
    }

    // Set the speed to 400 units (could be parameterized)
    public void SetSpeed()
    {
        this.speed = 400;
    }

    // Creates (instantiates) a new laser GameObject from a prefab
    public GameObject Build(GameObject laserPrefab)
    {
        // Create a new laser object from the given prefab
        GameObject newLaser = Object.Instantiate(laserPrefab);

        // Get the ProjectileLaser script attached to the new laser object
        ProjectileLaser laserComponent = newLaser.GetComponent<ProjectileLaser>();

        // Initialize the laser with speed and lifetime
        laserComponent.Initialize(speed, lifeTime);

        // Return the finished laser GameObject
        return newLaser;
    }
}
