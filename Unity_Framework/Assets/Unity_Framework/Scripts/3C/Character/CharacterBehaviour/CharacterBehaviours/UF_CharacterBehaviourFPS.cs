using UnityEditor;
using UnityEngine;

public class UF_CharacterBehaviourFPS : UF_CharacterBehaviour, IIsValid, IEnable
{
    #region f/p

    [SerializeField, Header("Enable")] private bool isEnable = true;
    public bool IsEnable => isEnable;
    public bool IsValid => CharacterSettings != null;
    #endregion

    
    
    #region custom methods

    public override void InitCharacterBehaviour(UF_CharacterSettings _characterSettings)
    {
        base.InitCharacterBehaviour(_characterSettings);

        UF_InputManager.OnMoveFPS += OnMoveFPS;
    }


    void OnMoveFPS(Vector2 _moveAxis)
    {
        if(!IsValid || !IsEnable) return;
        
        CharacterSettings.LocalPlayer.transform.position += _moveAxis.y * CharacterSettings.MoveSpeed * Time.deltaTime * CharacterSettings.LocalPlayer.transform.forward;
        CharacterSettings.LocalPlayer.transform.position += _moveAxis.x * CharacterSettings.MoveSpeed * Time.deltaTime * CharacterSettings.LocalPlayer.transform.right;
    }
    public void SetEnable(bool _value) => isEnable = _value;

    #endregion
}