using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Set the value of a Vector2 variable in another FSM.")]
    public class SetFsmVector2 : BaseSetFsmVariableAction<Vector2, Vector2Variable, Vector2Var>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}