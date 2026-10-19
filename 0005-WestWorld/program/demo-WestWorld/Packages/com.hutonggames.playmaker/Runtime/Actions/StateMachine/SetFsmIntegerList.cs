using System.Collections.Generic;
using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Set the values of an integer list variable in another FSM.")]
    public class SetFsmIntegerList : BaseSetFsmVariableAction<List<int>, IntegerListVariable, IntegerListVar>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}

