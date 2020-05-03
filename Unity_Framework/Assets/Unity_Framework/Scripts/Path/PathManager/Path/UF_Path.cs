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
       
        
        public UF_PathModeSelector PathMode = new UF_PathModeSelector();
        
        public bool IsMonoAgent = false;
        public GameObject MonoAgent = null;
        public List<GameObject> Agents = new List<GameObject>();

        public float StartAtPercent = 0;
        #endregion
        

        
    }
}