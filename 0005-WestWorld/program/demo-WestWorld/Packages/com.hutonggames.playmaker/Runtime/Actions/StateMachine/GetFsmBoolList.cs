using System.Collections.Generic;
using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Get the values of a bool list variable in another FSM.")]
    public class GetFsmBoolList : BaseGetFsmVariableAction<List<bool>, BoolListVariable, BoolListRef, BoolListVar>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}

