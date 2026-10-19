using System.Collections.Generic;
using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Get the values of a float list variable in another FSM.")]
    public class GetFsmFloatList : BaseGetFsmVariableAction<List<float>, FloatListVariable, FloatListRef, FloatListVar>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}
