using System.Collections;
using System.Collections.Generic;
using Platformer2d.Settings;
using Platformer2d.Utils;
using UnityEngine;

namespace Platformer2d.Engine.Game
{
    internal sealed class PlayerManagerController : BaseController
    {
        private ProfileGame _profileGame;
        private PlayerManagerView _playerManagerView;
        private PlayerManagerModel _playerManagerModel;

        private GameOver _gameOver;
        private EndLevel _endLevel;

        public PlayerManagerController(ProfileGame profileGame,PlayerManagerModel playerManagerModel)
        {
            _profileGame = profileGame;
            _playerManagerView = LoadView();
            _playerManagerModel = playerManagerModel;
            _gameOver = new GameOver(_playerManagerView,_profileGame);
            _endLevel = new EndLevel(_playerManagerView, _profileGame);

            Subscribe();
        }

        private PlayerManagerView LoadView()
        {
            GameObject prefab = ResourceLoader.LoadPrefab(GameConstantsView.PlayerManagerView);
            GameObject loadView = Object.Instantiate(prefab);
            AddGameObjects(loadView);
            return ResourceLoader.GetOrAddComponent<PlayerManagerView>(loadView);
        }

        private void Subscribe()
        {
            _playerManagerModel.OnGameOver += _gameOver.GameOverMenu;
            _playerManagerModel.OnLevelComplete += _endLevel.SetActiveEndLevelMenu;
        }

        private void UnSubscribe()
        {
            _playerManagerModel.OnGameOver -= _gameOver.GameOverMenu;
            _playerManagerModel.OnLevelComplete -= _endLevel.SetActiveEndLevelMenu;
        }



        protected override void OnDispose()
        {
            UnSubscribe();
        }
    }
}
