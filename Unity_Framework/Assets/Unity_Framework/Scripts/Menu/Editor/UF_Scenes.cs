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
            UF_Scenes _window = (UF_Scenes) GetWindow(typeof(UF_Scenes));
            _window.titleContent = new GUIContent("List of Scenes");
        }
        
        private void OnGUI() 
        {
            if (Application.isPlaying)
            {
                 EditoolsBox.HelpBoxWarning("Only Available in editor mode");
                 return;
            }
            
            var _scenes = Directory.GetFiles(Application.dataPath, "*.unity", SearchOption.AllDirectories);
            foreach (var _scene in _scenes)
            {
                string _name = System.IO.Path.GetFileNameWithoutExtension(_scene);
                EditoolsButton.Button(_name, Color.grey, () => { EditorSceneManager.OpenScene(_scene); });
            }
        }
        
    }
}