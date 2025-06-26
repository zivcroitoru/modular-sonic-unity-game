using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBuilder : ILaserBuilder
{
    private float speed;
    private float lifeTime;

    public void SetLifeTime()
    {
        this.lifeTime = 2f;
    }

    public void SetSpeed()
    {
        this.speed = 400f;
    }

    public GameObject Build(GameObject laserPrefab)
    {
        GameObject newLaser = Object.Instantiate(laserPrefab);

        // Get BaseProjectile component instead of non-existent ProjectileLaser
        BaseProjectile projectile = newLaser.GetComponent<BaseProjectile>();

        if (projectile != null)
        {
            projectile.Initialize(speed, lifeTime); // You must implement this method in BaseProjectile
        }
        else
        {
            Debug.LogWarning("BaseProjectile component missing on laser prefab!");
        }

        return newLaser;
    }
}
