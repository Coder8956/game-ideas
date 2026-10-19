using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Set the value of a Vector3 variable in another FSM.")]
    public class SetFsmVector3 : BaseSetFsmVariableAction<Vector3, Vector3Variable, Vector3Var>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}