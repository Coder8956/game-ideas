using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ActionDescription("Set a GameObject variable to the True Value or False Value based on a Bool.")]
    public class GameObjectSelectValue : BaseSelectValue<GameObjectVar, GameObjectRef>
    {
    }
}
