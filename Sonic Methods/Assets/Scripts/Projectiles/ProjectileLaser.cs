using System.Collections;
using UnityEngine;

public class ProjectileLaser : BaseProjectile
{
    public override void Shoot()
    {
        StartCoroutine(ManualMove());
        StartDeactivateTimer();
    }

    private IEnumerator ManualMove()
    {
        while (true)
        {
            transform.position += Vector3.up * _speed * Time.deltaTime;
            yield return null;
        }
    }
}
