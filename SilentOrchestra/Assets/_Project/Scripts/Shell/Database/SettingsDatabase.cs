using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace SilentOrchestra.Shell
{
    [CreateAssetMenu(fileName = "New SettingsDatabase", menuName = "SilentOrchestra/Database/Settings", order = 99)]
    public class SettingsDatabase : ScriptableObject
    {
        [FormerlySerializedAs("ageCurve")] public AnimationCurve agentAgeCurve;
        public Vector2 agentAgeRange;
    }
}
