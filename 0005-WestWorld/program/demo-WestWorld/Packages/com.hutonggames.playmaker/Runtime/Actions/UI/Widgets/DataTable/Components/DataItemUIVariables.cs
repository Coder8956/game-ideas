using System;

namespace HutongGames.PlayMaker.UI
{
    [Serializable]
    [DataType(typeof(DataItemUI))]
    public class DataItemUIVariable : Variable<DataItemUI>
    {
        public DataItemUIVariable()
        {
        }

        public DataItemUIVariable(string name) : base(name)
        {
        }
    }

    [Serializable]
    [DataType(typeof(DataItemUI))]
    public class DataItemUIVar : VariableVar<DataItemUI>
    {
    }

    [Serializable]
    [DataType(typeof(DataItemUI))]
    public class DataItemUIRef : VariableRef<DataItemUI>
    {
    }
}