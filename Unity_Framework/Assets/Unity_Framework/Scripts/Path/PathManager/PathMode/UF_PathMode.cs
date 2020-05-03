using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity_Framework.Scripts.Path.PathManager.PathMode
{
    [Serializable]
    public abstract class UF_PathMode
    {
        #region f/p

        public string Id = "Path 1";

        public bool ShowPath = true;
        public bool ShowPoint = true;
        
        public Color PathColor = Color.white;
        
        public abstract List<Vector3> PathPoints { get; }
        public Vector3 Position = Vector3.zero;
        
        #endregion


        #region custom methods
        public abstract void Run(GameObject _agent);
        public abstract void Run(List<GameObject> _agent);
        public abstract void RunAtPercent(GameObject _agent, float _percent);
        public abstract void RunAtPercent(List<GameObject> _agents, float _percent);

        #if UNITY_EDITOR
        public abstract void DrawSceneMode();
        public abstract void DrawSettings();
        #endif

        #endregion
    }
}