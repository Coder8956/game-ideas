using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Get the values of a Texture2D list variable in another FSM.")]
    public class GetFsmTexture2DList : BaseGetFsmVariableAction<List<Texture2D>, Texture2DListVariable, Texture2DListRef, Texture2DListVar>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}

