using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Set the values of a Vector2 list variable in another FSM.")]
    public class SetFsmVector2List : BaseSetFsmVariableAction<List<Vector2>, Vector2ListVariable, Vector2ListVar>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}

