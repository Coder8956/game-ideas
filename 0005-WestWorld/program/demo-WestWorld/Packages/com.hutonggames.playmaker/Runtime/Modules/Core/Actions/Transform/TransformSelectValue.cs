using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Transform)]
    [ActionDescription("Set a Transform variable to the True Value or False Value based on a Bool.")]
    public class TransformSelectValue : BaseSelectValue<TransformVar, TransformRef>
    {
    }
}
