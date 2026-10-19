using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Set the value of a bool variable in another FSM.")]
    public class SetFsmBool : BaseSetFsmVariableAction<bool, BoolVariable, BoolVar>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}