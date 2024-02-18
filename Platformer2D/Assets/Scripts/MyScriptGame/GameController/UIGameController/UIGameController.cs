using System;
using System.Collections;
using System.Collections.Generic;
using JoostenProductions;
using Platformer2d.Utils;
using TMPro;
using UnityEngine;

namespace Platformer2d.Engine.Game.UI
{
    internal sealed class UIGameController : BaseController
    {
        private UIGameModel _uiGameModel;
        private UIGameView _uiGameView;
        private IViewServices _viewServices;

        private TMP_Text _damageText;
        private TMP_Text _healedtext;
        private Color _startColorDamageText;
        private Color _startColorHealedText;

        private List<UIGameText> _uiDamageTextSpawned;
        private List<UIGameText> _uiHealthTextSpawned;

        public UIGameController(UIGameModel uiGameModel,UIGameView uiGameView,IViewServices viewServices)
        {
            _uiGameModel = uiGameModel;
            _uiGameView = uiGameView;
            _viewServices = viewServices;

            _uiDamageTextSpawned = new List<UIGameText>();
            _uiHealthTextSpawned = new List<UIGameText>();

            _startColorDamageText = _uiGameView.DamageText.color;
            _startColorHealedText = _uiGameView.HealedText.color;

            SetStartValue();

            _uiGameModel.OnTakeDamageUnit += TakeDamageUnitUI;
            _uiGameModel.OnHealedUnit += HealedUnitUI;
            _uiGameModel.OnChangeHealthUI += UpdateHealthUI;
            _uiGameModel.OnChageCountCoinText += UpdateCountCoinText;

            UpdateManager.SubscribeToUpdate(Update);
        }

        private void UpdateCountCoinText(int countCoin)
        {
            _uiGameView.PlayerCoinCount.text = countCoin.ToString();
        }

        private void Update()
        {
            FadeTextTimer(_uiDamageTextSpawned);
            FadeTextTimer(_uiHealthTextSpawned);
        }

        private void TakeDamageUnitUI(Vector3 startPoint,int takeDamage)
        {
            Vector3 spawnPosition = Camera.main.WorldToScreenPoint(startPoint);
            _damageText = _viewServices.InstantiateInCanvasUI<TMP_Text>(_uiGameView.DamageText.gameObject, spawnPosition,_uiGameView.UICanvas.transform);
            _damageText.text = takeDamage.ToString();
            UIGameText damageText = new UIGameText(_damageText,_uiGameModel,_viewServices,_startColorDamageText);
            _uiDamageTextSpawned.Add(damageText);
        }

        private void HealedUnitUI(Vector3 startPoint,int healed)
        {
            Vector3 spawnPosition = Camera.main.WorldToScreenPoint(startPoint);
            _healedtext = _viewServices.InstantiateInCanvasUI<TMP_Text>(_uiGameView.HealedText.gameObject, spawnPosition, _uiGameView.UICanvas.transform);
            _healedtext.text = healed.ToString();
            UIGameText healedText = new UIGameText(_healedtext,_uiGameModel,_viewServices,_startColorHealedText);
            _uiHealthTextSpawned.Add(healedText);
        }

        private void FadeTextTimer(List<UIGameText> uiGameText)
        {
            if (uiGameText.Count == 0)
            {
                return;
            }

            for (int i = 0; i < uiGameText.Count; i++)
            {
                uiGameText[i].FadeTextTimer();

                if (uiGameText[i].IsDestroyedText)
                {
                    uiGameText.Remove(uiGameText[i]);
                }
            }
        }

        private void UpdateHealthUI(float health,float maxHealth)
        {
            _uiGameView.PlayerHealthUI.UISliderHealth.value = CalculateSliderPercentage(health,maxHealth);
            _uiGameView.PlayerHealthUI.UIHealthText.text = "Health " + health + " / " + maxHealth;
        }

        private void SetStartValue()
        {
            _uiGameView.PlayerHealthUI.UISliderHealth.value = 1;
        }

        private float CalculateSliderPercentage(float health,float maxHealth)
        {
            return health / maxHealth;
        }

        protected override void OnDispose()
        {
            _uiGameModel.OnTakeDamageUnit -= TakeDamageUnitUI;
            _uiGameModel.OnHealedUnit -= HealedUnitUI;
            _uiGameModel.OnChangeHealthUI -= UpdateHealthUI;
            _uiGameModel.OnChageCountCoinText -= UpdateCountCoinText;

        }

    }
}
