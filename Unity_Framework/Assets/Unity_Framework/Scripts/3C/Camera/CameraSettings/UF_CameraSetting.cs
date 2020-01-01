using System;
using UnityEngine;

[Serializable]
public class UF_CameraSetting
{
     #region f/p

    [SerializeField, Header("Target")] private Transform target = null;
    [SerializeField, Header("Camera")] private Camera localCamera = null;

    #region offset
    [SerializeField, Header("Offset X"), Range(-20, 20)] private float offsetX = 0;
    [SerializeField, Header("Offset X Max"), Range(-20, 20)] private float offsetXMax = 20;
    [SerializeField, Header("Offset X Min"), Range(-20, 20)] private float offsetXMin = -20;
    
    [SerializeField, Header("Offset Y"), Range(-20, 20)] private float offsetY = 0;
    [SerializeField, Header("Offset Y Max"), Range(-20, 20)] private float offsetYMax = 20;
    [SerializeField, Header("Offset Y Min"), Range(-20, 20)] private float offsetYMin = -20;
    
    [SerializeField, Header("Offset Z"), Range(-20, 20)] private float offsetZ = 0;
    [SerializeField, Header("Offset Z Max"), Range(-20, 20)] private float offsetZMax = 20;
    [SerializeField, Header("Offset Z Min"), Range(-20, 20)] private float offsetZMin = -20;
    #endregion

    #region clamp
    [SerializeField, Header("Clamp X")] private bool clampX = false;
    [SerializeField, Header("Clamp Y")] private bool clampY = false;

    [SerializeField, Header("Clamp X Value Min"), Range(-180, 180)] private float clampXValueMin = 0;
    [SerializeField, Header("Clamp X Value Max"), Range(-180, 180)] private float clampXValueMax = 0;
    [SerializeField, Header("Clamp Y Value Min"), Range(-180, 180)] private float clampYValueMin = 0;
    [SerializeField, Header("Clamp Y Value Max"), Range(-180, 180)] private float clampYValueMax = 0;
    #endregion
   
    [SerializeField, Header("Rotate Speed"), Range(0, 200)] private float rotateSpeed = .1f;
    [SerializeField, Header("Rotate Speed Max"), Range(0, 200)] private float rotateSpeedMax = 200;
    [SerializeField, Header("Rotate Speed Min"), Range(0, 200)] private float rotateSpeedMin = 0;

    [SerializeField, Header("Follow Player ?")] private bool followPlayer= false;
    [SerializeField, Header("Focus Player ?")] private bool focusPlayer = false;

    [SerializeField, Header("Follow Target Speed"), Range(0, 100)] private float followSpeed = .1f;
    [SerializeField, Header("Follow Target Speed Max"), Range(0, 100)] private float followSpeedMax = 100f;
    [SerializeField, Header("Follow Target Speed Min"), Range(0, 100)] private float followSpeedMin = 0;

    
    #region get/set

    public Transform Target => target;
    public Camera LocalCamera => localCamera;


    #region offset
    public float OffsetX
    {
        get => offsetX;
        set => offsetX = ClampValue(value, offsetXMax, offsetXMin);
    }

    public float OffsetY
    {
        get => offsetY;
        set=> offsetY = ClampValue(value, offsetYMax, offsetYMin);
    }

    public float OffsetZ
    {
        get => offsetZ;
        set=> offsetZ = ClampValue(value, offsetZMax, offsetZMin);
    }

    #endregion


    #region clamp
    public bool ClampX
    {
        get => clampX;
        set => clampX = value;
    }

    public bool ClampY
    {
        get => clampY;
        set => clampY = value;
    }
    
    public float ClampXValueMin
    {
        get => clampXValueMin;
        set => clampXValueMin = ClampValue(value, 180, -180);
    }

    public float ClampXValueMax
    {
        get => clampXValueMax;
        set => clampXValueMax = ClampValue(value, 180, -180);
    }
    
    public float ClampYValueMin
    {
        get => clampYValueMin;
        set => clampYValueMin = ClampValue(value, 180, -180);
    }

    public float ClampYValueMax
    {
        get => clampYValueMax;
        set => clampYValueMax = ClampValue(value, 180, -180);
    }
    #endregion

    public bool FollowPlayer => followPlayer;
    public bool FocusPlayer => focusPlayer;
    public float RotateSpeed
    {
        get => rotateSpeed;
        set => rotateSpeed = ClampValue(value, rotateSpeedMax, rotateSpeedMin);
    }

    public float FollowSpeed
    {
        get => followSpeed;
        set => followSpeed = ClampValue(value, followSpeedMax, followSpeedMin);
    }
    
    #endregion

    #endregion



    #region custom methods

    float ClampValue(float _value, float _maxValue, float _minValue)
    {
        float _toReturn = _value;
        if (_toReturn > _maxValue)
            _toReturn = _maxValue;
        else if (_toReturn < _minValue)
            _toReturn = _minValue;

        return _toReturn;
    }

    public void SetLocalCamera(Camera _camera)
    {
        localCamera = _camera;
    }

    #endregion
}