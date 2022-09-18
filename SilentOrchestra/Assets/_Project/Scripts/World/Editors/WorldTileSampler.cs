using System;
using System.Collections;
using System.Collections.Generic;
using Magthylius.Components;
using NaughtyAttributes;
using UnityEngine;

namespace SilentOrchestra.World.Editors
{
    public class WorldTileSampler : WorldTile
    {
        [Header("World Tile Sampler")]
        [SerializeField] private HexTileSettings settings;

        [Button("Refresh Hex Settings")]
        private void OverrideHexSettings()
        {
            Hex.RebuildCaches();
            Hex.ChangeSettings(settings);
            Hex.RenderShape();
        }
        
        private new HexTile Hex => GetComponent<HexTile>();
    }
}
