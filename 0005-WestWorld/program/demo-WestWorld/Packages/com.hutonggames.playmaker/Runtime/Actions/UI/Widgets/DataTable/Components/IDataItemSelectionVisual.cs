namespace HutongGames.PlayMaker.UI
{
    public interface IDataItemSelectionVisual
    {
        void SetSelected(bool selected);  // user action: may animate
        void SyncSelected(bool selected); // rebuild/pool: no animation
    }
}