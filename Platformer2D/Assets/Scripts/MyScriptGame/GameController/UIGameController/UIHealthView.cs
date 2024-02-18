using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer2d.Engine.Game.UI
{
    internal sealed class UIHealthView : MonoBehaviour
    {
        [field: SerializeField] public Slider UISliderHealth;
        [field: SerializeField] public TMP_Text UIHealthText;
    }
}
