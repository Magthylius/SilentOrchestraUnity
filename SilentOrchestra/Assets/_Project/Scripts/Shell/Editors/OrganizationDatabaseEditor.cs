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

        private string _testGen = string.Empty;
        private void OnEnable()
        {
            _database = (OrganizationDatabase)target;
        }
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            EditorGUILayout.LabelField($"Test Gen: {_testGen}");
            if (GUILayout.Button("Generate random name")) _testGen = _database.RandomAgencyName;
        }
    }
}
