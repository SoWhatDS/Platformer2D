using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d.Engine.Level.InterectableObjects
{
    internal sealed class HealthPickUp 
    {
        private List<UIHealthPickUp> _uiHealthPickUpList;
        private UIHealthPickUpModel _uiHealthPickUpModel;

        public HealthPickUp(UIHealthPickUpView uiHealthPickUpView,UIHealthPickUpModel uiHealthPickUpModel)
        {
            _uiHealthPickUpList = uiHealthPickUpView.UIHealthPickUpList;
            _uiHealthPickUpModel = uiHealthPickUpModel;

            Initialization();
        }

        private void Initialization()
        {
            for (int i = 0; i < _uiHealthPickUpList.Count; i++)
            {
                _uiHealthPickUpList[i].Init(_uiHealthPickUpModel.HealthRestore);
            }
        }

        public void RotationUIHealthPickUp()
        {
            if (_uiHealthPickUpList.Count == 0)
            {
                return;
            }

            for (int i = 0; i < _uiHealthPickUpList.Count; i++)
            {
                if (_uiHealthPickUpList[i].IsDestroyedGameObject)
                {
                    _uiHealthPickUpList.Remove(_uiHealthPickUpList[i]);
                }
                else
                {
                    _uiHealthPickUpList[i].RotationPickUp(_uiHealthPickUpModel.RotationSpeed);
                }
            }
        }
    }
}
