using System.Collections.Generic;
using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Get the values of a string list variable in another FSM.")]
    public class GetFsmStringList : BaseGetFsmVariableAction<List<string>, StringListVariable, StringListRef, StringListVar>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}

