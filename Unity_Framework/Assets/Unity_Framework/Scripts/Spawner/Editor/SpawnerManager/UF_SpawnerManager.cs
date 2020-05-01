
using Unity_Framework.Scripts._3C.Input.Editor.InputManager;
using Unity_Framework.Scripts.Spawner.SpawnerManager;
using UnityEditor;
using UnityEngine;

namespace Unity_Framework.Scripts.Spawner.Editor.SpawnerManager
{
    
    public class UF_SpawnerManagerEditor
    {
        #region custom methods
        [MenuItem("UF/SpawnerTool/SpawnerManager")]
        public static void Init()
        {
            UF_SpawnerManager[] _spawnerManagers = Object.FindObjectsOfType<UF_SpawnerManager>();

            if (_spawnerManagers.Length > 0) return;
        
            GameObject _spawnerManager = new GameObject("SpawnerManager", typeof(UF_SpawnerManager));
            
        }
        #endregion

    }
}