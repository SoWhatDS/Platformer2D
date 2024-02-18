using System.Collections;
using System.Collections.Generic;
using Platformer2d.Engine.Game;
using UnityEngine;
using UnityEngine.Events;

namespace Platformer2d.Engine.Level.InterectableObjects
{
    interface IMovementPlatform 
    {
        void SubscribeToFlipDirection();

        void UnSubscribeToFlipDirection();
    }
}
