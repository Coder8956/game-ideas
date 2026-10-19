using System;

namespace HutongGames.PlayMaker.UI
{
    [Serializable]
    [DataType(typeof(DataPaging))]
    public class DataPagingVariable : Variable<DataPaging>
    {
        public DataPagingVariable()
        {
        }

        public DataPagingVariable(string name) : base(name)
        {
        }
    }

    [Serializable]
    [DataType(typeof(DataPaging))]
    public class DataPagingVar : VariableVar<DataPaging>
    {
    }

    [Serializable]
    [DataType(typeof(DataPaging))]
    public class DataPagingRef : VariableRef<DataPaging>
    {
    }
}