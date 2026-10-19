using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Get the values of a Quaternion list variable in another FSM.")]
    public class GetFsmQuaternionList : BaseGetFsmVariableAction<List<Quaternion>, QuaternionListVariable, QuaternionListRef, QuaternionListVar>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}

