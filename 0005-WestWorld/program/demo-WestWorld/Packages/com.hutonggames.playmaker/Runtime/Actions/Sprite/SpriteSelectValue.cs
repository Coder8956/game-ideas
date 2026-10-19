using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Sprite)]
    [ActionDescription("Set a Sprite variable to the True Value or False Value based on a Bool.")]
    public sealed class SpriteSelectValue : BaseSelectValue<SpriteVar, SpriteRef>
    {
    }
}
