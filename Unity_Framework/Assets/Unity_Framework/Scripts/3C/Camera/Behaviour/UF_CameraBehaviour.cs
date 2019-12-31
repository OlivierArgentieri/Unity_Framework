using System;
using UnityEngine;

public abstract class UF_CameraBehaviour: MonoBehaviour, IIsValid, IEnable
{
    #region f/p
    public Action OnUpdateBehaviour = null;

    private UF_CameraSetting cameraSetting = null;
    public bool IsValid => cameraSetting != null;
    public bool IsEnable { get; protected set; }

    public UF_CameraSetting CameraSetting => cameraSetting;
    #endregion
    
    #region custom methods
    public void InitBehaviour(UF_CameraSetting _cameraSetting)
    {
        cameraSetting = _cameraSetting;
        
    }
    
    protected virtual void FollowTarget()
    {
        if (!IsValid || !cameraSetting.FollowPlayer) return;

    }

    protected virtual void LookAtTarget()
    {
        if (!IsValid || !cameraSetting.FocusPlayer) return;
        
    }
    
    public void SetEnable(bool _value)
    {
        IsEnable = _value;
    }
    #endregion
}