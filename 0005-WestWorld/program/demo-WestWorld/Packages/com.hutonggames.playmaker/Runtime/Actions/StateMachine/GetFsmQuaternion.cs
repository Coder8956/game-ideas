using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Get the value of a Quaternion variable in another FSM.")]
    public class GetFsmQuaternion : BaseGetFsmVariableAction<Quaternion, QuaternionVariable, QuaternionRef, QuaternionVar>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}