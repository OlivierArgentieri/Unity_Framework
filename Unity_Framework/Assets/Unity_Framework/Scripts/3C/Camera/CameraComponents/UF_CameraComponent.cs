using System;
using System.Linq;
using UnityEngine;

public class UF_CameraComponent: MonoBehaviour, IHandlerItem<int>
{
    #region f/p
    public int ID { get; }
    public bool IsValid => BehaviourExist();
    
    [SerializeField, Header("Camera Settings")]
    private UF_CameraSetting cameraSettings = new UF_CameraSetting();

    [SerializeField, Header("Camera Type")]
    private CameraTypes cameraType = CameraTypes.Custom;

    private UF_CameraBehaviour _behaviour = null;
    public CameraTypes CameraType => cameraType;
    #endregion

    #region unity mehods
    private void Awake()
    {
        UF_CameraManager.OnReady += Register;
        cameraSettings.SetLocalCamera(GetComponent<Camera>());
        
        InitBehaviour();
        
    }

    private void Update()
    {
        if (!IsValid) return;
        _behaviour.OnUpdateBehaviour?.Invoke();
    }

    private void OnDestroy()
    {
        Unregister();
    }
    #endregion
    
    
    #region custom methods

    public void InitBehaviour()
    {
        gameObject.GetComponents<UF_CameraBehaviour>().ToList().ForEach(DestroyImmediate);
       
        switch (cameraType)
        {
            case CameraTypes.FPS:
                _behaviour = gameObject.AddComponent<UF_CameraBehaviourFPS>();
                break;
            case CameraTypes.TPS:
                break;
            case CameraTypes.RTS:
                break;
            case CameraTypes.Custom:
                break;
        }
        
        _behaviour?.InitBehaviour(cameraSettings);
    }
    
    public void Register()
    {
        if (!UF_CameraManager.Instance) return;
        UF_CameraManager.Instance.Add(this);
        name += "[SLV]"; // Slave
    }

    public void Unregister()
    {
        if (!UF_CameraManager.Instance) return;
        UF_CameraManager.Instance.Remove(this);
    }

    private bool BehaviourExist()
    {
        return GetComponent<UF_CameraBehaviour>() != null;
    }
    #endregion
}

public enum CameraTypes
{
    FPS,
    TPS,
    RTS,
    Custom,
}