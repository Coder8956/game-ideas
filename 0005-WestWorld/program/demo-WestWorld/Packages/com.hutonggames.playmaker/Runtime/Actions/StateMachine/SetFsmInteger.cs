using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Set the value of an integer variable in another FSM.")]
    public class SetFsmInteger : BaseSetFsmVariableAction<int, IntegerVariable, IntegerVar>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}