using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Convert)]
    public class ConvertBoolToTransform : BaseConvertBool<TransformVar, TransformRef>
    {
        public override void Execute() => StoreResult.Value = Evaluate.Value;
    }
}