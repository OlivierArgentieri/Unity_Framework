using System;
using System.Collections.Generic;
using UnityEngine;

namespace EditoolsUnity
{
    [Serializable]
    public class UF_PathAgent
    {
        #region f/p
        public int MaxSpeedMove = 100;
        public int MinSpeedMove = 1;
        public int SpeedMove = 1;

        public int MaxSpeedRotation = 500;
        public int MinSpeedRotation = 1;
        public int SpeedRotation = 1;

        public bool Show = true;
        private List<Vector3> pathPoints = null;

        public string PathId; // todo select
        public int PathIndex = 0;
        public GameObject AgentToMove = null;
        public int PathLength => pathPoints?.Count ?? 0 ;
        
        //public int CurveDefinition => curves[CurveID]?.CurveDefinition ?? 0;
        //public int CurrentPercent = 0;
        // private float StartPosition => ((float) CurrentPercent / 100) * CurveDefinition * CurveLength;
    
    
        #endregion
    }
}