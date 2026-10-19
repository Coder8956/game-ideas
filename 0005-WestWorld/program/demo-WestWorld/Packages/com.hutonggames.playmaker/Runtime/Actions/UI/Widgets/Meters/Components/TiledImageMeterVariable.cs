using System;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker.UI
{
    [Serializable]
    [DataType(typeof(TiledImageMeter))]
    public class TiledImageMeterVariable : Variable<TiledImageMeter>
    {
        public TiledImageMeterVariable()
        {
        }

        public TiledImageMeterVariable(string name) : base(name)
        {
        }
    }

    [Serializable]
    [DataType(typeof(TiledImageMeter))]
    public class TiledImageMeterVar : VariableVar<TiledImageMeter>
    {
    }

    [Serializable]
    [DataType(typeof(TiledImageMeter))]
    public class TiledImageMeterRef : VariableRef<TiledImageMeter>
    {
    }
}