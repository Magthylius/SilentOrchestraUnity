using System;
using System.Collections;
using System.Collections.Generic;
using Magthylius;
using UnityEditor;
using UnityEngine;

namespace SilentOrchestra.World.Editors
{
    [CustomEditor(typeof(WorldTile))]
    public class WorldTileEditor : CustomEditorBase
    {
        private void OnSceneGUI()
        {
            var tile = target as WorldTile;

            if (tile != null)
            {
                var offset = new Vector3(0f, 1f, 0f);
                Handles.Label(tile.transform.position + offset, tile.Coordinates.ToString());
                if (tile.TopRight) Handles.Label(tile.TopRight.transform.position + offset, "Top Right");
                if (tile.Right) Handles.Label(tile.Right.transform.position + offset, "Right");
                if (tile.BotRight) Handles.Label(tile.BotRight.transform.position + offset, "Bot Right");
                if (tile.BotLeft) Handles.Label(tile.BotLeft.transform.position + offset, "Bot Left");
                if (tile.Left) Handles.Label(tile.Left.transform.position + offset, "Left");
                if (tile.TopLeft) Handles.Label(tile.TopLeft.transform.position + offset, "Top Left");
            }
        }
    }
}
