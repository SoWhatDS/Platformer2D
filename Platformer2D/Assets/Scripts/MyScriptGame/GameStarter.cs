using Platformer2d.Utils;
using Platformer2d.Settings;
using UnityEngine;

namespace Platformer2d.Engine
{
    internal sealed class GameStarter : MonoBehaviour
    {
        [SerializeField] private SettingsContainer _settingsContainer;

        private const GameState InitialGameState = GameState.MainMenu;

        private MainController _mainController;

        private void Start()
        {
            ProfileGame profileGame = new ProfileGame(InitialGameState);
            _mainController = new MainController(profileGame,_settingsContainer);
        }

        private void OnDestroy()
        {
            _mainController.Dispose();
        }
    }
}
