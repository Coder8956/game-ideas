using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Convert)]
    public class ConvertBoolToString : BaseConvertBool<StringVar, StringRef>
    {
        public override void Reset()
        {
            base.Reset();
            SetDefaults("True", "False");
        }
        
        public override void Execute() => StoreResult.Value = Evaluate.Value;
    }
}