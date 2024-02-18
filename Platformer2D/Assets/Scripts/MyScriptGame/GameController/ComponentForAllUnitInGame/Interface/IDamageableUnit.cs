using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Platformer2d.Engine.Game
{
    interface IDamageableUnit 
    {
        bool Hit(int damage,Vector2 knockback);
        void HitTimer();
    }
}
