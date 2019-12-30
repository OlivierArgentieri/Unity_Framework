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
}