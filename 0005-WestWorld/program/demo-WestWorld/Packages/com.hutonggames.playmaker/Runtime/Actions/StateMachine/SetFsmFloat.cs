using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Set the value of a float variable in another FSM.")]
    public class SetFsmFloat : BaseSetFsmVariableAction<float, FloatVariable, FloatVar>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}