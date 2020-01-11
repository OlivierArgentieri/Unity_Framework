using System;
using UnityEngine;
using UnityEngine.UIElements;

public class UF_InputManager : ManagerTemplate<UF_InputManager>
{
    #region Axis
    

    
    #region axis actions
    public static event Action<Vector2> OnMouseAxis = null;
    
    #endregion
    
    #region axis label
    [SerializeField, Header("Mouse X Label")]
    private string mouseXLabel = "Mouse X";
    
    [SerializeField, Header("Mouse Y Label")]
    private string mouseYLabel = "Mouse Y";
    #endregion

    #region axis Value (debug)

    [SerializeField, Header("Mouse X Value ")]
    private float mouseXValue = 0;
    [SerializeField, Header("Mouse Y Value ")]
    private float mouseYValue = 0;

    private float MouseXValue => mouseXValue = Input.GetAxis(mouseXLabel);
    private float MouseYValue => mouseYValue = Input.GetAxis(mouseYLabel);

    #endregion

    #endregion

    #region unity methods

    private void Update()
    {
        // Axis
        OnMouseAxis?.Invoke(new Vector2(MouseXValue, MouseYValue));
    }

    #endregion

}