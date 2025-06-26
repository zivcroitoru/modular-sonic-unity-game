using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILaserBuilder 
{
    void SetSpeed();
    void SetLifeTime();

    GameObject Build(GameObject laserPrefab);
}
