using System.Collections.Generic;
using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Get the values of an integer list variable in another FSM.")]
    public class GetFsmIntegerList : BaseGetFsmVariableAction<List<int>, IntegerListVariable, IntegerListRef, IntegerListVar>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}

