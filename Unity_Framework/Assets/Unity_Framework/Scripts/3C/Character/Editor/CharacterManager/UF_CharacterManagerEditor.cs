using UnityEditor;
using UnityEngine;

namespace uf
{
    public class UF_CharacterManagerEditor
    {
        #region custom methods

        [MenuItem("UF/Character/CharacterManager")]
        public static void Init()
        {
            UF_CharacterManager[] _characterManagers = Object.FindObjectsOfType<UF_CharacterManager>();

            if (_characterManagers.Length > 0) return;

            GameObject _characterManager = new GameObject("CharacterManager", typeof(UF_CharacterManager));
            Selection.activeObject = _characterManager;


            // create InputManager 
            UF_InputManagerEditor.Init();
        }

        #endregion
    }
}