using Magthylius;
using UnityEditor;
using UnityEngine;

namespace SilentOrchestra.World.Editors
{
    [CustomEditor(typeof(WorldGenerator))]
    public class WorldGeneratorEditor : CustomEditorBase
    {
        private void OnSceneGUI()
        {
            var tiles = (target as WorldGenerator)?.Tiles;
            if (tiles != null)
            {
                foreach (var tileKvp in tiles)
                {
                    var coords = tileKvp.Key;
                    var tile = tileKvp.Value;
                    if (tile.isRandom) Handles.Label(tile.transform.position + new Vector3(0, 1f, 0), coords.ToString());
                }
            }
        }
    }
}
