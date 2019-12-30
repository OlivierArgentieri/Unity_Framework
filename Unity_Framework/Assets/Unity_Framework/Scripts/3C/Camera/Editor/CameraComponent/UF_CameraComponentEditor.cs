
using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(UF_CameraComponent))]
public class UF_CameraComponentEditor : Editor
{
    #region f/p

    private CameraTypes previousCameraType;

    #endregion
    private static UF_CameraComponent eTarget = null;

    #region unity methods

    private void OnEnable()
    {
        eTarget = (UF_CameraComponent) target;
    }
    
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
       
        if (eTarget.CameraType.ToString() != previousCameraType.ToString())
        {
            previousCameraType = eTarget.CameraType;
            InitCameraBehaviour();
            Debug.Log(eTarget.CameraType.ToString() != previousCameraType.ToString());
            Debug.Log(previousCameraType);
        }
    }
    
    #endregion


    #region custom methods

    void InitCameraBehaviour()
    {
        eTarget.InitBehaviour();
    }

    #endregion
}