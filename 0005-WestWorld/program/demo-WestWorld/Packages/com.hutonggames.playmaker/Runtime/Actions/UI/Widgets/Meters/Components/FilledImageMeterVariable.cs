using System;

namespace HutongGames.PlayMaker.UI
{
    [Serializable]
    [DataType(typeof(FilledImageMeter))]
    public class FilledImageMeterVariable : Variable<FilledImageMeter>
    {
        public FilledImageMeterVariable()
        {
        }

        public FilledImageMeterVariable(string name) : base(name)
        {
        }
    }

    [Serializable]
    [DataType(typeof(FilledImageMeter))]
    public class FilledImageMeterVar : VariableVar<FilledImageMeter>
    {
    }

    [Serializable]
    [DataType(typeof(FilledImageMeter))]
    public class FilledImageMeterRef : VariableRef<FilledImageMeter>
    {
    }
}