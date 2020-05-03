using System;
using System.Reflection;
using EditoolsUnity;
using Unity_Framework.Scripts.Path.PathManager;
using Unity_Framework.Scripts.Path.PathManager.Path;
using Unity_Framework.Scripts.Path.PathManager.PathMode;
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
            DrawPathOnScene();
        }
        
        #endregion


        #region custom methods

        private void GlobalSettings()
        {
            EditoolsBox.HelpBox($"PATH TOOL V{version}");
            AllPathUI();
            EditoolsButton.Button("Add Path", Color.white, eTarget.AddPath);
            
            EditoolsButton.ButtonWithConfirm("Remove all Path", Color.red, eTarget.Clear, "Clear All Paths ?", "Are you sure ?", "Yes", "No", !eTarget.IsEmpty );
        }
        
        private void AllPathUI()
        {
            if (!eTarget) return;
            
            for (int i = 0; i < eTarget.Paths.Count; i++)
            {
                UF_Path _p = eTarget.Paths[i];
                EditoolsLayout.Foldout(ref _p.ShowPath, $"Show/Hide {_p.Id}", true);

                if (!_p.ShowPath) continue;

                EditoolsBox.HelpBox($"[{i}] {_p.Id} -> {_p.PathPoints.Count} total points");

                
                EditoolsLayout.Horizontal(true);

                EditoolsButton.ButtonWithConfirm("Remove This Path", Color.red, eTarget.RemovePath, i, $"Suppress Path {i + 1} ? ","Are your sure ?");

                UF_PathModeSelector _mode = _p.PathMode;
                _mode.Type = (UF_PathType) EditoolsField.EnumPopup("Mode Type", _mode.Type);
                EditoolsLayout.Horizontal(false);

                _mode.Mode.DrawSettings();
                
             
                EditoolsLayout.Space(5);
            }
        }


        private void DrawPathOnScene()
        {
            for (int i = 0; i < eTarget.Paths.Count; i++)
            {
                UF_Path _point = eTarget.Paths[i];
                
                
                _point.PathMode.Mode.DrawSceneMode();
            }
        }
        

        #endregion
    }
}