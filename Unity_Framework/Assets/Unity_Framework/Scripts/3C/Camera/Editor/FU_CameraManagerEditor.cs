
using UnityEditor;
using UnityEngine;

public class FU_CameraManagerEditor
{
    #region custom methods
    [MenuItem("UF/Camera/CameraManager")]
    public static void Init()
    {
        FU_CameraManager[] _cameraManagers = Object.FindObjectsOfType<FU_CameraManager>();

        if (_cameraManagers.Length > 0) return;
        
        GameObject _cameraManager = new GameObject("CameraManager", typeof(FU_CameraManager));
        Selection.activeObject = _cameraManager;
    }
    #endregion

}