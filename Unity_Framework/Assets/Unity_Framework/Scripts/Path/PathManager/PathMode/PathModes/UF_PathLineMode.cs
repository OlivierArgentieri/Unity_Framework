using System;
using System.Collections.Generic;
using EditoolsUnity;
using Unity_Framework.Scripts.Path.PathManager.Path;
using Unity_Framework.Scripts.Path.PathManager.PathMode.PathModes.LinePath;
using UnityEngine;

namespace Unity_Framework.Scripts.Path.PathManager.PathMode.PathModes
{
    [Serializable]
    public class UF_PathLineMode : UF_PathMode
    {
        #region f/p
        public UF_PathLine Path = new UF_PathLine();
        #endregion

        
        
        public override void Run(GameObject _agent)
        {
            
        }

        public override void Run(List<GameObject> _agent)
        {
            
        }

        public override void RunAtPercent(GameObject _agent, float _percent)
        {
            
        }

        public override void RunAtPercent(List<GameObject> _agents, float _percent)
        {
            
        }

        
        #region UI Methods
        public override void DrawSceneMode()
        {
            ShowAllPathScene();
        }

        public override void DrawSettings()
        {
            EditoolsButton.Button("+", Color.green, Path.AddPoint);
          //  EditoolsButton.Button("Editable", Path.IsEditable ? Color.green : Color.grey, SetEditable, Path);

          // New Line
            EditoolsLayout.Horizontal(true);
            EditoolsField.TextField(Path.Id, ref Path.Id);
            EditoolsField.ColorField(Path.PathColor, ref Path.PathColor);


            EditoolsLayout.Horizontal(false);

            ShowPathPointUi(Path);
        }
        
        private void ShowPathPointUi(UF_PathLine _path)
        {
            if (_path.PathPoints.Count == 0) return;
            EditoolsLayout.Foldout(ref _path.ShowPoint, $"Show/Hide points {_path.Id}", true);
            if (_path.ShowPoint)
            {
                for (int i = 0; i < _path.PathPoints.Count; i++)
                {
                    EditoolsLayout.Horizontal(true);

                    _path.PathPoints[i] = EditoolsField.Vector3Field($"Path Point [{i + 1}]", _path.PathPoints[i]);
                    EditoolsButton.ButtonWithConfirm("-", Color.magenta, _path.RemovePoint, i,
                        $"Suppress Point {i + 1} at {_path.PathPoints[i]} ? ", "Are your sure ?");

                    EditoolsLayout.Horizontal(false);
                }
            }

            EditoolsLayout.Space(1);

            if (_path.PathPoints.Count > 0)
                EditoolsButton.ButtonWithConfirm("Remove All Points", Color.red, _path.ClearPoints, $"Suppress All Points ? ",
                    "Are your sure ?");
        }

        private void ShowAllPathScene()
        {
            EditoolsHandle.SetColor(Path.PathColor);

            for (int j = 0; j < Path.PathPoints.Count; j++)
            {
                Path.PathPoints[j] = EditoolsHandle.PositionHandle(Path.PathPoints[j], Quaternion.identity);
                EditoolsHandle.Label(Path.PathPoints[j] + Vector3.up * 5, $"Point {j + 1}");
                EditoolsHandle.SetColor(Color.white);
                EditoolsHandle.DrawDottedLine(Path.PathPoints[j] + Vector3.up * 5, Path.PathPoints[j], .5f);
                EditoolsHandle.SetColor(Path.PathColor);
                EditoolsHandle.DrawSolidDisc(Path.PathPoints[j], Vector3.up, 0.1f);
                if (j < Path.PathPoints.Count - 1)
                    EditoolsHandle.DrawLine(Path.PathPoints[j], Path.PathPoints[j + 1]);
              
                
            }
        }
        /*void SetEditable(UF_Path _path)
        {
            for (int i = 0; i < .Count; i++)
            {
                eTarget.Paths[i].IsEditable = false;
            }

            _path.IsEditable = true;
        }*/

        #endregion
    }
}