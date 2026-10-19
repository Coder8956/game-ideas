using System.Collections.Generic;
using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Set the values of a DataRecord list variable in another FSM.")]
    public class SetFsmDataRecordList : BaseSetFsmVariableAction<List<DataRecord>, DataRecordListVariable, DataRecordListVar>
    {
        // All work is done in base class, but we need the concrete type to serialize.
    }
}

