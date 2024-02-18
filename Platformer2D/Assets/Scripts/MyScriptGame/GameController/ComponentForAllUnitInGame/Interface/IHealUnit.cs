using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d.Engine.Game
{
    interface IHealUnit 
    {
        bool Heal(int healthRestore);
    }
}
