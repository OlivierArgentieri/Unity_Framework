using System;
using System.Collections.Generic;
using System.Linq;
using EditoolsUnity;
using Unity_Framework.Scripts.Spawner.SpawnerManager.SpawnMode.SpawnModes.BezierMode;
using UnityEditor;
using UnityEngine;

namespace Unity_Framework.Scripts.Spawner.SpawnerManager.SpawnMode.SpawnModes
{
    [Serializable]
    public class UF_BezierMode : UF_SpawnMode
    {
        #region f/p

        [SerializeField]
        UF_Curve Curve = new UF_Curve();

        private int selectedIndex = -1;
        #endregion


        #region custom methods
        private void AddCurve()
        {
            Curve.SetCurve();
        }
        
        
        public override void Spawn(GameObject _agent)
        {
            for (int i = 0; i < Curve.Anchor.Length; i++)
            {
                GameObject _go = GameObject.Instantiate(_agent, Curve.Anchor[i], Quaternion.identity);
            }
        }

        public override void Spawn(List<GameObject> _agent)
        {
            throw new System.NotImplementedException();
        }

        public override void SpawnWithDestroyDelay(GameObject _agent)
        {
            throw new System.NotImplementedException();
        }

        public override void SpawnWithDestroyDelay(List<GameObject> _agents)
        {
            throw new System.NotImplementedException();
        }


        #if UNITY_EDITOR
        public override void DrawSceneMode()
        {
            
            Vector3 _lastAnchor = Curve.Anchor[Curve.Anchor.Length - 1];
        _lastAnchor = Handles.PositionHandle(_lastAnchor, Quaternion.identity);
        Curve.Anchor[Curve.Anchor.Length - 1] = _lastAnchor;
        
        for (int j = 0; j < Curve.Anchor.Length; j+=3)
        {
            Vector3 _handleA = Curve.Anchor[j];
            Vector3 _handleB = Curve.Anchor[j+1];
            Vector3 _handleC = Curve.Anchor[j+2];

            Handles.DrawLine(_handleA, _handleA + Vector3.up * .5f);
            Handles.DrawLine(_handleB, _handleB + Vector3.up * .5f);
            
            float _sizeA = HandleUtility.GetHandleSize(_handleA);
            float _sizeB = HandleUtility.GetHandleSize(_handleB);

            bool _pressA = Handles.Button(_handleA + Vector3.up * .05f, Quaternion.identity, .05f * _sizeA, .05f * _sizeA, Handles.DotHandleCap);
            bool _pressB = Handles.Button(_handleB + Vector3.up * .05f, Quaternion.identity, .05f * _sizeB, .05f * _sizeB, Handles.DotHandleCap);

            if (_pressA)
                selectedIndex = j;
            else if (_pressB)
                selectedIndex = j + 1;

            if (selectedIndex == j)
            {
                _handleA = Handles.PositionHandle(_handleA, Quaternion.identity);
                if(GUI.changed)
                    Curve.SetCurve();
            }
            
            
            else if (selectedIndex == j + 1)
            {
                _handleB = Handles.PositionHandle(_handleB, Quaternion.identity);
                if(GUI.changed)
                    Curve.SetCurve();
            }

            Curve.Anchor[j] = _handleA;
            Curve.Anchor[j+1] = _handleB;
            EditoolsHandle.DrawDottedLine(_handleA, _handleB, 1);
            EditoolsHandle.DrawDottedLine(_handleB, _handleC, 1);
        }

        Vector3[] _curve = Curve.Curve;
        for (int j = 0; j < Curve.Curve.Length ; j++)
        {
            if(j< Curve.Curve.Length-1)
                Handles.DrawLine(Curve.Curve[j], Curve.Curve[j+1]);
        }
        
        Handles.color = Color.white;
        //EditoolsHandle.DrawDottedLine(Curve[_c.GetStartAtPercent], _c.Curve[_c.GetStartAtPercent] + Vector3.up, 1);

        
            
            for (int i = 0; i < Curve.Anchor.Length; i++)
            {
                if (i >= Curve.Anchor.Length - 1) continue;
                
                Handles.DrawLine(Curve.Anchor[i], Curve.Anchor[i+1]);
            }
        }

        public override void DrawSettings()
        {

            EditoolsLayout.Horizontal(true);
            EditoolsLayout.Vertical(true);
            //EditoolsButton.ButtonWithConfirm("-", Color.red, RemoveCurve, i, $"Remove Curve {i}", "Are your sure ?");
            EditoolsButton.Button("Add Segment", Color.green, Curve.AddSegment);
            EditoolsLayout.Vertical(false);
            EditoolsLayout.Horizontal(false);
            
            
            EditoolsField.IntSlider("Curve Definition", ref Curve.CurveDefinition, Curve.MinDefinition, Curve.MaxDefinition);
            //EditoolsField.IntSlider("Start at percent ", ref Curve.CurrentPercent, 0, 100);
            if (GUI.changed)
            {
                Curve.SetCurve();
                SceneView.RepaintAll();
            }
        }

        public override void DrawLinkToSpawner(Vector3 _position)
        {
            if (Curve.Anchor.Length < 1) return;
            Handles.DrawDottedLine( Curve.Anchor[0], _position, 0.5f);
           
        }
        #endif

        #endregion
    }
}