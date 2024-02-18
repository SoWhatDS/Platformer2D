using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d.Engine.Level.InterectableObjects
{
    internal sealed class Coin
    {
        private List<CoinView> _coinsListOnMap;
        private Vector3 _speedRotation;

        public Coin(CoinsView coinsView,Vector3 speedRotation)
        {
            _coinsListOnMap = coinsView.CoinsListOnMap;
            _speedRotation = speedRotation;
        }

        public void RotateAllCoinsOnMap()
        {
            for (int i = 0; i < _coinsListOnMap.Count; i++)
            {
                if (_coinsListOnMap[i].IsDestroyedGameObject)
                {
                    _coinsListOnMap.Remove(_coinsListOnMap[i]);
                }
                else
                {
                    _coinsListOnMap[i].RotationCoin(_speedRotation);
                }
            }
        }
    }
}
