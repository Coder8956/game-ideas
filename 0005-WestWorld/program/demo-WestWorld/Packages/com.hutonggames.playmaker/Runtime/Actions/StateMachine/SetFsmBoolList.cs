using System.Collections.Generic;
using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Set the values of a bool list variable in another FSM.")]
    public class SetFsmBoolList : BaseSetFsmVariableAction<List<bool>, BoolListVariable, BoolListVar>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}

