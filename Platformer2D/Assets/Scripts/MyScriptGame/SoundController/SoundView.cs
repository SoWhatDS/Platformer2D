using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d.Engine.Sound
{
    internal sealed class SoundView : MonoBehaviour
    {
        [field: SerializeField] public AudioSource IntroAudioSourceInGame;
        [field: SerializeField] public AudioSource LoopAudioSourceInGame;
    }
}
