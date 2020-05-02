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

        [SerializeField] UF_Curve Curve = new UF_Curve();

        private int selectedIndex = -1;

        #endregion


        #region custom methods

        private void AddCurve()
        {
            Curve.SetCurve();
        }


        public override void Spawn(GameObject _agent)
        {
            int _step = Curve.Curve.Length / Curve.CurveDefinition;

            for (int i = 0; i < Curve.Curve.Length; i += _step)
                GameObject.Instantiate(_agent, Curve.Curve[i], Quaternion.identity);
            
        }

        public override void Spawn(List<GameObject> _agents)
        {
            int _step = Curve.Curve.Length / Curve.CurveDefinition;

            for (int i = 0; i < Curve.Curve.Length; i += _step)
            {
                int _randomIndex = UnityEngine.Random.Range(0, _agents.Count);
                if (!_agents[_randomIndex]) continue;
                GameObject _go = GameObject.Instantiate(_agents[_randomIndex], Curve.Curve[i], Quaternion.identity);
            }
        }

        public override void SpawnWithDestroyDelay(GameObject _agent)
        {
            int _step = Curve.Curve.Length / Curve.CurveDefinition;

            for (int i = 0; i < Curve.Curve.Length; i += _step)
            {
                GameObject _go = GameObject.Instantiate(_agent, Curve.Curve[i], Quaternion.identity);
                GameObject.Destroy(_go, AutoDestroyDelay);
            }
        }

        public override void SpawnWithDestroyDelay(List<GameObject> _agents)
        {
            int _step = Curve.Curve.Length / Curve.CurveDefinition;

            for (int i = 0; i < Curve.Curve.Length; i += _step)
            {
                int _randomIndex = UnityEngine.Random.Range(0, _agents.Count);
                if (!_agents[_randomIndex]) continue;
                GameObject _go = GameObject.Instantiate(_agents[_randomIndex], Curve.Curve[i], Quaternion.identity);
                GameObject.Destroy(_go, AutoDestroyDelay);
            }
        }


#if UNITY_EDITOR
        public override void DrawSceneMode()
        {
            Curve.SetCurve();

            Vector3 _lastAnchor = Curve.Anchor[Curve.Anchor.Length - 1];
            _lastAnchor = Handles.PositionHandle(_lastAnchor, Quaternion.identity);
            Curve.Anchor[Curve.Anchor.Length - 1] = _lastAnchor;

            for (int j = 0; j < Curve.Anchor.Length; j += 3)
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
            EditoolsHandle.SetColor(Curve.CurveColor);
            Vector3[] _curve = Curve.Curve;
            for (int j = 0; j < Curve.Curve.Length; j++)
            {
                if (j < Curve.Curve.Length - 1)
                    Handles.DrawLine(Curve.Curve[j], Curve.Curve[j + 1]);
            }

            EditoolsHandle.SetColor(Color.white);

            //EditoolsHandle.DrawDottedLine(Curve[_c.GetStartAtPercent], _c.Curve[_c.GetStartAtPercent] + Vector3.up, 1);

        }

        public override void DrawSettings()
        {
            EditoolsLayout.Space(3);
            EditoolsLayout.Horizontal(true);
            EditoolsBox.HelpBoxInfo("Curve Settings"); 
            
            EditoolsLayout.Vertical(true);
            EditoolsButton.ButtonWithConfirm("Reset Curve", Color.red, Curve.ResetCurve, "Reset Curve ?", $"Remove Curve", "Are your sure ?");
            EditoolsButton.Button("Add Segment", Color.green, Curve.AddSegment);
            EditoolsLayout.Vertical(false);
            EditoolsLayout.Horizontal(false);

            
            EditoolsLayout.Horizontal(true);
            EditoolsBox.HelpBox("Curve Color");
            EditoolsField.ColorField(Curve.CurveColor, ref Curve.CurveColor);
            EditoolsLayout.Horizontal(false);


            EditoolsField.IntSlider("Curve Definition", ref Curve.CurveDefinition, Curve.MinDefinition,
                Curve.MaxDefinition);

            if (GUI.changed)
            {
                Curve.SetCurve();
                SceneView.RepaintAll();
            }
            
            EditoolsField.Toggle("Auto Destroy Agents ?", ref AutoDestroyAgent);
            if (AutoDestroyAgent)
                AutoDestroyDelay = EditorGUILayout.Slider("Auto Destroy Delay", AutoDestroyDelay, 0, 15);

        }

        public override void DrawLinkToSpawner(Vector3 _position)
        {
            if (Curve.Anchor.Length < 1) return;
            Handles.DrawDottedLine(Curve.Anchor[0], _position, 0.5f);
        }
#endif

        #endregion
    }
}