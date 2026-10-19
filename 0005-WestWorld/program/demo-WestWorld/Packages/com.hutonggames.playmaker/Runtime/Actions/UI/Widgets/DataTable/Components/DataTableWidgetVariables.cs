using System;

namespace HutongGames.PlayMaker.UI
{
    [Serializable]
    [DataType(typeof(DataTableWidget))]
    public class DataTableWidgetVariable : Variable<DataTableWidget>
    {
        public DataTableWidgetVariable()
        {
        }

        public DataTableWidgetVariable(string name) : base(name)
        {
        }
    }

    [Serializable]
    [DataType(typeof(DataTableWidget))]
    public class DataTableWidgetVar : VariableVar<DataTableWidget>
    {
    }

    [Serializable]
    [DataType(typeof(DataTableWidget))]
    public class DataTableWidgetRef : VariableRef<DataTableWidget>
    {
    }
}