using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Set the value of a Rect variable in another FSM.")]
    public class SetFsmRect : BaseSetFsmVariableAction<Rect, RectVariable, RectVar>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}