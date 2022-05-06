using System;
using System.Collections;
using System.Collections.Generic;
using Magthylius;
using UnityEditor;
using UnityEngine;

namespace SilentOrchestra.Shell.Editors
{
    [CustomEditor(typeof(SettingsDatabase))]
    public class SettingsDatabaseEditor : CustomEditorBase
    {
        private SettingsDatabase _database;
        private void OnEnable()
        {
            _database = (SettingsDatabase)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            EditorGUILayout.Separator();
            Space(10f);
            
            float[] ageMult = new float[]
            {
                MathEx.Lerp(_database.agentAgeRange, _database.agentAgeCurve.Evaluate(0f)),
                MathEx.Lerp(_database.agentAgeRange, _database.agentAgeCurve.Evaluate(0.25f)),
                MathEx.Lerp(_database.agentAgeRange, _database.agentAgeCurve.Evaluate(0.5f)),
                MathEx.Lerp(_database.agentAgeRange, _database.agentAgeCurve.Evaluate(0.75f)),
                MathEx.Lerp(_database.agentAgeRange, _database.agentAgeCurve.Evaluate(1f)),
            };
            EditorGUILayout.LabelField($"Age range at {0f}: {ageMult[0]} ");
            EditorGUILayout.LabelField($"Age range at {0.25f}: {ageMult[1]} ");
            EditorGUILayout.LabelField($"Age range at {0.5f}: {ageMult[2]} ");
            EditorGUILayout.LabelField($"Age range at {0.75f}: {ageMult[3]} ");
            EditorGUILayout.LabelField($"Age range at {1f}: {ageMult[4]} ");
        }
    }
}
