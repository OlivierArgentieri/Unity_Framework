using System;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class UF_CharacterBehaviourFPS : UF_CharacterBehaviour, IIsValid, IEnable
{
    #region f/p
    [SerializeField, Header("Enable")] private bool isEnable = true;
    [SerializeField, Header("Gravity"), Range(0,50)] private float gravity= 20f;
    
    private CharacterController characterController = null;
    

    private bool canMove => characterController && characterController.isGrounded;
    public bool IsEnable => isEnable;
    
    public bool IsValid => CharacterSettings != null && characterController;
    #endregion


    #region unity methods
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
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

        
        if (!canMove)
        {
            Gravity();
            return;
        }
        
        if(_moveAxis == Vector2.zero) return;
        Vector3 _move = new Vector3(_moveAxis.x, 0, _moveAxis.y);
        _move = transform.TransformDirection(_move);
        _move *= CharacterSettings.MoveSpeed;
        characterController.Move(_move);

    }

    void Gravity()
    {
        if(!IsValid) return;

        Vector3 _gravityVector = Vector3.zero;
        _gravityVector.y -= gravity * Time.deltaTime;
        characterController.Move(_gravityVector);
    }
    public void SetEnable(bool _value) => isEnable = _value;

    #endregion
}