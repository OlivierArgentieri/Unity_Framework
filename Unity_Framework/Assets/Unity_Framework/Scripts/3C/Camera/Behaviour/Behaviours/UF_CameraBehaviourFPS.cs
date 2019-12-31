using UnityEngine;

public class UF_CameraBehaviourFPS : UF_CameraBehaviour
{
    #region f/p

    private float roll = 0; // x
    private float pitch = 0; // y

    #endregion

    #region custom methods

    protected override void FollowTarget()
    {
        base.FollowTarget();
        Vector3 _offset = new Vector3(CameraSetting.OffsetX, CameraSetting.OffsetY, CameraSetting.OffsetZ);
        transform.position = Vector3.MoveTowards(transform.position, CameraSetting.Target.position + _offset,Time.deltaTime * CameraSetting.FollowSpeed);
    }

    private void OnMouseAxis(Vector2 _mouseAxis)
    {
        if (!IsEnable) return;

        roll += -_mouseAxis.y * CameraSetting.RotateSpeed * Time.deltaTime;
        pitch += _mouseAxis.x * CameraSetting.RotateSpeed * Time.deltaTime;

        if (CameraSetting.ClampX)
            roll = Util.ClampRotation(roll, CameraSetting.ClampXValueMax, CameraSetting.ClampXValueMin);
        else
            roll = roll % 360;

        if (CameraSetting.ClampY)
            pitch = Util.ClampRotation(pitch, CameraSetting.ClampYValueMax, CameraSetting.ClampYValueMin);
        else
            pitch = pitch % 360;
        
        transform.eulerAngles = new Vector3(roll, pitch, transform.eulerAngles.z);
        CameraSetting.Target.eulerAngles = new Vector3(CameraSetting.Target.eulerAngles.x, pitch, CameraSetting.Target.eulerAngles.z);
    }

    #endregion
}