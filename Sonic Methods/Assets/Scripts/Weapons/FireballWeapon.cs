using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballWeapon : MonoBehaviour, IUseableWeapon
{
    public GameObject fireball;
    private bool _isEquip = false;


    public void Shoot()
    {
        if(fireball != null && _isEquip)
        {
            GameObject curFireball = Instantiate(fireball,transform.position,new Quaternion());
            ProjectileFireball scFireball = curFireball.GetComponent<ProjectileFireball>();
            if (scFireball != null)
            {
                float direction = 1;
                if (transform.parent != null)
                    direction = transform.parent.localScale.x;
                scFireball.Shoot(direction);
            }
        }
    }

    public void UnEquip()
    {
        _isEquip = false;
    }
    public void Equip()
    {
        _isEquip = true;
    }
}