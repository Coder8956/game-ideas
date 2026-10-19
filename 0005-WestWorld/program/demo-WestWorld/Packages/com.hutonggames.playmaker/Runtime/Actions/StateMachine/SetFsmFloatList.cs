using System.Collections.Generic;
using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Set the values of a float list variable in another FSM.")]
    public class SetFsmFloatList : BaseSetFsmVariableAction<List<float>, FloatListVariable, FloatListVar>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}
