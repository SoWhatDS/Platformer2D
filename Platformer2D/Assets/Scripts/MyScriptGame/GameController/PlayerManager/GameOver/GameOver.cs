using System.Collections;
using System.Collections.Generic;
using Platformer2d.Settings;
using UnityEngine;

namespace Platformer2d.Engine.Game
{
    internal sealed class GameOver 
    {
        private GameOverView _gameOverView;
        private ProfileGame _profileGame;

        private int _freezeTime = 0;
        private int _resetTime = 1;

        public GameOver(PlayerManagerView playerManagerView, ProfileGame profileGame)
        {
            _gameOverView = playerManagerView.GameOverView;
            _gameOverView.gameObject.SetActive(false);
            _profileGame = profileGame;
            Time.timeScale = _resetTime;
            _gameOverView.Init(Retry,MainMenu);
        }

        public void GameOverMenu(bool isPlayerDeath)
        {
            _gameOverView.SetActiveMenu(isPlayerDeath);
            Time.timeScale = _freezeTime;
        }

        private void Retry()
        {
            _profileGame.CurrentGameState.Value = Utils.GameState.StartGame;
        }

        private void MainMenu()
        {
            _profileGame.CurrentGameState.Value = Utils.GameState.MainMenu;
        }
      
    }
}
