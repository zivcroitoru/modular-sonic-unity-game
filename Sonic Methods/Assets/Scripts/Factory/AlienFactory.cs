using UnityEngine;

public class AlienFactory : ShadowEnemyFactory
{
    public override ShadowEnemy CreateShadowEnemy()
    {
        GameObject alien = new GameObject("Alien " + Time.time);
        AlienEnemy logic = alien.AddComponent<AlienEnemy>();
        return logic;
    }
}
