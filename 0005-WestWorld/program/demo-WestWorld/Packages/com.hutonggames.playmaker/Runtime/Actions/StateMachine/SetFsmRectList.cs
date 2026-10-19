using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Set the values of a Rect list variable in another FSM.")]
    public class SetFsmRectList : BaseSetFsmVariableAction<List<Rect>, RectListVariable, RectListVar>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}

