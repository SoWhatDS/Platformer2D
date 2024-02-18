using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d.Utils
{
    interface IViewServices 
    {
        T Instantiate<T>(GameObject prefab, Vector3 startPoint);
        T InstantiateInCanvasUI<T>(GameObject prefab, Vector3 startPoint, Transform canvas); 

        void Destroy(GameObject value);
    }
}
