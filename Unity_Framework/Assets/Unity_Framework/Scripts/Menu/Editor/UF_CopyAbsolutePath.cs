using System;
using UnityEditor;
using UnityEngine;

namespace Unity_Framework.Scripts.Menu.Editor
{
    public static class UF_CopyAbsolutePath
    {
        [MenuItem("Assets/Copy Absolute Path", priority = 1)]
        static void CopyAbsolutePath()
        {
            var _absolutePath = System.IO.Path.Combine(Application.dataPath, "../", AssetDatabase.GetAssetPath(Selection.activeObject));
            GUIUtility.systemCopyBuffer = new Uri(_absolutePath).AbsolutePath;
        }
        
        [MenuItem("Assets/Copy Relative Path", priority = 0)]
        static void CopyRelativePath()
        {
            var _relativePath = AssetDatabase.GetAssetPath(Selection.activeObject);
            GUIUtility.systemCopyBuffer = _relativePath;
        }
    }
}