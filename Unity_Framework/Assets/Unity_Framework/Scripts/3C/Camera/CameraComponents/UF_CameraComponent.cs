using System;
using System.Linq;
using UnityEngine;

public class UF_CameraComponent : MonoBehaviour, IHandlerItem<int>
{
    #region f/p
    [SerializeField, Header("Camera ID")]
    private int cameraID = 0;
    
    [SerializeField, Header("Camera Settings")]
    private UF_CameraSetting cameraSettings = null;

    [SerializeField, Header("Camera Type")]
    private CameraTypes cameraType = CameraTypes.Custom;

    private UF_CameraBehaviour behaviour = null;


    public CameraTypes CameraType => cameraType;
    public int ID => cameraID;
    public bool IsValid => cameraSettings;

    #endregion

    #region unity mehods

    private void Awake()
    {
        if (!IsValid) return;
        UF_CameraManager.OnReady += Register;
        cameraSettings.SetLocalCamera(GetComponent<Camera>());

        InitBehaviour();
    }

    private void Update()
    {
        UpdateBehaviour();
    }

    private void OnDestroy()
    {
        Unregister();
    }

    #endregion


    #region custom methods

    private void UpdateBehaviour()
    {
        if (!IsValid) return;

        behaviour.OnUpdateBehaviour?.Invoke();
    }

    public void InitBehaviour()
    {
        behaviour = GetComponent<UF_CameraBehaviour>();
        switch (cameraType)
        {
            case CameraTypes.FPS:
                if (BehaviourExist() && behaviour.GetComponent<UF_CameraBehaviourFPS>()) break;
                ClearBehaviours();
                behaviour = gameObject.AddComponent<UF_CameraBehaviourFPS>();
                break;
            case CameraTypes.TPS:
                if (BehaviourExist() && behaviour.GetComponent<UF_CameraBehaviourTPS>()) break;
                ClearBehaviours();

                behaviour = gameObject.AddComponent<UF_CameraBehaviourTPS>();
                break;
            case CameraTypes.RTS:
                if (BehaviourExist() && behaviour.GetComponent<UF_CameraBehaviourRTS>()) break;
                ClearBehaviours();

                behaviour = gameObject.AddComponent<UF_CameraBehaviourRTS>();
                break;
            case CameraTypes.Custom:
                break;
        }

        behaviour?.InitBehaviour(cameraSettings);
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

    private void ClearBehaviours()
    {
        gameObject.GetComponents<UF_CameraBehaviour>().ToList().ForEach(DestroyImmediate);
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