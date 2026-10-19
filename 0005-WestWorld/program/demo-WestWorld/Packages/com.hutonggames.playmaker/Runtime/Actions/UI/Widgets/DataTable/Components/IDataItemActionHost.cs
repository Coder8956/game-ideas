namespace HutongGames.PlayMaker.UI
{
    public interface IDataItemActionHost
    {
        bool TryHandleAction(in DataUIActionRequest request);
    }
}