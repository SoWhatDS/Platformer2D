using System.Collections;
using System.Collections.Generic;
using Platformer2d.Settings;
using UnityEngine;

namespace Platformer2d.Engine.Game
{
    internal sealed class EndLevel 
    {
        private EndLevelView _endLevelView;
        private ProfileGame _profileGame;

        private int _freezeTime = 0;
        private int _resetTime = 1;

        internal EndLevel(PlayerManagerView playerManagerView,ProfileGame profileGame)
        {
            _endLevelView = playerManagerView.EndLevelView;
            _endLevelView.gameObject.SetActive(false);
            _profileGame = profileGame;
            Time.timeScale = _resetTime;
            _endLevelView.Init(MainMenu);
        }

        public void SetActiveEndLevelMenu(bool isLevelComplete)
        {
            _endLevelView.gameObject.SetActive(isLevelComplete);
            Time.timeScale = _freezeTime;
        }

        private void MainMenu()
        {
            _profileGame.CurrentGameState.Value = Utils.GameState.MainMenu;
        }
    }
}
