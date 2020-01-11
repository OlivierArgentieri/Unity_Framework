
using UnityEngine;

public class UF_CameraBehaviourTPS : UF_CameraBehaviour
{
    #region f/p
    [SerializeField, Header("Target")] private Transform target = null;

    public Transform Target => target;


    #endregion
    
    
    public override void InitBehaviour(UF_CameraSetting _cameraSetting)
    {
        base.InitBehaviour(_cameraSetting);
        
    }


    protected override void FollowTarget()
    {
        base.FollowTarget();
        
    }

    protected override void LookAtTarget()
    {
        base.LookAtTarget();
        
    }
}