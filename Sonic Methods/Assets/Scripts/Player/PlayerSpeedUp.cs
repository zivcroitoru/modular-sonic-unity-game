using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedUp : MonoBehaviour
{
    private bool _isSpeedUp = false;
    public bool IsSpeedUp { get => _isSpeedUp; }

    public float powerUpDuration = 5f;

    private SpriteRenderer _curSpriteRenderer;

    private void Awake()
    {
        _curSpriteRenderer = GetComponent<SpriteRenderer>();    
    }
    
    public void ActivateSpeedUp()
    {
        Debug.Log("ActivateSpeedUp");
        StartCoroutine(ActivateSpeedUpTimer());
    }

IEnumerator ActivateSpeedUpTimer()
{
    _isSpeedUp = true;
    _curSpriteRenderer.color = Color.blue;

    PlayerMovement movement = GetComponent<PlayerMovement>();
    if (movement != null)
    {
        movement.speed *= 1.5f;
    }

    yield return new WaitForSeconds(powerUpDuration);

    if (movement != null)
    {
        movement.speed /= 1.5f;
    }

    _curSpriteRenderer.color = Color.white;
    _isSpeedUp = false;
}
}
