using UnityEngine;
using Zenject;
using System.Collections.Generic;

public class LaserPoolManager : MonoBehaviour
{
    private List<GameObject> _pooledLasers;
    public GameObject laserPrefab;
    public Transform projectileHolder;
    [SerializeField] private int _amountToPool = 5;

    private LaserDirector _laserDirector;

    [Inject]
    public void Construct(LaserDirector laserDirector)
    {
        _laserDirector = laserDirector;
    }

    private void Awake()
    {
        _pooledLasers = new List<GameObject>();
    }

    private void Start()
    {
        for (int i = 0; i < _amountToPool; i++)
            CreateLaser();
    }

    private GameObject CreateLaser()
    {
        if (laserPrefab != null)
        {
            GameObject laser = _laserDirector.Construct(laserPrefab);
            laser.SetActive(false);
            _pooledLasers.Add(laser);
            if (projectileHolder != null)
                laser.transform.SetParent(projectileHolder.transform);
            return laser;
        }
        return null;
    }

    public GameObject GetPooledLaser()
    {
        foreach (GameObject laser in _pooledLasers)
        {
            if (!laser.activeInHierarchy)
                return laser;
        }
        return CreateLaser();
    }
}
