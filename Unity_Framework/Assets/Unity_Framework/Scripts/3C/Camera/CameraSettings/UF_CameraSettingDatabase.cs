using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraSettingDatabase", menuName = "Camera/CameraSetting")]
public class UF_CameraSettingDatabase : ScriptableObject
{
    #region f/p
    List<UF_CameraSetting> datas = new List<UF_CameraSetting>();

    [SerializeField] private int selectedSetting = 0;

    public UF_CameraSetting CurrentSetting => GetSettingById(selectedSetting);
    public List<UF_CameraSetting> Datas => datas;
    #endregion

    #region custom methods

    public void AddSetting() => datas.Add(new UF_CameraSetting(this));
    
    public UF_CameraSetting GetSettingById(int _id)
    {
        if (_id < 0 || _id > Datas.Count - 1) return null;

        return Datas[_id];
    }

    public void EditSetting(int _index) => selectedSetting = _index;
    public void RemoveSettingById(int _index) => datas.RemoveAt(_index);

    #endregion
}