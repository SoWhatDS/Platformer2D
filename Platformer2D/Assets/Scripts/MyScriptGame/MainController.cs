
using UnityEngine;
using Platformer2d.Settings;
using Platformer2d.Utils;
using System;
using Platformer2d.Engine.MainMenu;
using Platformer2d.Engine.LevelSelect;
using Platformer2d.Engine.Game;
using Platformer2d.Engine.Sound;

namespace Platformer2d.Engine
{
    internal sealed class MainController : BaseController
    {
        private readonly ProfileGame _profileGame;
        private readonly SettingsContainer _settingsContainer;

        private MainMenuController _mainMenuController;
        private LevelSelectController _levelSelectController;
        private GameController _gameController;
        private SoundController _soundController;

        public MainController(ProfileGame profileGame,SettingsContainer settingsContainer)
        {
            _profileGame = profileGame;
            _settingsContainer = settingsContainer;

            _profileGame.CurrentGameState.SubscribeOnChanged(OnChangeGameState);
            OnChangeGameState(_profileGame.CurrentGameState.Value);
        }

        private void OnChangeGameState(GameState gameState)
        {
            DisposeAllControllers();

            CreateSoundController();

            switch (gameState)
            {
                case GameState.MainMenu:
                    _mainMenuController = new MainMenuController(_profileGame);
                    break;
                case GameState.LevelSelect:
                    _levelSelectController = new LevelSelectController(_settingsContainer,_profileGame);
                    break;
                case GameState.StartGame:
                    _gameController = new GameController(_profileGame,_settingsContainer);
                    _soundController.Dispose();
                    break;
                case GameState.QuitGame:
                    QuitGame();
                    break;
                default:
                    DisposeAllControllers();
                    break;
            }
        }

        private void DisposeAllControllers()
        {
            _mainMenuController?.Dispose();
            _levelSelectController?.Dispose();
            _gameController?.Dispose();
        }

        private void QuitGame()
        {
#if (UNITY_EDITOR || DEVELOPMENT_BUILD)
            {
                Debug.Log(this.GetType() + " : " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
#endif

#if (UNITY_EDITOR)
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }

#elif (UNITY_STANDALONE)
            {
               Application.Quit();
            }
#elif (UNITY_WEBGL)
            {
               SceneManager.LoadScene("QuitScene");
            }
#endif
        }

        private void CreateSoundController()
        {
            if (_soundController == null)
            {
                _soundController = new SoundController(_settingsContainer.SoundModel);
            }
        }

        protected override void OnDispose()
        {
            _mainMenuController?.Dispose();
            _levelSelectController?.Dispose();
            _gameController?.Dispose();
            _soundController?.Dispose();
            _profileGame.CurrentGameState.UnSubscribeOnChanged(OnChangeGameState);

            //Hardcode for test saiving
            PlayerPrefs.SetInt("mapIndex", 1);
        }
    }
}
