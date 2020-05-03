using System;
using System.Reflection;
using EditoolsUnity;
using Unity_Framework.Scripts.Path.PathManager;
using UnityEditor;
using UnityEngine;

namespace Unity_Framework.Scripts.Path.Editor.PathManagerEditor
{
    [CustomEditor(typeof(UF_PathManager))]
    public class UF_PathManagerEditor : EditorCustom<UF_PathManager>
    {
        #region const
        private static readonly Version version = new Version(1, 2, 0);

        private const BindingFlags reflectionFlags = BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
        #endregion


        #region UI Methods
        
        protected override void OnEnable()
        {
            base.OnEnable();
            Tools.current = Tool.None;
        }

        public override void OnInspectorGUI()
        {
            GlobalSettings();
            
         
            SceneView.RepaintAll();
        }

        private void OnSceneGUI()
        {
          
        }
        
        #endregion


        #region custom methods

        private void GlobalSettings()
        {
            EditoolsBox.HelpBox($"PATH TOOL V{version}");
            AllPathUI();
            EditoolsButton.Button("Add Path", Color.white, eTarget.AddPath);
            
            EditoolsButton.ButtonWithConfirm("Remove all Path", Color.red, eTarget.Clear, "Clear All Paths ?", "Are you sure ?", "Yes", "No", eTarget.IsEmpty );
        }
        
        private void AllPathUI()
        {
            if (!eTarget) return;
            
        }

        #endregion
    }
}