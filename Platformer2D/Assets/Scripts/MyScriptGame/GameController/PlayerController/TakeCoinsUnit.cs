using System;
using System.Collections;
using System.Collections.Generic;
using Platformer2d.Engine.Game.UI;
using UnityEngine;

namespace Platformer2d.Engine.Game.Player
{
    public class TakeCoinsUnit : ITakeCoins
    {
        private int _coinsCount;
        private UIGameModel _uiGameModel;

        public TakeCoinsUnit(int coinsCount,UIGameModel uiGameModel)
        {
            _coinsCount = coinsCount;
            _uiGameModel = uiGameModel;
            _uiGameModel.OnChageCountCoinText?.Invoke(_coinsCount);
        }

        public void TakeCoin()
        {
            _coinsCount++;
            _uiGameModel.OnChageCountCoinText?.Invoke(_coinsCount);
        }
    }
}
