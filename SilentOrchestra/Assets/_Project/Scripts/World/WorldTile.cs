using Magthylius.Components;
using UnityEngine;

namespace SilentOrchestra.World
{
    [RequireComponent(typeof(HexTile))]
    public class WorldTile : MonoBehaviour
    {
        private HexTile _hex;

        private void Awake()
        {
            _hex = GetComponent<HexTile>();
        }

        public void OnMouseDown()
        {
        }
    }
}