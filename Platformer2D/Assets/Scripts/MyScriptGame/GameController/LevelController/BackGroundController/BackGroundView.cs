using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Platformer2d.Engine.Game.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer2d.Engine.BackGround
{
    internal sealed class BackGroundView : MonoBehaviour
    {
        [field: SerializeField] public GameObject[] ChildBackGroundsPrefabs;
        [field: SerializeField] public Renderer[] ChildBackGroundRenderers;
        [field: SerializeField] public float ParallaxSpeed;
    }
}
