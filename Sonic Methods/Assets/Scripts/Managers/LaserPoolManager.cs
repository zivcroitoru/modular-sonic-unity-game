using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LaserPoolManager : MonoBehaviour
{
    private List<GameObject> _pooledLasers; // Holds all lasers in the pool (both active and inactive)

    public GameObject laserPrefab;          // Prefab to use when creating new lasers
    public Transform projectileHolder;      // Optional parent object for organizing pooled lasers in the hierarchy

    [SerializeField]
    private int _amountToPool = 10;         // How many lasers to pre-instantiate at start

    private LaserDirector _laserDirector;   // Responsible for constructing lasers using the builder pattern

    // Inject the LaserDirector via Zenject
    [Inject]
    public void Construct(LaserDirector laserDirector)
    {
        _laserDirector = laserDirector;
    }

    // Initialize the list
    private void Awake()
    {
        _pooledLasers = new List<GameObject>();
    }

    // Create the initial pool of lasers
    private void Start()
    {
        for (int i = 0; i < _amountToPool; i++)
            CreateLaser();
    }

    // Creates a single laser, adds it to the pool, disables it, and parents it (optional)
    private GameObject CreateLaser()
    {
        if (laserPrefab != null)
        {
            GameObject laser = _laserDirector.Construct(laserPrefab); // Builds the laser using the director
            laser.SetActive(false);                                   // Start inactive
            _pooledLasers.Add(laser);                                 // Add to pool

            if (projectileHolder != null)
                laser.transform.SetParent(projectileHolder.transform); // Keep the hierarchy clean

            return laser;
        }
        return null;
    }

    // Returns an inactive laser from the pool, or creates a new one if none are available
    public GameObject GetPooledLaser()
    {
        foreach (GameObject laser in _pooledLasers)
        {
            if (!laser.activeInHierarchy)
                return laser; // Found a free laser
        }

        // No available laser → create one on demand
        return CreateLaser();
    }

    // Returns a laser back to the pool (called when it hits something or expires)
    public void ReturnToPool(GameObject laser)
    {
        laser.SetActive(false); // Deactivate it

        if (projectileHolder != null)
            laser.transform.SetParent(projectileHolder.transform); // Re-parent for organization
    }
}
