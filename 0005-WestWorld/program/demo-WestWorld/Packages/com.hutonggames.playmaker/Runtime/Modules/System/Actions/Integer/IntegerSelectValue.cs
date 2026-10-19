using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Integer)]
    [ActionDescription("Set an Integer variable to the True Value or False Value based on a Bool.")]
    public class IntegerSelectValue : BaseSelectValue<IntegerVar, IntegerRef>
    {
    }
}
