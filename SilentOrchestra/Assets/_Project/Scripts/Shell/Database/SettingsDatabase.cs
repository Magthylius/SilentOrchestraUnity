using System.Collections;
using System.Collections.Generic;
using Magthylius;
using UnityEngine;
using UnityEngine.Serialization;

namespace SilentOrchestra.Shell
{
    [CreateAssetMenu(fileName = "New SettingsDatabase", menuName = "SilentOrchestra/Database/Settings", order = 99)]
    public class SettingsDatabase : ScriptableObject
    {
        [Header("Game")] 
        [Min(1)] public int agentsPerAgency = 10;
        [Min(1)] public int agenciesPerGovernment = 1;
        [Min(1)] public int governmentsPerTheater = 4;
        
        [Header("Agents")]
        public AnimationCurve agentAgeCurve;
        public Vector2 agentAgeRange;

        public void ApplySettings()
        {
            GameSettings.AgentsPerAgency = agentsPerAgency;
            GameSettings.AgenciesPerGovernment = agenciesPerGovernment;
            GameSettings.GovernmentsPerTheater = governmentsPerTheater;
        }

        public float GetAge(float normalizedValue) =>
            MathEx.Lerp(agentAgeRange, agentAgeCurve.Evaluate(normalizedValue));

        public float RandomAge => GetAge(Random.value);
    }
}
