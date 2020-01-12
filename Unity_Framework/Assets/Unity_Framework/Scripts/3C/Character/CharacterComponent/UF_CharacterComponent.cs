using System.Linq;
using UnityEngine;

public class UF_CharacterComponent : MonoBehaviour, IHandlerItem<int>
{

    #region f/p

    public int ID => 0;
    
    [SerializeField, Header("Player Settings")] private UF_CharacterSettings characterSettings = new UF_CharacterSettings();
    [SerializeField, Header("")] UF_CharacterBehaviourType behaviourType = UF_CharacterBehaviourType.NONE;

    private UF_CharacterBehaviour characterBehaviour = null;
    
    
    public UF_CharacterSettings CharacterSettings => characterSettings;
    public UF_CharacterBehaviourType BehaviourType => behaviourType;
    public bool IsValid => true;
    #endregion

    #region unity methods

    private void Awake()
    {
        UF_CharacterManager.OnReady += InitCharacter;
    }

    private void OnDestroy()
    {
        Unregister();
    }

    #endregion
    

    #region custom methods

    void InitCharacter()
    {
        Register();
        characterSettings.InitSettings(this);
        InitBehaviour();
    }

    public void InitBehaviour()
    {
        characterBehaviour = GetComponent<UF_CharacterBehaviour>();
        switch (behaviourType)
        {
            case UF_CharacterBehaviourType.FPS:
                if (BehaviourExist() && characterBehaviour.GetComponent<UF_CharacterBehaviourFPS>()) break;
                ClearBehaviours();
                characterBehaviour = gameObject.AddComponent<UF_CharacterBehaviourFPS>();
                break;
            case UF_CharacterBehaviourType.RTS:
                
                break;
            case UF_CharacterBehaviourType.TPS:
                
                break;
            case UF_CharacterBehaviourType.NONE:
                
                break;
            
        }
        characterBehaviour?.InitCharacterBehaviour(characterSettings);

    }
    
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
    
    private bool BehaviourExist() => GetComponent<UF_CharacterBehaviour>() != null;
    private void ClearBehaviours() => gameObject.GetComponents<UF_CameraBehaviour>().ToList().ForEach(DestroyImmediate);
    
    #endregion
}

public enum UF_CharacterBehaviourType
{
    FPS,
    RTS,
    TPS,
    NONE
}