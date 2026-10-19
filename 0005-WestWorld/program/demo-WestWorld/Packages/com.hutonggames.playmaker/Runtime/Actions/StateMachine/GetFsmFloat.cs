using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Get the value of a float variable in another FSM.")]
    public class GetFsmFloat : BaseGetFsmVariableAction<float, FloatVariable, FloatRef, FloatVar>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}