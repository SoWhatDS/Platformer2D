using System.Collections;
using System.Collections.Generic;
using Platformer2d.Engine.LevelSelect;
using UnityEngine;
using System;
using Object = UnityEngine.Object;
using Platformer2d.Engine.Level;
using Platformer2d.Utils;
using Platformer2d.Settings;
using JoostenProductions;

namespace Platformer2d.Engine.Game.LevelCreate
{
    internal sealed class LevelController : BaseController
    {
        private int _currentMapIndex;
        private int _mapIndexProgress = 0;
        private Map[] _maps;
        private GameObject _levelPrefab;
        private Map _currentMap;
        private LevelView _levelView;
        private PlayerManagerModel _playerManagerModel;

        

        public LevelController(SettingsContainer settingsContainer,PlayerManagerModel playerManagerModel)
        {
            _playerManagerModel = playerManagerModel;
            _maps = settingsContainer.LevelSelectModel.Maps;
            _currentMapIndex = PlayerPrefs.GetInt("currentMap");

            _currentMap = FindCurrentMap();
            _levelView = LoadLevel();
            _levelView.EndLevelPoint.OnCollisionDetected += EndLevel ;
        }

        private void EndLevel(bool isLevelEnd)
        {
            if (isLevelEnd)
            {
                _mapIndexProgress++;
                _playerManagerModel?.OnLevelComplete.Invoke(isLevelEnd);
            }
        }

        private LevelView LoadLevel()
        {
            GameObject objectView = Object.Instantiate(_levelPrefab);
            AddGameObjects(objectView);
            return ResourceLoader.GetOrAddComponent<LevelView>(objectView);
        }

        private Map FindCurrentMap()
        {
            for (int i = 0; i < _maps.Length; i++)
            {
                if (_currentMapIndex == _maps[i].mapIndex)
                {
                    _levelPrefab = _maps[i].loadLevel;
                    return _maps[i];
                }
            }

            throw new ArgumentNullException("Map not found in scriptableObject");
        }

        public LevelView GetLevelView()
        {
            return _levelView;
        }

        protected override void OnDispose()
        {
            _levelView.EndLevelPoint.OnCollisionDetected -= EndLevel;
            PlayerPrefs.SetInt("currentMap", 0);
        }
    }
}
