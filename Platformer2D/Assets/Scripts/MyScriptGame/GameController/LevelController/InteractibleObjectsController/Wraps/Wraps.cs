using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d.Engine.Level.InterectableObjects
{
    internal sealed class Wraps 
    {
        private LaserBeamer _laserBeamer;
        private PushButtonDown _pushButtonDown;

        public Wraps(WrapsView wrapsView, WrapsModel wrapsModel)
        {
            _laserBeamer = new LaserBeamer(wrapsView, wrapsModel.LaserBeamerModel);
            _pushButtonDown = new PushButtonDown(wrapsView, wrapsModel.PushButtonDownModel);
        }

        public void MoveDownArrow()
        {
            _pushButtonDown.MoveArrowDown();
        }
    }
}
