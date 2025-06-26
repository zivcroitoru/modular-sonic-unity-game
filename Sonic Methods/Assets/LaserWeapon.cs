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
            curLaser.transform.position = transform.position;
            curLaser.SetActive(true);

            ProjectileLaser scLaser = curLaser.GetComponent<ProjectileLaser>();
            if (scLaser != null)
            {
                scLaser.Shoot(); // no direction needed
            }
        }
    }

    public void Equip() => _isEquip = true;
    public void UnEquip() => _isEquip = false;
}
