using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Set the value of a Quaternion variable in another FSM.")]
    public class SetFsmQuaternion : BaseSetFsmVariableAction<Quaternion, QuaternionVariable, QuaternionVar>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}