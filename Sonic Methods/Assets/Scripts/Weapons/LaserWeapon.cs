using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LaserWeapon : MonoBehaviour, IUseableWeapon
{
    public GameObject laser;
    private bool _isEquip = false;
    [Inject] private LaserPoolManager _laserPoolManager;

public void Shoot()
{
    if (laser != null && _isEquip)
    {
        GameObject curLaser = _laserPoolManager.GetPooledLaser();

        // Spawn laser slightly above the player
        Vector3 spawnOffset = new Vector3(0f, 3f, 0f); // 1 unit above
        curLaser.transform.position = transform.position + spawnOffset;
        curLaser.SetActive(true);

        // Prevent immediate collision with player
        Collider2D laserCol = curLaser.GetComponent<Collider2D>();
        Collider2D playerCol = GetComponent<Collider2D>();

        if (laserCol != null && playerCol != null)
        {
            Physics2D.IgnoreCollision(laserCol, playerCol);
            Debug.Log("Ignoring collision between laser and player.");
        }

        // Fire upward
        ProjectileLaser scLaser = curLaser.GetComponent<ProjectileLaser>();
        if (scLaser != null)
        {
            scLaser.Fire(Vector2.up);
        }

        Debug.Log("Laser shot above player!");
    }
    else if (!_isEquip)
    {
        Debug.Log("Laser not equipped, can't shoot.");
    }
}



    public void Equip()
    {
        _isEquip = true;
        Debug.Log("Laser equipped.");
    }

    public void UnEquip()
    {
        _isEquip = false;
        Debug.Log("Laser unequipped.");
    }
}
