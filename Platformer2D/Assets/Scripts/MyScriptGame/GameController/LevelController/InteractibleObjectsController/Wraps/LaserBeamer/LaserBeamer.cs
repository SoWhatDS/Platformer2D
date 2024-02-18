using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d.Engine.Level.InterectableObjects
{
    internal sealed class LaserBeamer 
    {
        private LaserBeamerModel _laserBeamerModel;
        private List<LaserBeamerView> _lasersBeamer;

        public LaserBeamer(WrapsView wrapsView, LaserBeamerModel laserBeamerModel)
        {
            _laserBeamerModel = laserBeamerModel;
            _lasersBeamer = wrapsView.LaserBeamerList;

            Initialization();
        }

        private void Initialization()
        {
            for (int i = 0; i < _lasersBeamer.Count; i++)
            {
                _lasersBeamer[i].Init(_laserBeamerModel.TakeDamage, _laserBeamerModel.KnockBack);
            }
        }
    }
}
