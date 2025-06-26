using UnityEngine;

public class LaserPowerUp : IPowerUp
{
    public void ApplyPowerUp(GameObject player)
    {
        Debug.Log("ApplyPowerUp Laser");
        if (player != null)
        {
            LaserWeapon laserWeapon = player.GetComponentInChildren<LaserWeapon>();
            if (laserWeapon != null)
                laserWeapon.Equip();
        }
    }
}
