using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Convert)]
    public class ConvertBoolToColor : BaseConvertBool<ColorVar, ColorRef>
    {
        public override void Reset()
        {
            base.Reset();
            SetDefaults(Color.white, Color.black);
        }
        
        public override void Execute() => StoreResult.Value = Evaluate.Value;
    }
}