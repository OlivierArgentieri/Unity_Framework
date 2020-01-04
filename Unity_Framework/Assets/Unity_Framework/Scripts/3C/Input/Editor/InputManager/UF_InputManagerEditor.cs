using UnityEditor;
using UnityEngine;

public class UF_InputManagerEditor
{
    #region custom methods

    [MenuItem("UF/Input/InputManager")]
    public static void Init()
    {
        UF_InputManager[] _inputManagers = Object.FindObjectsOfType<UF_InputManager>();

        if (_inputManagers.Length > 0) return;
        
        GameObject _inputManager = new GameObject("InputManager", typeof(UF_InputManager));
        Selection.activeGameObject = _inputManager;
    }
    

    #endregion
}