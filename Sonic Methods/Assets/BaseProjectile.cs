using System.Collections;
using UnityEngine;

public abstract class BaseProjectile : MonoBehaviour
{
    [SerializeField]
    protected float _speed = 1f;

    [SerializeField]
    protected float _destroyTime = 5f;

    protected virtual void OnDisable()
    {
        StopAllCoroutines();
    }

    public virtual void Initialized(float speed, float lifeTime)
    {
        _speed = speed;
        _destroyTime = lifeTime;
    }

    public abstract void Shoot();

    protected void StartDeactivateTimer()
    {
        StartCoroutine(DeactivateLogic());
    }

    private IEnumerator DeactivateLogic()
    {
        yield return new WaitForSeconds(_destroyTime);
        StopAllCoroutines();
        gameObject.SetActive(false);
    }
}
