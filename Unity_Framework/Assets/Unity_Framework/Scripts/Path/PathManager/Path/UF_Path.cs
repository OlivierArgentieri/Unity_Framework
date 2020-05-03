using System;
using System.Collections.Generic;
using Unity_Framework.Scripts.Path.PathManager.PathMode;
using UnityEngine;

namespace Unity_Framework.Scripts.Path.PathManager.Path
{
    [Serializable]
    public class UF_Path
    {
        #region f/p
        public string Id = "Path 1";

        public bool ShowPath = true;
      
        public List<Vector3> PathPoints = new List<Vector3>();
        
        public UF_PathModeSelector PathMode = new UF_PathModeSelector();

        
        public bool IsMonoAgent = false;
        public GameObject MonoAgent = null;
        public List<GameObject> Agents = new List<GameObject>();

        public float StartAtPercent = 0;
        #endregion
        

        #region custom methods 
        public void AddAgent() => Agents.Add(null);
        public void RemoveAgent(int _index) => Agents.RemoveAt(_index);
        public void RemoveAgent() => MonoAgent = null;
        public void ClearAgents() => Agents.Clear();
        
        #endregion
    }
}