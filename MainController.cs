using System.Linq;
using CarGameScripts.ContentDataSource;
using CarGameScripts.ContentDataSource.Items;
using CarGameScripts.Feature.InventoryFeature;
using CarGameScripts.Feature.InventoryFeature.Interface;
using CarGameScripts.Feature.ShedFeature.UpgradeHandlers;
using CarGameScripts.Garage;
using Game;
using Game.Trail;
using Profile;
using Tools;
using Ui;
using UnityEngine;

internal sealed class MainController : BaseController
{
    private MainMenuController _mainMenuController;
    private GameController _gameController;
    private GarageController _garageController;
    private readonly Transform _placeForUi;
    private readonly ProfilePlayer _profilePlayer;
    private IInventoryModel _inventoryModel;

    public MainController(Transform placeForUi, ProfilePlayer profilePlayer)
    {
        _profilePlayer = profilePlayer;
        _placeForUi = placeForUi;
        _inventoryModel = ConfigureInventoryModel();
        OnChangeGameState(_profilePlayer.CurrentState.Value);
        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
    }

    private void OnChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer);
                _gameController?.Dispose();
                _garageController?.Dispose();
                break;
            case GameState.Garage:
                _garageController = new GarageController(_placeForUi, _profilePlayer, _inventoryModel);
                _mainMenuController?.Dispose();
                break;
            case GameState.Game:
                _gameController = new GameController(_placeForUi, _profilePlayer);
                _mainMenuController?.Dispose();
                break;
            
            default:
                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                break;
        }
    }

    protected override void OnDispose()
    {
        _mainMenuController?.Dispose();
        _gameController?.Dispose();
        _profilePlayer.CurrentState.UnSubscriptionOnChange(OnChangeGameState);
        
		base.OnDispose();
    }
    
    private IInventoryModel ConfigureInventoryModel()
    {
        return new InventoryModel();
    }
}
