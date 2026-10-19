using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Convert)]
    public class ConvertBoolToVector3 : BaseConvertBool<Vector3Var, Vector3Ref>
    {
        public override void Execute() => StoreResult.Value = Evaluate.Value;
    }
}