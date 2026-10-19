using System;

namespace HutongGames.PlayMaker.UI
{
    [Serializable]
    [DataType(typeof(MeterLabel))]
    public class MeterLabelVariable : Variable<MeterLabel>
    {
        public MeterLabelVariable()
        {
        }

        public MeterLabelVariable(string name) : base(name)
        {
        }
    }

    [Serializable]
    [DataType(typeof(MeterLabel))]
    public class MeterLabelVar : VariableVar<MeterLabel>
    {
    }

    [Serializable]
    [DataType(typeof(MeterLabel))]
    public class MeterLabelRef : VariableRef<MeterLabel>
    {
    }
}