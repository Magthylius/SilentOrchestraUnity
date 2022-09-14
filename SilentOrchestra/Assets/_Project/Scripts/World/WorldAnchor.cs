using System.Collections;
using System.Collections.Generic;
using Magthylius;
using UnityEngine;

namespace SilentOrchestra.World
{
    public class WorldAnchor : HardSingleton<WorldAnchor>
    {
        [SerializeField] private WorldGenerator generator;

        public static WorldGenerator Generator => Instance.generator;
    }
}
