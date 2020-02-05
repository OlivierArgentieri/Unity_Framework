using UnityEditor;
using UnityEngine;

namespace uf
{
    public class UF_CameraManagerEditor
    {
        #region custom methods

        [MenuItem("UF/Camera/CameraManager")]
        public static void Init()
        {
            UF_CameraManager[] _cameraManagers = Object.FindObjectsOfType<UF_CameraManager>();

            if (_cameraManagers.Length > 0) return;

            GameObject _cameraManager = new GameObject("CameraManager", typeof(UF_CameraManager));
            Selection.activeObject = _cameraManager;

            // create InputManager 
            UF_InputManagerEditor.Init();
        }

        #endregion
    }
}