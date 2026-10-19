using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Get the values of a Rect list variable in another FSM.")]
    public class GetFsmRectList : BaseGetFsmVariableAction<List<Rect>, RectListVariable, RectListRef, RectListVar>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}

