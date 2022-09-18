using Magthylius.Components;
using UnityEngine;

namespace SilentOrchestra.World
{
    using SilentOrchestra.Shell;
    
    [RequireComponent(typeof(HexTile))]
    public class WorldTile : MonoBehaviour
    {
        [SerializeField] private WorldTileType type = WorldTileType.Plains;
        
        protected HexTile Hex => GetComponent<HexTile>();
        public WorldTileType Type => type;

        public WorldTile TopRight => GetNeighbourTile(0);
        public WorldTile Right => GetNeighbourTile(1);
        public WorldTile BottomRight => GetNeighbourTile(2);
        public WorldTile BottomLeft => GetNeighbourTile(3);
        public WorldTile Left => GetNeighbourTile(4);
        public WorldTile TopLeft => GetNeighbourTile(5);

        private WorldTile GetNeighbourTile(int index)
        {
            HexTile target = null;
            switch (index)
            {
                case 0: target = Hex.TopRightTile; break;
                case 1: target = Hex.RightTile; break;
                case 2: target = Hex.BottomRightTile; break;
                case 3: target = Hex.BottomLeftTile; break;
                case 4: target = Hex.LeftTile; break;
                case 5: target = Hex.TopLeftTile; break;
                default: return null;
            }

            return target == null ? null : target.GetComponent<WorldTile>();
        }
    }
}