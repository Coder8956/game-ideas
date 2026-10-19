using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Vector2)]
    [ActionDescription("Set a Vector2 variable to the True Value or False Value based on a Bool.")]
    public class Vector2SelectValue : BaseSelectValue<Vector2Var, Vector2Ref>
    {
    }
}
