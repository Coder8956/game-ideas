using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Get the values of a Transform list variable in another FSM.")]
    public class GetFsmTransformList : BaseGetFsmVariableAction<List<Transform>, TransformListVariable, TransformListRef, TransformListVar>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}

