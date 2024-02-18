using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Platformer2d.Engine.Game.UI
{
    [CreateAssetMenu(fileName = nameof(UIGameModel),menuName = "Settings/ " + nameof(UIGameModel))]
    public sealed class UIGameModel : ScriptableObject
    {
        [field: SerializeField] public Vector3 MoveSpeed { get; private set;}
        [field: SerializeField] public float TimeToFade { get; private set; }

        public UnityAction<Vector3,int> OnTakeDamageUnit;
        public UnityAction<Vector3,int> OnHealedUnit;

        public UnityAction<float,float> OnChangeHealthUI;

        public UnityAction<int> OnChageCountCoinText;
    }
}
