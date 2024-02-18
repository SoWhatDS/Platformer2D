using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d.Engine.Level.InterectableObjects
{
    internal sealed class PlatformsView : MonoBehaviour
    {
        [SerializeField] private List<VerticalPlatformView> _verticalPlatforms;
        [SerializeField] private List<HorizontalViewPlatform> _horizontalPlatforms;

        private List<IMovementPlatform> _allPlatforms = new List<IMovementPlatform>();

        public List<IMovementPlatform> GetAllPlatforms()
        {
            GetAllVerticalPlatforms();
            GetAllHorizontalPlatforms();
            return _allPlatforms;
        }

        private void GetAllVerticalPlatforms()
        {
            for (int i = 0; i < _verticalPlatforms.Count; i++)
            {
                if (_verticalPlatforms[i] is IMovementPlatform platform)
                {
                    _allPlatforms.Add(platform);
                }
            }
        }

        private void GetAllHorizontalPlatforms()
        {
            for (int i = 0; i < _horizontalPlatforms.Count; i++)
            {
                if (_horizontalPlatforms[i] is IMovementPlatform platfrom)
                {
                    _allPlatforms.Add(platfrom);
                }
            }
        }

    }
}
