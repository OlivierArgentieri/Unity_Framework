using System;
using UnityEngine;

public class FU_CameraComponent: MonoBehaviour, IHandlerItem<int>
{
    #region f/p
    public int ID { get; }
    public bool IsValid { get; }
    #endregion

    #region unity mehods
    private void Awake()
    {
        FU_CameraManager.OnReady += Register;
    }
    
    private void OnDestroy()
    {
        Unregister();
    }
    #endregion
    
    
    #region custom methods
    public void Register()
    {
        FU_CameraManager.Instance.Add(this);
    }

    public void Unregister()
    {
        FU_CameraManager.Instance.Remove(this);
    }
    #endregion
}