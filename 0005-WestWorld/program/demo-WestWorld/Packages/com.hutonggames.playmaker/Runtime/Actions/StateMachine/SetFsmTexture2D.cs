using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Set the value of a Texture2D variable in another FSM.")]
    public class SetFsmTexture2D : BaseSetFsmVariableAction<Texture2D, Texture2DVariable, Texture2DVar>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}
