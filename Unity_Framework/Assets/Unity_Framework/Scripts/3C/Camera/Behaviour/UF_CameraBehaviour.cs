public abstract class UF_CameraBehaviour: IIsValid, IEnable
{
    #region f/p

    public bool IsValid { get; protected set; } = true;
    public bool IsEnable { get; protected set; }
    
    #endregion
    
    #region custom methods

    protected virtual void FollowTarget()
    {
        
    }

    protected virtual void LookAtTarget()
    {
        
    }
    
    public void SetEnable(bool _value)
    {
        IsEnable = _value;
    }
    #endregion
}