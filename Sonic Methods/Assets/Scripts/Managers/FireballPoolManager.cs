using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FireballPoolManager : MonoBehaviour
{
    private List<GameObject> _pooledFireBalls;
    public GameObject fireballPrefab;
    public Transform projectileHolder;

    [SerializeField]
    private int _amountToPool = 5;

    private FireballDirector _fireballDirector;


    [Inject]
    public void Construct(FireballDirector fireballDirector)
    {
        _fireballDirector = fireballDirector;
    }

    private void Awake()
    {
        _pooledFireBalls = new List<GameObject>();
    }

    private void Start()
    {
        for (int i = 0; i < _amountToPool; i++)
            CreateFireball();
    }

    private GameObject CreateFireball()
    {
        if (fireballPrefab != null)
        {
            GameObject fireball = _fireballDirector.Construct(fireballPrefab);
            fireball.SetActive(false);
            _pooledFireBalls.Add(fireball);
            if (projectileHolder != null)
                fireball.transform.SetParent(projectileHolder.transform);
            return fireball;
        }
        return null;
    }

    public GameObject GetPooledFireball()
    {
        foreach (GameObject fireball in _pooledFireBalls)
        {
            if(!fireball.activeInHierarchy)
                return fireball;
        }
        return CreateFireball();
    }
}
