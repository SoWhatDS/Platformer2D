
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Platformer2d.Engine.Game.Enemy
{
    [CreateAssetMenu(fileName = nameof(EnemyModel), menuName = "Settings/ " + nameof(EnemyModel))]
    internal sealed class EnemyModel : ScriptableObject,IEnemyModel
    {
        [field: SerializeField] public float WalkSpeed { get; private set; }
        [field: SerializeField] public float WalkIdle { get; private set; }
        [field: SerializeField] public float WalkStopRate { get; private set; }

        [field: SerializeField] public int Health { get; private set;}
        [field: SerializeField] public int MaxHealth { get; private set; }
        [field: SerializeField] public float InvicibilityTime { get; private set; }

        [field: SerializeField] public int AttackDamage { get; private set; }
        [field: SerializeField] public Vector2 KnockBack { get; private set; }

        [field: SerializeField] public AudioClip DeathAudioClip { get; private set; }
        [field: SerializeField] public AudioClip HitAudioClip { get; private set; }
    }
}
