using System.Collections;
using System.Collections.Generic;
using Platformer2d.Engine.Game.UI;
using UnityEngine;

namespace Platformer2d.Engine.Game.Enemy
{
    internal sealed class FlyingEyeEnemyFabric
    {
        private FlyingEyeModel _flyingEyeModel;
        private UIGameModel _uiGameModel;
        private FlyingEyeController _flyingEyeController;

        public FlyingEyeEnemyFabric(FlyingEyeModel flyingEyeModel,UIGameModel uiGameModel)
        {
            _flyingEyeModel = flyingEyeModel;
            _uiGameModel = uiGameModel;
        }

        public FlyingEyeController CreateEnemy(Transform startRespawnPoint)
        {
            _flyingEyeController = new FlyingEyeController(_flyingEyeModel, _uiGameModel,startRespawnPoint);
            return _flyingEyeController;
        }
    }
}
