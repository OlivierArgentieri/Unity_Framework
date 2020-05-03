using System.Collections.Generic;
using Unity_Framework.Scripts.Path.PathManager.Path;
using Unity_Framework.Scripts.Path.PathManager.PathMode;
using UnityEngine;

namespace Unity_Framework.Scripts.Path.PathManager
{
    public class UF_PathManager : MonoBehaviour
    {
        #region f/p
        // todo refletcions
        public List<UF_Path> Paths = new List<UF_Path>();

        public bool IsEmpty => Paths != null && Paths.Count <1;
        #endregion

        
        #region cutstom methods
        
        public void AddPath() => Paths.Add(new UF_Path());
        public void Remove(int _index) => Paths.RemoveAt(_index);
        public void Clear() => Paths.Clear();

        #endregion
    }
}