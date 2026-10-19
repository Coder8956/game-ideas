using System.Collections.Generic;
using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Get the values of a DataRecord list variable in another FSM.")]
    public class GetFsmDataRecordList : BaseGetFsmVariableAction<List<DataRecord>, DataRecordListVariable, DataRecordListRef, DataRecordListVar>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}

