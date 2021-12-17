using System.IO;
using EditoolsUnity;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Unity_Framework.Scripts.Menu.Editor
{
    public class UF_Scenes : EditorWindow
    {
        [MenuItem("UF/List Scenes")]
        static void Init()
        {
            UF_Scenes window = (UF_Scenes) EditorWindow.GetWindow(typeof(UF_Scenes));
            window.titleContent = new GUIContent("List of Scenes");
        }
        
        private void OnGUI() 
        {
            var _scenes = Directory.GetFiles(Application.dataPath, "*.unity", SearchOption.AllDirectories);
            foreach (var _scene in _scenes)
            {
                string _name = System.IO.Path.GetFileNameWithoutExtension(_scene);
                EditoolsButton.Button(_name, Color.grey, () => { EditorSceneManager.OpenScene(_scene); });
            }

        }
        
    }
}