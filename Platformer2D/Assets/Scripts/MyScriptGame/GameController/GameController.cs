using System;
using System.Collections;
using System.Collections.Generic;
using Platformer2d.Engine.Game.Player;
using Platformer2d.Settings;
using Platformer2d.Engine.Game.LevelCreate;
using UnityEngine;
using Platformer2d.Engine.BackGround;
using Platformer2d.Engine.Game.Enemy;
using Platformer2d.Engine.Game.UI;
using Platformer2d.Utils;
using Platformer2d.Engine.Sound;
using Platformer2d.Engine.Level.InterectableObjects;

namespace Platformer2d.Engine.Game
{
    internal sealed class GameController : BaseController
    {
        private ProfileGame _profileGame;
        private SettingsContainer _settingsContainer;
        private IViewServices _viewServices;

        private LevelController _levelController;
        private PlayerController _playerController;
        private BackGroundController _backGroundController;
        private UIGameController _uiGameController;
        private EnemyFabricController _enemyFabricController;
        private KnightEnemyFabric _knightEnemyFabric;
        private FlyingEyeEnemyFabric _flyingEyeEnemyFabric;
        private SoundController _soundController;
        private InteractibleObjectsController _interactibleObjectController;
        private PlayerManagerController _playerManagerController;

        public GameController(ProfileGame profileGame,SettingsContainer settingsContainer)
        {
            _profileGame = profileGame;
            _settingsContainer = settingsContainer;
            _viewServices = new ViewServices();
            _knightEnemyFabric = new KnightEnemyFabric(_settingsContainer.KnightModel, _settingsContainer.UIGameModel);
            _flyingEyeEnemyFabric = new FlyingEyeEnemyFabric(_settingsContainer.FlyingEyeModel, _settingsContainer.UIGameModel);

            CreateControllers();
        }

        private void CreateControllers()
        {
            _levelController = new LevelController(_settingsContainer,_settingsContainer.PlayerManagerModel);
            AddControllers(_levelController);

            _uiGameController = new UIGameController(_settingsContainer.UIGameModel, _levelController.GetLevelView().UIGameView, _viewServices);
            AddControllers(_uiGameController);

            _playerController = new PlayerController(_settingsContainer.PlayerModel,_settingsContainer.UIGameModel,_viewServices,
                _settingsContainer.PlayerManagerModel,_levelController.GetLevelView().StartRespwanPlayerPoint);
            AddControllers(_playerController);

            _backGroundController = new BackGroundController(_levelController.GetLevelView().BackGroundView);
            AddControllers(_backGroundController);
            
            _enemyFabricController = new EnemyFabricController(_flyingEyeEnemyFabric,_knightEnemyFabric,
                _levelController.GetLevelView().RespawnPointsForKnight,_levelController.GetLevelView().RespwanPointForFlyingEye);
            AddControllers(_enemyFabricController);

            _soundController = new SoundController(_settingsContainer.SoundModel);
            AddControllers(_soundController);

            _interactibleObjectController = new InteractibleObjectsController(_levelController.GetLevelView().InterectibleObjectsView,_settingsContainer.InterectibleObjectsModel);
            AddControllers(_interactibleObjectController);

            _playerManagerController = new PlayerManagerController(_profileGame,_settingsContainer.PlayerManagerModel);
            AddControllers(_playerManagerController);


        }

        protected override void OnDispose()
        {
            _levelController?.Dispose();
            _playerController?.Dispose();
            _backGroundController?.Dispose();
            _enemyFabricController?.Dispose();
            _uiGameController?.Dispose();
            _soundController?.Dispose();
            _interactibleObjectController?.Dispose();
            _playerManagerController?.Dispose();
        }
    }
}
