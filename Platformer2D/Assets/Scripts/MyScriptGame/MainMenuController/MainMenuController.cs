
using UnityEngine;
using Platformer2d.Utils;
using Platformer2d.Settings;
using Platformer2d.Engine.LevelSelect;

namespace Platformer2d.Engine.MainMenu
{
    internal sealed class MainMenuController :BaseController
    {
        private ProfileGame _profileGame;
        private MainMenuView _mainMenuView;


        public MainMenuController(ProfileGame profileGame)
        {
            _profileGame = profileGame;
            _mainMenuView = LoadView();
            _mainMenuView.Init(OnLevelSelectMenu,OnSettingsMenu,OnQuitGame);
        }

        private MainMenuView LoadView()
        {
            GameObject prefab = ResourceLoader.LoadPrefab(GameConstantsView.MainMenuView);
            GameObject objectView = Object.Instantiate(prefab);
            AddGameObjects(objectView);
            return ResourceLoader.GetOrAddComponent<MainMenuView>(objectView);          
        }

        private void OnLevelSelectMenu()
        {
            _profileGame.CurrentGameState.Value = GameState.LevelSelect;
        }

        private void OnSettingsMenu()
        {
            _profileGame.CurrentGameState.Value = GameState.Settings;
        }

        private void OnQuitGame()
        {
            _profileGame.CurrentGameState.Value = GameState.QuitGame;
        }

    }
}
