using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Convert)]
    public class ConvertBoolToSprite : BaseConvertBool<SpriteVar, SpriteRef>
    {
        public override void Execute() => StoreResult.Value = Evaluate.Value;
    }
}