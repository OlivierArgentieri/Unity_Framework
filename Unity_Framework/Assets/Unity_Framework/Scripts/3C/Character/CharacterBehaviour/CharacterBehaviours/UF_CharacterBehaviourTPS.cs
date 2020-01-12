using System;
using UnityEngine;

public class UF_CharacterBehaviourTPS : UF_CharacterBehaviour, IIsValid, IEnable
{
    #region f/p
    private event Action OnUpdate = null; 

    [SerializeField, Header("Enable")] private bool isEnable = true;
    
    [SerializeField, Range(0,500), Header("Rotate Speed")] private float rotateSpeed = 400;
    
    [SerializeField, Header("ID Main Camera")] private int idMainCamera = 0;

    private UF_CameraComponent mainCamera = null;
    
    public bool IsEnable => isEnable;
    public bool IsValid => CharacterSettings != null && mainCamera;
    #endregion


    #region unity methods

    private void Update()
    {
        OnUpdate?.Invoke();
    }

    private void OnDestroy()
    {
        OnUpdate = null;
        UF_CameraManager.OnRegister -= SetMainCamera;
    }
    #endregion
    
    #region custom methods
    public override void InitCharacterBehaviour(UF_CharacterSettings _characterSettings)
    {
        base.InitCharacterBehaviour(_characterSettings);
        UF_CameraManager.OnRegister += SetMainCamera;


    }
    
    void OnMoveFPS(Vector2 _moveAxis)
    {
        if(!IsValid || !IsEnable) return;
        
        CharacterSettings.LocalPlayer.transform.rotation = Quaternion.AngleAxis(mainCamera.transform.eulerAngles.y, Vector3.up);
        
        CharacterSettings.LocalPlayer.transform.position += _moveAxis.y * CharacterSettings.MoveSpeed * Time.deltaTime * CharacterSettings.LocalPlayer.transform.forward;
        CharacterSettings.LocalPlayer.transform.position += _moveAxis.x * CharacterSettings.MoveSpeed * Time.deltaTime * CharacterSettings.LocalPlayer.transform.right;
    }

    
    void OnRotateTo()
    {
        if (!IsValid || !isEnable) return;

        RotateTo(mainCamera.transform.forward, rotateSpeed);
    }
    
    
    void RotateTo(Vector3 _target, float _rotateSpeed)
    {
        if ((_target + transform.localScale / 2) - transform.position == Vector3.zero) return;

        Quaternion lookAt = Quaternion.LookRotation((_target  + transform.localScale/2) - transform.position,  transform.up);
        if((lookAt.eulerAngles - Vector3.zero).magnitude > 0)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(lookAt.eulerAngles.y, Vector3.up), Time.deltaTime * _rotateSpeed);
    }

    void SetMainCamera(UF_CameraComponent _camera)
    {
        if(!_camera && _camera.ID != idMainCamera) return;
        mainCamera = _camera;
        
        if (!mainCamera) return;
       // OnUpdate += OnRotateTo;
    }
    
    public void SetEnable(bool _value) => isEnable = _value;
    #endregion

    #region Gizmos

    private void OnDrawGizmos()
    {
        if(!IsValid || !mainCamera || !mainCamera.CameraSettings) return;

        if (!mainCamera.CameraSettings.LocalCamera) return;
        UF_InputManager.OnMoveFPS += OnMoveFPS;

    }

    #endregion

}