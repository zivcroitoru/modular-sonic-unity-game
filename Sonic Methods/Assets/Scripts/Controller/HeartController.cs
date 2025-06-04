using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    [SerializeField] private HeartView heartView;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private IHeartModel _heartModel;
    private IHeartView _heartView;
    private Coroutine spikeRoutine;
    private ResetPosition resetPosition;

    private void OnEnable()
    {
        SC_Death.OnSpikeCollision += StartSpikeDamage;
        SC_Heart.OnHeartCollision += OnHeartCollision;
    }
    private void OnDisable()
    {
        SC_Death.OnSpikeCollision -= StartSpikeDamage;
        SC_Heart.OnHeartCollision -= OnHeartCollision;
    }

    private void Awake()
    {
        resetPosition = GetComponent<ResetPosition>();
        _heartModel = new HeartModel();
        _heartView = heartView;
        UpdateView();
    }

    private void OnHeartCollision()
    {
        _heartModel.AddHeart();
        UpdateView();
    }

    private void UpdateView()
    {
        if(_heartView != null && _heartModel != null)
            _heartView.UpdateHeartAmount(_heartModel.GetHeartAmount());
    }
    private void StartSpikeDamage()
{
    if (spikeRoutine == null)
        spikeRoutine = StartCoroutine(SpikeDamageRoutine());
}
private IEnumerator BlinkRed()
{
    Color originalColor = spriteRenderer.color;
    spriteRenderer.color = Color.red;
    yield return new WaitForSeconds(0.1f);
    spriteRenderer.color = originalColor;
}

    private IEnumerator SpikeDamageRoutine()
    {
        while (!_heartModel.IsDead())
    {
        _heartModel.RemoveHeart();
        UpdateView();
        
        if (spriteRenderer != null)
            StartCoroutine(BlinkRed());

        yield return new WaitForSeconds(1f);
    }

   // Reset when out of hearts
    if (resetPosition != null)
        resetPosition.ResetPlayerPosition();
    _heartModel.AddHeart(); // Optional: reset to 1
    UpdateView();
    spikeRoutine = null;
    }
}
