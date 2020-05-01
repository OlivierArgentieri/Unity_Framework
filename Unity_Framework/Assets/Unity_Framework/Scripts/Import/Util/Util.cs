using UnityEngine;

namespace Unity_Framework.Scripts.Import.Util
{
    public abstract class Util
    {
        public static float ClampRotation(float _value, float _maxValue, float _minValue)
        {
            float _toReturn = _value;

            if (_toReturn > _maxValue)
                _toReturn = _maxValue;
        
            else if (_toReturn < _minValue)
                _toReturn = _minValue;

            return _toReturn % 360;
        }

        public static Ray ConvertCordToRay(Camera _camera, Vector2 _v2, float _distance) => _camera.ScreenPointToRay(new Vector3(_v2.x, _v2.y, _distance));
    }
}