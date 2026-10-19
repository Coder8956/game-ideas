using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Get the values of a Color list variable in another FSM.")]
    public class GetFsmColorList : BaseGetFsmVariableAction<List<Color>, ColorListVariable, ColorListRef, ColorListVar>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}

