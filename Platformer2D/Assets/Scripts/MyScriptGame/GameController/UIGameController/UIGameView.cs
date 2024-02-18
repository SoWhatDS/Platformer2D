using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Platformer2d.Engine.Game.UI
{
    internal sealed class UIGameView : MonoBehaviour
    {
        [field: SerializeField] public TMP_Text DamageText;
        [field: SerializeField] public TMP_Text HealedText;
        [field: SerializeField] public Canvas UICanvas;
        [field: SerializeField] public UIHealthView PlayerHealthUI;
        [field: SerializeField] public TMP_Text PlayerCoinCount;
    }
}
