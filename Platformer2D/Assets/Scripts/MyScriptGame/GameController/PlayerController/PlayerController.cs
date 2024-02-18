using System.Collections;
using System.Collections.Generic;
using JoostenProductions;
using Platformer2d.Engine.Game.UI;
using Platformer2d.Engine.Sound;
using Platformer2d.Utils;
using UnityEngine;

namespace Platformer2d.Engine.Game.Player
{
    internal sealed class PlayerController : BaseController
    {
        private PlayerView _playerView;
        private PlayerModel _playerModel;
        private Player _player;
        private Transform _startRespwanPoint;

        public PlayerController(PlayerModel playerModel,UIGameModel uiGameModel,IViewServices viewServices,PlayerManagerModel playerManagerModel,Transform startRespawnPoint)
        {
            _startRespwanPoint = startRespawnPoint;
            _playerView = LoadView();
            _playerModel = playerModel;
            _player = new Player(_playerView, _playerModel,uiGameModel,viewServices,playerManagerModel);
            UpdateManager.SubscribeToFixedUpdate(FixedUpdate);
            UpdateManager.SubscribeToUpdate(Update);
        }

        private PlayerView LoadView()
        {
            GameObject prefab = ResourceLoader.LoadPrefab(GameConstantsView.PlayerView);
            GameObject objectView = Object.Instantiate(prefab,_startRespwanPoint);
            AddGameObjects(objectView);
            return ResourceLoader.GetOrAddComponent<PlayerView>(objectView);
        }

        private void FixedUpdate()
        {
            CheckTouchingDirections();
            OnRigidbodyMove();
            OnRigidbodyJump();
            MoveArrow();
        }

        private void Update()
        {
            HitTimer();
        }

        private void OnRigidbodyMove()
        {
            _player.RigidbodyPlayerMove();
        }

        private void OnRigidbodyJump()
        {
            _player.RigidbodyPlayerJump();
        }

        private void CheckTouchingDirections()
        {
            _player.CheckTouchingDirections();
        }

        private void HitTimer()
        {
            _player.HitTimer();
        }

        private void MoveArrow()
        {
            _player.MoveArrow();
        }

        protected override void OnDispose()
        {
            _player.UnSubscribeOnAction();
            UpdateManager.UnsubscribeFromFixedUpdate(FixedUpdate);
            UpdateManager.UnsubscribeFromUpdate(Update);
        }
    }
}
