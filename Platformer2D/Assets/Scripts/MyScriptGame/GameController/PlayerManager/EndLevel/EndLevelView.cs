using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Platformer2d.Engine.Game
{
    public class EndLevelView : MonoBehaviour
    {
        [SerializeField] private Button _mainMenuButton;

        private UnityAction _mainMenuAction;

        public void Init(UnityAction mainMenuAction)
        {
            _mainMenuAction = mainMenuAction;
            _mainMenuButton.onClick.AddListener(_mainMenuAction);
        }

        private void OnDestroy()
        {
            _mainMenuButton.onClick.RemoveListener(_mainMenuAction);
        }
    }
}
