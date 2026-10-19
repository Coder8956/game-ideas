/* USE BASE TARGET MANAGER VARIABLE
using System;

namespace HutongGames.PlayMaker.UI
{
    [Serializable]
    [DataType(typeof(TargetIndicator))]
    public class TargetIndicatorVariable : Variable<TargetIndicator>
    {
        public TargetIndicatorVariable()
        {
        }

        public TargetIndicatorVariable(string name) : base(name)
        {
        }
    }

    [Serializable]
    [DataType(typeof(TargetIndicator))]
    public class TargetIndicatorVar : VariableVar<TargetIndicator>
    {
    }

    [Serializable]
    [DataType(typeof(TargetIndicator))]
    public class TargetIndicatorRef : VariableRef<TargetIndicator>
    {
    }
}
*/