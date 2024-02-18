using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2d.Utils;
using Platformer2d.Engine.Game.Player;
using JoostenProductions;
using UnityEngine.Events;

namespace Platformer2d.Engine.Game
{
    internal sealed class RangedAttack
    {
        private IViewServices _viewServices;
        private ArrowView _arrowView;
        private PlayerModel _playerModel;
        private Vector3 _startArrowDirection;

        public UnityAction OnBowAttack;

        private List<ArrowView> _arrowsSpawned = new List<ArrowView>();

        public RangedAttack(IViewServices viewServises,PlayerModel playerModel)
        {
            _viewServices = viewServises;
            _playerModel = playerModel;
        }

        public void CreateArrow(Vector3 startFirePoint, Vector3 direction)
        {   
            _arrowView = _viewServices.Instantiate<ArrowView>(_playerModel.ArrowPrefab,startFirePoint);
            _startArrowDirection = _arrowView.transform.localScale;
            
            _arrowView.gameObject.transform.localScale = new Vector3(_startArrowDirection.x * direction.x,
            _startArrowDirection.y, _startArrowDirection.z);
            
            _arrowView.Init(_playerModel.DamageArrow, _playerModel.KnockBackArrow);
            _arrowsSpawned.Add(_arrowView);
            OnBowAttack?.Invoke();
        }

        public void MoveArrow()
        {
            for (int i = 0; i < _arrowsSpawned.Count; i++)
            {
                _arrowsSpawned[i].BowAttack(_playerModel.MoveSpeedArrow);
                _arrowsSpawned[i].SpawnArrowTimer();

                if (_arrowsSpawned[i].GotHit || !_arrowsSpawned[i].IsSpawning)
                {
                    _arrowsSpawned[i].transform.localScale = _startArrowDirection;
                    _viewServices.Destroy(_arrowsSpawned[i].gameObject);
                    _arrowsSpawned[i].GotHit = false;
                    _arrowsSpawned.Remove(_arrowsSpawned[i]);
                }
            }
        }
    }
}
