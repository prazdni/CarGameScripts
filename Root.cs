using System;
using Amazon.Util;
using CarGameScripts.Analytic;
using Profile;
using UnityEngine;

internal sealed class Root : MonoBehaviour
{
    [SerializeField] private Transform _placeForUi;
    [SerializeField] private float _speedCar = 15.0f;

    private MainController _mainController;

    private void Awake()
    {
        ProfilePlayer profilePlayer = new ProfilePlayer(_speedCar, new UnityAnalyticTools());
        profilePlayer.CurrentState.Value = GameState.Start;
        _mainController = new MainController(_placeForUi, profilePlayer);
    }

    private void Update()
    {
        _mainController.Execute(Time.deltaTime);
    }

    private void OnDestroy()
    {
        _mainController?.Dispose();
    }
}
