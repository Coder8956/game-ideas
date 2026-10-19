using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Get the value of a bool variable in another FSM.")]
    public class GetFsmBool : BaseGetFsmVariableAction<bool, BoolVariable, BoolRef, BoolVar>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}