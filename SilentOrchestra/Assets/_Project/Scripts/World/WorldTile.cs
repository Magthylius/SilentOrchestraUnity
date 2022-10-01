using System;
using System.Collections.Generic;
using System.Linq;
using Magthylius.Components;
using UnityEngine;

namespace SilentOrchestra.World
{
    using SilentOrchestra.Shell;
    
    [RequireComponent(typeof(HexTile))]
    public class WorldTile : MonoBehaviour
    {
        [SerializeField] private WorldTileType type = WorldTileType.Plains;

        private HexTile _hexTile;
        private List<WorldTile> _neighbours = new();

        private HashSet<WorldTileType> _potentialTypes = new();
        private bool _hasCollapsed = false;

        private void Awake()
        {
            _hexTile = GetComponent<HexTile>();
        }

        public void Initialize()
        {
            if (_hexTile.TopRightTile != null) _neighbours.Add(_hexTile.TopRightTile.GetComponent<WorldTile>());
            if (_hexTile.RightTile != null) _neighbours.Add(_hexTile.RightTile.GetComponent<WorldTile>());
            if (_hexTile.BottomRightTile != null) _neighbours.Add(_hexTile.BottomRightTile.GetComponent<WorldTile>());
            if (_hexTile.BottomLeftTile != null) _neighbours.Add(_hexTile.BottomLeftTile.GetComponent<WorldTile>());
            if (_hexTile.LeftTile != null) _neighbours.Add(_hexTile.LeftTile.GetComponent<WorldTile>());
            if (_hexTile.TopLeftTile != null) _neighbours.Add(_hexTile.TopLeftTile.GetComponent<WorldTile>());

            Enum.GetValues(typeof(WorldTileType)).Cast<WorldTileType>().ToList().ForEach(enumType => _potentialTypes.Add(enumType));
        }

        public WorldTileType Type
        {
            get => type;
            set
            {
                type = value;
                _hexTile.MeshRenderer.material.color = GameSettings.WorldTileColors[type];
            }
        }

        public bool HasCollapsed => _hasCollapsed;
    }
}