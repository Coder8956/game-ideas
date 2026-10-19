using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Get the value of a DataRecord variable in another FSM.")]
    public class GetFsmDataRecord : BaseGetFsmVariableAction<DataRecord, DataRecordVariable, DataRecordRef, DataRecordVar>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}