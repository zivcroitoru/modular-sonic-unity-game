using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class ProjectileLaser : BaseProjectile
{
    private Rigidbody2D _rigid;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }
private void Start()
{
    Debug.Log("[Laser] Testing motion by adding force");
    _rigid.AddForce(Vector2.up * 400f, ForceMode2D.Impulse);
}
void Update()
{
    if (_rigid != null)
    {
        Debug.Log("[Laser Update] Position: " + transform.position + " | Velocity: " + _rigid.velocity);
    }
}

    public override void Initialize(float speed, float lifeTime)
    {
        base.Initialize(speed, lifeTime);
        Debug.Log($"[Laser Init] Speed={speed}, LifeTime={lifeTime}");
    }

    public override void Fire(Vector2 ignoredDirection)
    {
        if (_rigid == null)
        {
            Debug.LogError("[Laser] Missing Rigidbody2D!");
            return;
        }

        _rigid.velocity = Vector2.zero;

        // FORCE upward motion for test
        Vector2 force = Vector2.up * speed;
        _rigid.AddForce(force, ForceMode2D.Impulse);

        Debug.Log($"[Laser Fire] Forced upward with {force}");

        // No timer — only deactivate on hit
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log($"[Laser] Hit ENEMY: {collision.name}");
            DeactivateObject();
        }
        else
        {
            Debug.Log($"[Laser] Hit non-enemy: {collision.name} (tag: {collision.tag})");
            // Do nothing
        }
    }

    private void DeactivateObject()
    {
        if (_rigid != null)
            _rigid.velocity = Vector2.zero;

        gameObject.SetActive(false);
        Debug.Log("[Laser] Deactivated after hitting enemy");
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
