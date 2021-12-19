using System;
using UnityEditor;
using UnityEngine;

namespace Unity_Framework.Scripts.Menu.Editor
{
    public static class UF_CopyAbsolutePath
    {
        [MenuItem("Assets/Copy Path/Copy Absolute Path", priority = 0)]
        static void CopyAbsolutePath()
        {
            var _relativePath = AssetDatabase.GetAssetPath(Selection.activeObject);
            GUIUtility.systemCopyBuffer = System.IO.Path.GetFullPath(_relativePath); //new Uri(_absolutePath).AbsolutePath);
        }
        
        [MenuItem("Assets/Copy Path/Copy Relative Path", priority = 0)]
        static void CopyAssetPath()
        {
            var _assetPath = AssetDatabase.GetAssetPath(Selection.activeObject);
            GUIUtility.systemCopyBuffer = _assetPath;
        }
        
        [MenuItem("Assets/Copy Path/Copy .meta file Path", priority = 0)]
        static void CopyMetaFilePath()
        {
            var _assetPath = AssetDatabase.GetAssetPath(Selection.activeObject);
            var _metaPath = AssetDatabase.GetTextMetaFilePathFromAssetPath(_assetPath);
            GUIUtility.systemCopyBuffer = System.IO.Path.GetFullPath(_metaPath);
        }
    }
}