namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    public abstract class BaseWaitAction : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame | UpdateMode.Blocking;
        public override UpdateMode RequiredUpdateModes => DefaultUpdateMode;
        public override bool CanFinish => true;
    }
}
