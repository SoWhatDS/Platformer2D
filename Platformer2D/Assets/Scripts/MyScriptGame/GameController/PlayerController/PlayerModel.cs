using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer2d.Engine.Game.Player
{
    [CreateAssetMenu(fileName = nameof(PlayerModel), menuName = "Settings/ " + nameof(PlayerModel))]
    internal sealed class PlayerModel : ScriptableObject
    {
        [field: SerializeField] public float WalkSpeed { get; private set; }
        [field: SerializeField] public float RunSpeed { get; private set; }
        [field: SerializeField] public float IdleSpeed { get; private set; } = 0;
        [field: SerializeField] public float JumpImpulse { get; private set; }
        [field: SerializeField] public float AirWalkSpeed { get; private set; }

        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public int MaxHealth { get; private set; }
        [field: SerializeField] public float InvicibilityTime { get; private set; }

        [field: SerializeField] public int AttackDamage { get; private set; }
        [field: SerializeField] public Vector2 KnockBack { get; private set; }

        [field: SerializeField] public int AttackDamage2 { get; private set; }
        [field: SerializeField] public Vector2 KnockBack2 { get; private set; }

        [field: SerializeField] public int AttackDamage3 { get; private set; }
        [field: SerializeField] public Vector2 KnockBack3 { get; private set; }

        [field: SerializeField] public GameObject ArrowPrefab { get; private set; }
        [field: SerializeField] public int DamageArrow { get; private set; }
        [field: SerializeField] public Vector2 MoveSpeedArrow { get; private set; }
        [field: SerializeField] public Vector2 KnockBackArrow { get; private set; }

        [field: SerializeField] public int AirAttackDamage1 { get; private set; }
        [field: SerializeField] public Vector2 AirKnockback1 { get; private set; }

        [field: SerializeField] public int AirAttackDamage2 { get; private set; }
        [field: SerializeField] public Vector2 AirKnockback2 { get; private set; }

        [field: SerializeField] public AudioClip AttackAudioClip { get; private set; }
        [field: SerializeField] public AudioClip DeathAudioClip { get; private set; }
        [field: SerializeField] public AudioClip BowAttackAudioClip { get; private set; }
        [field: SerializeField] public AudioClip HitAudioClip { get; private set; }
        [field: SerializeField] public AudioClip HealAudioClip { get; private set; }

        [field: SerializeField] public int CoinsCount { get; set; }
    }
}
