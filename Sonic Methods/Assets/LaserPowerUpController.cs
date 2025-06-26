using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPowerUpController : PickUp
{
    protected override void OnPickUp(GameObject player)
    {
        player.GetComponent<PlayerPowerUp>().CollectPowerUp(new LaserPowerUp());
    }
}
