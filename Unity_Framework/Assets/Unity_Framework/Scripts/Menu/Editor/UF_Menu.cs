
using UnityEditor;
using UnityEngine;

public class UF_Menu
{
    [MenuItem("UF/Save On Play ([WIP] Doesn't work)")]
    public static void SaveDataOnPlay()
    {
        foreach (var o in Selection.objects)
        {
            EditorUtility.SetDirty(o);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}
