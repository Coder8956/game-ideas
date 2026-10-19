using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Get the values of a Vector3 list variable in another FSM.")]
    public class GetFsmVector3List : BaseGetFsmVariableAction<List<Vector3>, Vector3ListVariable, Vector3ListRef, Vector3ListVar>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}

