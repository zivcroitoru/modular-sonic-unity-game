using UnityEngine;

public class LaserController : PickUp
{
    protected override void OnPickUp(GameObject player)
    {
        player.GetComponent<PlayerPowerUp>().CollectPowerUp(new LaserPowerUp());
    }
}
