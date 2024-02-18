using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d.Engine.Level.InterectableObjects
{
    internal sealed class Platforms 
    {
        private List<IMovementPlatform> _platforms;

        public Platforms(PlatformsView platformsView)
        {
            _platforms = platformsView.GetAllPlatforms();
        }

        public void SubscribePlatformsOnFlipDirection()
        {
            for (int i = 0; i < _platforms.Count; i++)
            {
                _platforms[i].SubscribeToFlipDirection();
            }
        }

        public void UnSubscribeToFlipDirection()
        {
            for (int i = 0; i < _platforms.Count; i++)
            {
                _platforms[i].UnSubscribeToFlipDirection();
            }
        }
    }
}
