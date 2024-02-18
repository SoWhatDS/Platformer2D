using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d.Engine.Level.InterectableObjects
{
    internal sealed class PushButtonDown 
    {
        private PushButtonDownModel _pushButtonDownModel;
        private List<PushButtonDownView> _pushButtonDownList;

        public PushButtonDown(WrapsView wrapsView,PushButtonDownModel pushButtonDownModel)
        {
            _pushButtonDownList = wrapsView.PushButtonsDownList;
            _pushButtonDownModel = pushButtonDownModel;

            Initialization();
        }

        private void Initialization()
        {
            for (int i = 0; i < _pushButtonDownList.Count; i++)
            {
                _pushButtonDownList[i].ArrowDownView.Init(_pushButtonDownModel.TakeDamage,_pushButtonDownModel.KnockBack,_pushButtonDownModel.SpeedDown);
            }
        }

        public void MoveArrowDown()
        {
            for (int i = 0; i < _pushButtonDownList.Count; i++)
            {
                if (_pushButtonDownList[i].IsButtonDown)
                {
                    _pushButtonDownList[i].ArrowDownView.MoveDown();
                }
            }
        }


    }
}
