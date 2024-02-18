using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d.Engine.Sound
{
    [CreateAssetMenu(fileName = nameof(SoundModel), menuName = "Settings/ " + nameof(SoundModel))]
    public class SoundModel : ScriptableObject
    {
        [field: SerializeField] public AudioClip IntroAudioClip { get; private set; }
        [field: SerializeField] public AudioClip LoopBackGroundAudioClip { get; private set; }
    }
}
