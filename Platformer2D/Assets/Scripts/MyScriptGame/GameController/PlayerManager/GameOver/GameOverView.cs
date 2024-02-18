using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Platformer2d.Engine.Game
{
    internal sealed class GameOverView : MonoBehaviour
    {
        [SerializeField] private Button _retryButton;
        [SerializeField] private Button _mainMenuButton;

        private UnityAction _retryAction;
        private UnityAction _mainMenuAction;

        public void SetActiveMenu(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        public void Init(UnityAction retryAction, UnityAction mainMenuAction)
        {
            _retryAction = retryAction;
            _mainMenuAction = mainMenuAction;

            _retryButton.onClick.AddListener(_retryAction);
            _mainMenuButton.onClick.AddListener(_mainMenuAction);
        }

        private void OnDestroy()
        {
            _retryButton.onClick.RemoveListener(_retryAction);
            _mainMenuButton.onClick.RemoveListener(_mainMenuAction);
        }
    }
}
