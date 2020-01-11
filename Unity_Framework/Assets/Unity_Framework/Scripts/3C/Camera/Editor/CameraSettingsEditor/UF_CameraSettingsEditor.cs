using System;
using UnityEditor;
using UnityEngine;

public class UF_CameraSettingsEditor : EditorWindow, IIsValid
{
    #region f/p
    private UF_CameraSettingDatabase data = null;
    public bool IsValid => data;
    #endregion

    
    #region unity methods
    private void OnEnable()
    {
        data = Resources.Load<UF_CameraSettingDatabase>("data/CameraSettingDatabase");
    }
    #endregion


    
    #region custom methods

    
    
    #endregion
}