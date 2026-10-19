using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Set the value of a string variable in another FSM.")]
    public class SetFsmString : BaseSetFsmVariableAction<string, StringVariable, StringVar>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}