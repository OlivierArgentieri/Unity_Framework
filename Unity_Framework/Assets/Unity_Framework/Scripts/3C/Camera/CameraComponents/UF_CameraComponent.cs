using System;
using UnityEngine;

public class UF_CameraComponent: MonoBehaviour, IHandlerItem<int>
{
    #region f/p
    public int ID { get; }
    public bool IsValid { get; }
    #endregion

    #region unity mehods
    private void Awake()
    {
        UF_CameraManager.OnReady += Register;
    }
    
    private void OnDestroy()
    {
        Unregister();
    }
    #endregion
    
    
    #region custom methods
    public void Register()
    {
        UF_CameraManager.Instance.Add(this);
        name += "[SLV]"; // Slave
    }

    public void Unregister()
    {
        UF_CameraManager.Instance.Remove(this);
    }
    #endregion
}