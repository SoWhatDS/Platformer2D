using System.Collections;
using System.Collections.Generic;
using Platformer2d.Utils;
using TMPro;
using UnityEngine;

namespace Platformer2d.Engine.Game.UI
{
    internal sealed class UIGameText
    {
        private TMP_Text _uiText;
        private UIGameModel _uiGameModel;
        private IViewServices _viewServices;

        private Color _startColor;
        private float _timeElapsed = 0f;
        private bool _isDestroyedText;

        public bool IsDestroyedText
        {
            get { return _isDestroyedText; }
        }

        public UIGameText(TMP_Text uiText, UIGameModel uiGameModel, IViewServices viewServices,Color startColor)
        {
            _uiText = uiText;
            _uiGameModel = uiGameModel;
            _viewServices = viewServices;
            _isDestroyedText = false;
            _startColor = startColor;
        }

        private void MoveTextUP()
        {
            _uiText.transform.position += _uiGameModel.MoveSpeed * Time.deltaTime;
        }

        public void FadeTextTimer()
        {
            if (_uiText == null)
            {
                return;
            }

            MoveTextUP();

            _timeElapsed += Time.deltaTime;

            if (_timeElapsed < _uiGameModel.TimeToFade)
            {
                float fadeAlpha = _startColor.a * (1 - (_timeElapsed / _uiGameModel.TimeToFade));
                _uiText.color = new Color(_startColor.r, _startColor.g, _startColor.b, fadeAlpha);
            }
            else
            {
                _isDestroyedText = true;
                _viewServices.Destroy(_uiText.gameObject);
                _uiText.color = _startColor;
                _timeElapsed = 0;
                _uiText = null;
            }
        }
    }
}
