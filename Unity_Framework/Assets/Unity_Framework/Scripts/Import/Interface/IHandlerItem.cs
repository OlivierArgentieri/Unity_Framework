public interface IHandlerItem<TID>
{
    #region f/p
    TID ID { get; }
    #endregion
    
    #region custom methods
    void Register();
    void Unregister();
    #endregion
}