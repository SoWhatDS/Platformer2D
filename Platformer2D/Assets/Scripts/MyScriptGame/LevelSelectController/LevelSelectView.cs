using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Platformer2d.Engine.LevelSelect
{
    internal sealed class LevelSelectView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _mapName;
        [SerializeField] private TMP_Text _mapDescription;
        [SerializeField] private Image _mapImage;
        [SerializeField] private Button _prevButton;
        [SerializeField] private Button _nextButton;
        [SerializeField] private Button _playButton;
        [SerializeField] private GameObject _lockImage;

        private bool _mapUnlocked;

        private UnityAction _prevAction;
        private UnityAction _nextAction;
        private UnityAction _startGameAction;

        public void Init(UnityAction prevAction,UnityAction nextAction,UnityAction startGameAction)
        {
            _prevAction = prevAction;
            _nextAction = nextAction;
            _startGameAction = startGameAction;

            _prevButton.onClick.AddListener(_prevAction);
            _nextButton.onClick.AddListener(_nextAction);
            _playButton.onClick.AddListener(_startGameAction);
        }

        public void DisplayMap(Map map)
        {
            _mapName.text = map.mapName;
            _mapDescription.text = map.mapDescription;
            _mapImage.sprite = map.mapImage;

            if (map.mapIndex <= PlayerPrefs.GetInt("currentMap"))
            {
                _mapUnlocked = true;
            }
            else
            {
                _mapUnlocked = false;
            }

            _lockImage.SetActive(!_mapUnlocked);
            _playButton.interactable = _mapUnlocked;

            if (_mapUnlocked)
            {
                _mapImage.color = Color.white;
            }
            else
            {
                _mapImage.color = Color.grey;
            }

        }

        private void OnDestroy()
        {
            _prevButton.onClick.RemoveListener(_prevAction);
            _nextButton.onClick.RemoveListener(_nextAction);
            _playButton.onClick.RemoveListener(_startGameAction);
        }
    }
}
