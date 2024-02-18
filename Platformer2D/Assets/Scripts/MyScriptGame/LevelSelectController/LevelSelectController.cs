
using UnityEngine;
using Platformer2d.Settings;
using Platformer2d.Utils;

namespace Platformer2d.Engine.LevelSelect
{
    internal sealed class LevelSelectController : BaseController
    {
        private LevelSelectView _levelSelectView;
        private ProfileGame _profileGame;
        private Map[] _maps;
        private int _currentIndex = 0;
        private int _changeableIndex = 0;
        private int _mapIndex = 1;

        public LevelSelectController(SettingsContainer settingsContainer,ProfileGame profileGame)
        {
            _profileGame = profileGame;
            _levelSelectView = LoadView();
            _maps = settingsContainer.LevelSelectModel.Maps;
            _levelSelectView.DisplayMap(_maps[_currentIndex]);
            _levelSelectView.Init(DecreaseIndex,IncreaseIndex,StartGame);
        }

        private LevelSelectView LoadView()
        {
            GameObject prefab = ResourceLoader.LoadPrefab(GameConstantsView.LevelSelectView);
            GameObject objectView = Object.Instantiate<GameObject>(prefab);
            AddGameObjects(objectView);
            return ResourceLoader.GetOrAddComponent<LevelSelectView>(objectView);
        }

        private void ChangeMap(int changeNumber)
        {
            _currentIndex = changeNumber;
            _levelSelectView.DisplayMap(_maps[_currentIndex]);
        }

        private void IncreaseIndex()
        {
            _changeableIndex++;

            if (_changeableIndex > _maps.Length - 1)
            {
                _changeableIndex = 0;
            }
            ChangeMap(_changeableIndex);
        }

        private void DecreaseIndex()
        {
            _changeableIndex--;

            if (_changeableIndex < 0)
            {
                _changeableIndex = _maps.Length-1;
            }

            ChangeMap(_changeableIndex);
        }

        private void StartGame()
        {
            PlayerPrefs.SetInt("currentMap", _currentIndex);
            _profileGame.CurrentGameState.Value = GameState.StartGame;
        }
    }
}
