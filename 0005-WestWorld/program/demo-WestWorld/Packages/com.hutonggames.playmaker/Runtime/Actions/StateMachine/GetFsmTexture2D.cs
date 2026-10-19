using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Get the value of a Texture2D variable in another FSM.")]
    public class GetFsmTexture2D : BaseGetFsmVariableAction<Texture2D, Texture2DVariable, Texture2DRef, Texture2DVar>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}