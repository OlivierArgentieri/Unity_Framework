using System;
using UnityEngine;

[Serializable]
public class UF_CharacterSettings
{
    #region f/p
    [SerializeField, Header("Move Speed "), Range(0,100)]private float moveSpeed = 10.0f;
    private UF_CharacterComponent localPlayer = null;

    
    public float MoveSpeed => moveSpeed;
    #endregion

    
    
    #region custom methods
    public void InitSettings(UF_CharacterComponent _character)
    {
        SetPlayer(_character);
    }

    private void SetPlayer(UF_CharacterComponent _character) => localPlayer = _character;

    #endregion
}