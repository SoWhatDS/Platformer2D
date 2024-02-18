using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d.Engine.Game.Player
{
    interface IMoveRigidbodyPlayer
    {
        void RigidbodyMove(Vector2 moveInput, float currentSpeed);

        void RigidbodyJump(float jumpImpulse);
    }
}
