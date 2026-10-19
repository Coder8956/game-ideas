using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Set the values of a Texture2D list variable in another FSM.")]
    public class SetFsmTexture2DList : BaseSetFsmVariableAction<List<Texture2D>, Texture2DListVariable, Texture2DListVar>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}
