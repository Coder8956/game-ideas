using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Float)]
    [ActionDescription("Set a Float variable to the True Value or False Value based on a Bool.")]
    public class FloatSelectValue : BaseSelectValue<FloatVar, FloatRef>
    {
    }
}
