using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Get the value of an integer variable in another FSM.")]
    public class GetFsmInteger : BaseGetFsmVariableAction<int, IntegerVariable, IntegerRef, IntegerVar>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}