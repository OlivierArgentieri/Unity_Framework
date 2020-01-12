using UnityEngine;

public class UF_CharacterComponent : MonoBehaviour, IHandlerItem<int>
{

    #region f/p
    public bool IsValid => true;

    public int ID => 0;
    #endregion


    #region custom methods
    public void Register()
    {
        if (!UF_CharacterManager.Instance) return;
        UF_CharacterManager.Instance.Add(this);
    }

    public void Unregister()
    {
        if (!UF_CharacterManager.Instance) return;
        UF_CharacterManager.Instance.Remove(this);
    }
    #endregion
}