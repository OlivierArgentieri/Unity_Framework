namespace uf
{
    public interface IEnable
    {
        #region f/p

        bool IsEnable { get; }

        #endregion

        #region custom methods

        void SetEnable(bool _value);

        #endregion
    }
}