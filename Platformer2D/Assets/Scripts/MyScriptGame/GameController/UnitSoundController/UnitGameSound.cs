using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d.Engine.Game.UnitSound
{
    internal sealed class UnitGameSound
    {
        private AudioSource _unitAudioSource;

        public UnitGameSound(AudioSource unitAudioSource)
        {
            _unitAudioSource = unitAudioSource;
        }

        public void PlayOneShotSound(AudioClip audioClip)
        {
            _unitAudioSource.PlayOneShot(audioClip);
        }
    }
}
