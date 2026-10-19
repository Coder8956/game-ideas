using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Vector3)]
    [ActionDescription("Set a Vector3 variable to the True Value or False Value based on a Bool.")]
    public class Vector3SelectValue : BaseSelectValue<Vector3Var, Vector3Ref>
    {
    }
}
