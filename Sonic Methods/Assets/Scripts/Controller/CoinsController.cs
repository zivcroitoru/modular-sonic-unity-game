using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsController : MonoBehaviour
{
    [SerializeField] private CoinsView coinsView;
    private ICoinsModel _coinsModel;
    private ICoinView _coinsView;

    private void OnEnable()
    {
        Debug.Log("CoinsController: Subscribed to OnCoinCollision");
        SC_Coin.OnCoinCollision += OnCoinCollision;
    }

    private void OnDisable()
    {
        Debug.Log("CoinsController: Unsubscribed from OnCoinCollision");
        SC_Coin.OnCoinCollision -= OnCoinCollision;
    }

    public void Awake()
    {
        Debug.Log("CoinsController: Awake()");
        _coinsModel = new CoinsModel();
        _coinsView = coinsView;

        if (_coinsView == null)
            Debug.LogWarning("CoinsController: coinsView is not assigned in Inspector");

        UpdateView();
    }

    private void OnCoinCollision()
    {
        Debug.Log("CoinsController: OnCoinCollision triggered");
        _coinsModel.AddCoin();
        UpdateView();
    }

    private void UpdateView()
    {
        Debug.Log("CoinsController: UpdateView()");
        if (_coinsView != null && _coinsModel != null)
        {
            int coinAmount = _coinsModel.GetCoinsAmount();
            Debug.Log("CoinsController: Updating view with amount = " + coinAmount);
            _coinsView.UpdateCoinsAmount(coinAmount);
        }
        else
        {
            Debug.LogWarning("CoinsController: _coinsView or _coinsModel is null");
        }
    }
}
