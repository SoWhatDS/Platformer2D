using System.Collections;
using System.Collections.Generic;
using JoostenProductions;
using Platformer2d.Engine.Game.UI;
using UnityEngine;

namespace Platformer2d.Engine.Level.InterectableObjects
{
    internal sealed class InteractibleObjectsController : BaseController
    {
        private Platforms _platforms;
        private HealthPickUp _healthPickUp;
        private Wraps _wraps;
        private Coin _coin;

        public InteractibleObjectsController(InterectibleObjectsView interectibleObjectsView,InterectibleObjectsModel interectibleObjectsModel)
        {
            _platforms = new Platforms(interectibleObjectsView.Platforms);
            _healthPickUp = new HealthPickUp(interectibleObjectsView.UIHealthPickUp,interectibleObjectsModel.UIHealthPickUpModel);
            _wraps = new Wraps(interectibleObjectsView.Wraps,interectibleObjectsModel.WrapsModel);
            _coin = new Coin(interectibleObjectsView.CoinsOnMap,interectibleObjectsModel.CoinModel.SpeedRotation);

            SubscribeObjects();
        }

        private void Update()
        {
            _healthPickUp.RotationUIHealthPickUp();
            _wraps.MoveDownArrow();
            _coin.RotateAllCoinsOnMap();
        }

        private void SubscribeObjects()
        {
            _platforms.SubscribePlatformsOnFlipDirection();
            UpdateManager.SubscribeToUpdate(Update);
        }

        private void UnSubscribeObjects()
        {
            _platforms.UnSubscribeToFlipDirection();
            UpdateManager.UnsubscribeFromUpdate(Update);
        }

        protected override void OnDispose()
        {
            UnSubscribeObjects();
        }
    }
}
