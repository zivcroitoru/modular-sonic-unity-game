using UnityEngine;

public class SoldierFactory : ShadowEnemyFactory
{
    public override ShadowEnemy CreateShadowEnemy()
    {
        GameObject soldier = new GameObject("Soldier " + Time.time);
        SoldierEnemy logic = soldier.AddComponent<SoldierEnemy>();
        return logic;
    }
}
