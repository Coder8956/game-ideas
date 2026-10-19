using System.Collections.Generic;
using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Set the values of a string list variable in another FSM.")]
    public class SetFsmStringList : BaseSetFsmVariableAction<List<string>, StringListVariable, StringListVar>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}

