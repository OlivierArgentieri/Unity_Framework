using System.Collections.Generic;
using Unity_Framework.Scripts.Path.PathManager.PathMode.PathModes.LinePath;
using UnityEngine;

namespace Unity_Framework.Scripts.Path.PathManager.PathMode.PathModes
{
    public class UF_PathLineMode : UF_PathMode
    {
        #region f/p

        public List<UF_PathLine> Paths = new List<UF_PathLine>();

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
            
        }

        public override void DrawSettings()
        {
            
        }
        #endregion
    }
}