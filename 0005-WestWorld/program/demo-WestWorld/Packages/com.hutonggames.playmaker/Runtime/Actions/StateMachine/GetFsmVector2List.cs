using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Get the values of a Vector2 list variable in another FSM.")]
    public class GetFsmVector2List : BaseGetFsmVariableAction<List<Vector2>, Vector2ListVariable, Vector2ListRef, Vector2ListVar>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}

