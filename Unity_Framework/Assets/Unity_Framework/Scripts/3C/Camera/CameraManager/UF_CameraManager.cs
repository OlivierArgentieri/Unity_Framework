using System;
using System.Collections.Generic;

public class UF_CameraManager: ManagerTemplate<UF_CameraManager>, IHandler<int, UF_CameraComponent>
{
    #region f/p
    public static event Action OnReady = null;
    public Dictionary<int, UF_CameraComponent> Handles { get; } = new Dictionary<int, UF_CameraComponent>();
    public bool IsValid => Handles != null;
    #endregion


    #region unity methods
    protected override void Awake()
    {
        base.Awake();
        OnReady?.Invoke();
    }
    #endregion
    
    #region custom methods

    private void Handler(bool _add, UF_CameraComponent _component)
    {
        if (!_component.IsValid || !IsValid) return;

        bool _handle = _add ? !IsExist(_component) : IsExist(_component);
        
        if(! _handle) throw new Exception("CameraManager => Invalid Component in Handler Method");
        
        if (_add)
            Handles.Add(_component.ID, _component);
        else
            Handles.Remove(_component.ID);
    }
    
    public void Add(UF_CameraComponent _item) => Handler(true, _item);
    public void Remove(UF_CameraComponent _item) => Handler(false, _item);
    public bool IsExist(UF_CameraComponent _item)
    {
        if (!IsValid) throw new Exception("CameraManager => Invalid CameraManager");
        return Handles.ContainsKey(_item.ID);
    }
    #endregion

}