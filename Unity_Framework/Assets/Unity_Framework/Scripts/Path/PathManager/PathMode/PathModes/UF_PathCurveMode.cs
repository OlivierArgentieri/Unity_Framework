using System;
using System.Collections.Generic;
using System.Linq;
using EditoolsUnity;
using Unity_Framework.Scripts.Import.Interface;
using Unity_Framework.Scripts.Path.PathManager.PathMode.PathModes.Curve;
using UnityEditor;
using UnityEngine;

namespace Unity_Framework.Scripts.Path.PathManager.PathMode.PathModes
{
    [Serializable]
    public class UF_PathCurveMode : UF_PathMode, IIsValid
    {

        #region f/p
        [SerializeField] UF_PathCurve Curve = new UF_PathCurve();

        private float startAtPercent = 0;
        
        private int selectedIndex = -1;
        
        public override List<Vector3> PathPoints => Curve.CurvePoints.ToList();
        public override Vector3 StartPercentPosition => Curve.StartPercentPosition;
        public override int GetStartPercentIndex => Curve.GetStartPercentIndex;
        public bool IsValid => Curve != null;
        #endregion
        
        
        
        public override void Run(GameObject _agent)
        {
            throw new NotImplementedException();
        }

        public override void Run(List<GameObject> _agent)
        {
            throw new NotImplementedException();
        }

        public override void RunAtPercent(GameObject _agent, float _percent)
        {
            throw new NotImplementedException();
        }

        public override void RunAtPercent(List<GameObject> _agents, float _percent)
        {
            throw new NotImplementedException();
        }

        #region UI methods

        public override void DrawSceneMode()
        {
             if (!IsValid || Curve.IsEmpty) return;
            Curve.SetCurve();

            
            Vector3 _lastAnchor = Curve.Anchor[Curve.Anchor.Count - 1];
            _lastAnchor = Handles.PositionHandle(_lastAnchor, Quaternion.identity);
            Curve.Anchor[Curve.Anchor.Count - 1] = _lastAnchor;

            for (int j = 0; j < Curve.Anchor.Count; j += 3)
            {
                Vector3 _handleA = Curve.Anchor[j];
                Vector3 _handleB = Curve.Anchor[j + 1];
                Vector3 _handleC = Curve.Anchor[j + 2];

                
                // markers
                Handles.DrawLine(_handleA, _handleA + Vector3.up * .5f);
                Handles.DrawLine(_handleB, _handleB + Vector3.up * .5f);

                float _sizeA = HandleUtility.GetHandleSize(_handleA);
                float _sizeB = HandleUtility.GetHandleSize(_handleB);

                // select Handle
                bool _pressA = Handles.Button(_handleA + Vector3.up * .05f, Quaternion.identity, .05f * _sizeA, .05f * _sizeA, Handles.DotHandleCap);
                bool _pressB = Handles.Button(_handleB + Vector3.up * .05f, Quaternion.identity, .05f * _sizeB, .05f * _sizeB, Handles.DotHandleCap);

                if (_pressA)
                    selectedIndex = j;
                else if (_pressB)
                    selectedIndex = j + 1;

                if (selectedIndex == j) // if select first point segment
                {
                    _handleA = Handles.PositionHandle(_handleA, Quaternion.identity);
                    if (GUI.changed)
                        Curve.SetCurve();
                }


                else if (selectedIndex == j + 1) // if select middle segment curve
                {
                    _handleB = Handles.PositionHandle(_handleB, Quaternion.identity);
                    if (GUI.changed)
                        Curve.SetCurve();
                }

                Curve.Anchor[j] = _handleA;
                Curve.Anchor[j + 1] = _handleB;
                
                // draw linked middle point
                EditoolsHandle.DrawDottedLine(_handleA, _handleB, .5f); 
                EditoolsHandle.DrawDottedLine(_handleB, _handleC, .5f);
            }

            // draw curve
            EditoolsHandle.SetColor(PathColor);
            Vector3[] _curve = Curve.CurvePoints;
            for (int j = 0; j < Curve.CurvePoints.Length; j++)
            {
                if (j < Curve.CurvePoints.Length - 1)
                    Handles.DrawLine(Curve.CurvePoints[j], Curve.CurvePoints[j + 1]);
            }

            EditoolsHandle.SetColor(Color.white);

            EditoolsHandle.DrawDottedLine(Curve.CurvePoints[Curve.GetStartPercentIndex], Curve.CurvePoints[Curve.GetStartPercentIndex] + Vector3.up, 1);
        }

        public override void DrawSettings()
        {
            if (!IsValid) return;
            EditoolsLayout.Space(3);
            
            EditoolsLayout.Horizontal(true);
            EditoolsBox.HelpBox($"Path ID : {Id}");
            EditoolsField.TextField("", ref Id);
            EditoolsLayout.Horizontal(false);
            
            
            EditoolsLayout.Horizontal(true);
            EditoolsBox.HelpBoxInfo("Curve Settings");
            EditoolsLayout.Vertical(true);
            EditoolsButton.ButtonWithConfirm("Reset Curve", Color.red, Curve.ResetCurve, "Reset Curve ?", $"Remove Curve", "Are your sure ?", _showCondition: !Curve.IsEmpty);
            EditoolsButton.Button("Add Segment", Color.green, Curve.AddSegment);
            EditoolsLayout.Vertical(false);
            EditoolsLayout.Horizontal(false);

            
            EditoolsLayout.Horizontal(true);
            EditoolsBox.HelpBox("Curve Color");
            EditoolsField.ColorField(PathColor, ref PathColor);
            EditoolsLayout.Horizontal(false);
          

            EditoolsLayout.Space(2);

            EditoolsField.IntSlider("Start at percent ", ref Curve.CurrentPercent, 0, 100);
            EditoolsField.IntSlider("Curve Definition", ref Curve.CurveDefinition, Curve.MinDefinition,
                Curve.MaxDefinition);
            
            EditoolsLayout.Space(2);
            
            DisplaySegmentSettings();
            
            if (GUI.changed)
            {
                Curve.SetCurve();
                SceneView.RepaintAll();
            }
            
        }
        
        private void DisplaySegmentSettings()
        {
            if (!IsValid || Curve.IsEmpty) return;
            EditoolsLayout.Foldout(ref Curve.DipslaySegments, "Curve Segments");

            if (!Curve.DipslaySegments) return;
            
            
            for (int i = 0; i < Curve.Anchor.Count; i+=3)
            {
                EditoolsLayout.Horizontal(true);
                EditoolsButton.ButtonWithConfirm("X", Color.red, Curve.RemoveSegment, i, $"Remove {i/3}", $"Remove {i/3}", "Are your sure ?");
                EditoolsBox.HelpBox($"Segment {i/3} / {(Curve.Anchor.Count-1)/3} ");
                EditoolsLayout.Horizontal(false);
            }
        }

        #endregion


    }
}