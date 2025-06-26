using UnityEngine;
using System.Collections;

public abstract class BaseProjectile : MonoBehaviour
{
    public float speed = 500f;
    public float lifeTime = 2f;

    public virtual void Initialize(float speed, float lifeTime)
    {
        this.speed = speed;
        this.lifeTime = lifeTime;
        Debug.Log($"[BaseProjectile] Initialized with speed={speed}, lifeTime={lifeTime}");
    }

    public virtual void Fire(Vector2 direction)
    {
        Debug.Log($"[BaseProjectile] Fire called with direction={direction}");
        StartCoroutine(Move(direction));
    }

    protected virtual IEnumerator Move(Vector2 direction)
    {
        float timer = 0f;
        Vector3 velocityPerFrame = direction.normalized * speed * Time.deltaTime;
        Debug.Log($"[BaseProjectile] Starting movement loop. Velocity per frame: {velocityPerFrame}");

        while (timer < lifeTime)
        {
            transform.Translate(velocityPerFrame);
            timer += Time.deltaTime;
            yield return null;
        }

        Debug.Log($"[BaseProjectile] Movement complete after {timer} seconds");
        OnExpire();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"[BaseProjectile] OnTriggerEnter2D: Hit {collision.name} (tag: {collision.tag})");
        OnExpire();
    }

    protected virtual void OnExpire()
    {
        Debug.Log("[BaseProjectile] Expired or hit something — disabling object");
        gameObject.SetActive(false);
    }
}
