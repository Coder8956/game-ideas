using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Convert)]
    public class ConvertBoolToInteger : BaseConvertBool<IntegerVar, IntegerRef>
    {
        public override void Execute() => StoreResult.Value = Evaluate.Value;
    }
}