using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UF_InputManager : ManagerTemplate<UF_InputManager>
{
    #region Axis
    
    #region axis actions
    public static event Action<Vector2> OnMouseAxis = null;
    public static event Action<Vector2> OnMoveFPS = null;
    
    #endregion
    
    #region axis label
    [SerializeField, Header("Mouse X Label")]private string mouseXLabel = "Mouse X";
    [SerializeField, Header("Mouse Y Label")]private string mouseYLabel = "Mouse Y";
    
    [SerializeField, Header("Horizontal Label")] private string moveHorizontalLabel = "Horizontal";
    [SerializeField, Header("Vertical Label")] private string moveVerticalLabel = "Vertical";

    #endregion

    #region axis Value (debug)

    [SerializeField, Header("Mouse X Value ")]private float mouseXValue = 0;
    [SerializeField, Header("Mouse Y Value ")]private float mouseYValue = 0;

    [SerializeField, Header("Horizontal Axis Value")]private float moveHorizontalValue = 0;
    [SerializeField, Header("Vertical Axis Value")]private float moveVerticalValue = 0;
    
    private float MouseXValue => mouseXValue = Input.GetAxis(mouseXLabel);
    private float MouseYValue => mouseYValue = Input.GetAxis(mouseYLabel);
    private float MoveVerticalValue => moveVerticalValue= Input.GetAxis(moveVerticalLabel);
    private float MoveHorizontalValue => moveHorizontalValue = Input.GetAxis(moveHorizontalLabel);

    #endregion

    #endregion

    #region unity methods

    private void Update()
    {
        // Axis
        OnMouseAxis?.Invoke(new Vector2(MouseXValue, MouseYValue));
        OnMoveFPS?.Invoke(new Vector2(MoveHorizontalValue, MoveVerticalValue));
    }

    private bool GetListKeyDownInputValue(List<UF_Key> _actions)
    {
        for (int i = 0; i < _actions.Count; i++)
        {
            if (Input.GetKeyDown(_actions[i].Key))
                return true;
        }
        return false;
    }
    
    
    private bool GetListKeyInputValue(List<UF_Key> _actions)
    {
        for (int i = 0; i < _actions.Count; i++)
        {
            if (Input.GetKey(_actions[i].Key))
                return true;
        }
        return false;
    }
    #endregion

}