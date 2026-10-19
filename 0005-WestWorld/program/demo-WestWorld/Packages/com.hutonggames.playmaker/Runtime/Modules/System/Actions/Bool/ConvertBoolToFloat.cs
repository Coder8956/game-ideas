using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Convert)]
    public class ConvertBoolToFloat : BaseConvertBool<FloatVar, FloatRef>
    {
        public override void Execute() => StoreResult.Value = Evaluate.Value;
    }
}