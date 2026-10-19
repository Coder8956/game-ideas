using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Get the value of a string variable in another FSM.")]
    public class GetFsmString : BaseGetFsmVariableAction<string, StringVariable, StringRef, StringVar>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}