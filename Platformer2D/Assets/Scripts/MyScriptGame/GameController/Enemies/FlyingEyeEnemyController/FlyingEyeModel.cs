using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d.Engine.Game.Enemy
{
    [CreateAssetMenu(fileName = nameof(FlyingEyeModel),menuName = "Settings/ " + nameof(FlyingEyeModel))]
    internal sealed class FlyingEyeModel : ScriptableObject,IEnemyModel
    {
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public int MaxHealth { get; private set; }
        [field: SerializeField] public float InvicibilityTime { get; private set; }

        [field: SerializeField] public int AttackDamage { get; private set; }
        [field: SerializeField] public Vector2 Knockback { get; private set; }

        [field: SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public float IdleSpeed { get; private set; } = 0;

        [field: SerializeField] public AudioClip DeathAudioClip { get; private set; }
        [field: SerializeField] public AudioClip HitAudioClip { get; private set; }

      
    }
}
