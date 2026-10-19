using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Color)]
    [ActionDescription("Set a Color variable to the True Value or False Value based on a Bool.")]
    public sealed class ColorSelectValue : BaseSelectValue<ColorVar, ColorRef>
    {
        public override void Reset()
        {
            base.Reset();
            SetDefaults(Color.white, Color.black);
        }
    }
}
