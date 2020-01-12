using UnityEngine;

public class UF_CharacterBehaviour : MonoBehaviour
{
    #region f/p
    private UF_CharacterSettings characterSettings = null;
    protected UF_CharacterSettings CharacterSettings => characterSettings ;
    #endregion


    #region custom methods
    public virtual void InitCharacterBehaviour(UF_CharacterSettings _characterSettings)
    {
        characterSettings = _characterSettings;
    }
    #endregion
}