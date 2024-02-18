using System.Collections;
using System.Collections.Generic;
using Platformer2d.Engine.Game.UI;
using UnityEngine;

namespace Platformer2d.Engine.Game.Enemy
{
    internal sealed class KnightEnemyFabric 
    {
        private EnemyModel _enemyModel;
        private UIGameModel _uiGameModel;
        private KnightEnemyController _knightEnemyController;

        public KnightEnemyFabric(EnemyModel enemyModel, UIGameModel uiGameModel)
        {
            _enemyModel = enemyModel;
            _uiGameModel = uiGameModel;
        }

        public KnightEnemyController CreateEnemy(Transform startRespawnPoint)
        {
            _knightEnemyController = new KnightEnemyController(_enemyModel,_uiGameModel,startRespawnPoint);
            return _knightEnemyController;
        }
    }
}
