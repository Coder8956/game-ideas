using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Convert)]
    public class ConvertBoolToVector2 : BaseConvertBool<Vector2Var, Vector2Ref>
    {
        public override void Execute() => StoreResult.Value = Evaluate.Value;
    }
}