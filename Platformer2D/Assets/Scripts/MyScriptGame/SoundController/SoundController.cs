using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2d.Utils;
using JoostenProductions;
using UnityEngine.Events;

namespace Platformer2d.Engine.Sound
{
    internal sealed class SoundController : BaseController
    {
        private SoundView _soundView;
        private SoundModel _soundModel;

        public SoundController(SoundModel soundModel)
        {
            _soundView = LoadView();
            _soundModel = soundModel;
            PlayBackGroundSound();
        }

        private SoundView LoadView()
        {
            GameObject prefab = ResourceLoader.LoadPrefab(GameConstantsView.SoundView);
            GameObject objectView = Object.Instantiate(prefab);
            AddGameObjects(objectView);
            return ResourceLoader.GetOrAddComponent<SoundView>(objectView);
        }

        private void PlayBackGroundSound()
        {
            _soundView.IntroAudioSourceInGame.clip = _soundModel.IntroAudioClip;
            _soundView.LoopAudioSourceInGame.clip = _soundModel.LoopBackGroundAudioClip;
            _soundView.LoopAudioSourceInGame.loop = true;
            _soundView.IntroAudioSourceInGame.Play();
            _soundView.LoopAudioSourceInGame.PlayScheduled(AudioSettings.dspTime + _soundView.IntroAudioSourceInGame.clip.length);
        }

        private void PlayOneShotSound(AudioSource audiosource,AudioClip audioClip)
        {
            //audiosource.clip = audioClip;
            audiosource.PlayOneShot(audioClip);
        }

        protected override void OnDispose()
        {
            
        }
    }
}
