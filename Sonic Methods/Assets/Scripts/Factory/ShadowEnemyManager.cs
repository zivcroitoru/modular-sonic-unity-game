using UnityEngine;

public class ShadowEnemyManager : MonoBehaviour
{
    private SoldierFactory _soldierFactory;
    private AlienFactory _alienFactory;

    void Awake()
    {
        _soldierFactory = new SoldierFactory();
        _alienFactory = new AlienFactory();
    }

    private void Start()
    {
        ShadowEnemy enemy1 = SpawnEnemy(_soldierFactory);
        for (int i = 0; i < 10; i++)
            SpawnEnemy(_soldierFactory);

        enemy1.Attack();

        ShadowEnemy enemy2 = SpawnEnemy(_alienFactory);
        enemy2.Attack();
    }

    private ShadowEnemy SpawnEnemy(ShadowEnemyFactory factory)
    {
        return factory.CreateShadowEnemy();
    }
}
