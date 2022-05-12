using System.Collections;
using System.Collections.Generic;
using Magthylius;
using UnityEditor;
using UnityEngine;

namespace SilentOrchestra.Shell.Editors
{
    [CustomEditor(typeof(OrganizationDatabase))]
    public class OrganizationDatabaseEditor : CustomEditorBase
    {
        private OrganizationDatabase _database;

        private string _generatedName = string.Empty;
        private string _generatedAbbrev = string.Empty;
        private void OnEnable()
        {
            _database = (OrganizationDatabase)target;
            _generatedName = _database.RandomAgencyName;
            _generatedAbbrev = _database.GenerateAbbreviation(_generatedName);
        }
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            EditorGUILayout.LabelField($"Generated Name: {_generatedName}");
            EditorGUILayout.LabelField($"Generated Abbrev: {_generatedAbbrev}");
            if (GUILayout.Button("Generate random name"))
            {
                _generatedName = _database.RandomAgencyName;
                _generatedAbbrev = _database.GenerateAbbreviation(_generatedName);
            }
        }
    }
}
