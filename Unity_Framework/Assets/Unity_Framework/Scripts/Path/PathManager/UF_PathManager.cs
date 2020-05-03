using System.Collections.Generic;
using EditoolsUnity;
using Unity_Framework.Scripts.Path.PathManager.Path;
using UnityEngine;

namespace Unity_Framework.Scripts.Path.PathManager
{
    public class UF_PathManager : MonoBehaviour
    {
        #region f/p
        // todo refletcions
        public List<UF_Path> Paths = new List<UF_Path>();
        public List<UF_PathAgent> Agents = new List<UF_PathAgent>();

        public bool IsEmpty => Paths != null && Paths.Count <1;
        #endregion

        
        #region cutstom methods
        
        public void AddPath() => Paths.Add(new UF_Path());
        public void RemovePath(int _index) => Paths.RemoveAt(_index);
        public void ClearPath() => Paths.Clear();
        
        public void AddAgent() => Agents.Add(null);
        public void RemoveAgent(int _index) => Agents.RemoveAt(_index);
        public void ClearAgents() => Agents.Clear();
        
        #endregion
    }
}