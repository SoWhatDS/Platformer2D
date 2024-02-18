
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Platformer2d.Engine.MainMenu
{
    internal sealed class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _levelSelectButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _quitButton;

        private UnityAction _levelSelectAction;
        private UnityAction _settingsAction;
        private UnityAction _quitAction;

        public void Init(UnityAction onlevelSelect,UnityAction onSettingsAction,UnityAction onQuitAction)
        {
            _levelSelectAction = onlevelSelect;
            _settingsAction = onSettingsAction;
            _quitAction = onQuitAction;

            _levelSelectButton.onClick.AddListener(_levelSelectAction);
            _settingsButton.onClick.AddListener(_settingsAction);
            _quitButton.onClick.AddListener(_quitAction);
        }

        private void OnDestroy()
        {
            _levelSelectButton.onClick.RemoveListener(_levelSelectAction);
            _settingsButton.onClick.RemoveListener(_settingsAction);
            _quitButton.onClick.RemoveListener(_quitAction);
        }

    }
}
