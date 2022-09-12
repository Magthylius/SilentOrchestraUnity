using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilentOrchestra.World
{
    public class WorldTile : MonoBehaviour
    {
        public void OnMouseDown()
        {
            print($"{gameObject.name}");
        }
    }
}
