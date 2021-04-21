using AI;
using CarGameScripts.Feature.InventoryFeature;
using CarGameScripts.Feature.InventoryFeature.Interface;
using CarGameScripts.Garage;
using CarGameScripts.Reward;
using Game;
using Profile;
using Tools;
using Ui;
using UnityEngine;

internal sealed class MainController : BaseController, IExecute
{
    private MainMenuController _mainMenuController;
    private RewardController _rewardController;
    private GameController _gameController;
    private GarageController _garageController;
    private readonly Transform _placeForUi;
    private readonly ProfilePlayer _profilePlayer;
    private IInventoryModel _inventoryModel;
    private CurrencyController _currencyController;
    private StartFightController _startFightController;
    private FightWindowController _fightWindowController;

    public MainController(Transform placeForUi, ProfilePlayer profilePlayer)
    {
        _profilePlayer = profilePlayer;
        _placeForUi = placeForUi;
        _inventoryModel = ConfigureInventoryModel();
        OnChangeGameState(_profilePlayer.CurrentState.Value);
        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
        
        _rewardController = new RewardController(profilePlayer.CurrentState);
        AddController(_rewardController);
        _currencyController = new CurrencyController();
        AddController(_currencyController);
    }

    private void OnChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer);
                _gameController?.Dispose();
                _garageController?.Dispose();
                _startFightController?.Dispose();
                _fightWindowController?.Dispose();
                break;
            case GameState.Garage:
                _garageController = new GarageController(_placeForUi, _profilePlayer, _inventoryModel);
                _mainMenuController?.Dispose();
                _startFightController?.Dispose();
                _fightWindowController?.Dispose();
                break;
            case GameState.Game:
                _gameController = new GameController(_placeForUi, _profilePlayer);
                _startFightController = new StartFightController(_placeForUi, _profilePlayer);
                _mainMenuController?.Dispose();
                _fightWindowController?.Dispose();
                break;
            case GameState.Fight:
                _fightWindowController = new FightWindowController(_profilePlayer);
                _mainMenuController?.Dispose();
                _startFightController?.Dispose();
                _gameController?.Dispose();
                break;
            default:
                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                _startFightController?.Dispose();
                _fightWindowController?.Dispose();
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

    public void Execute(float deltaTime)
    {
        _rewardController?.Execute(deltaTime);
    }
}
