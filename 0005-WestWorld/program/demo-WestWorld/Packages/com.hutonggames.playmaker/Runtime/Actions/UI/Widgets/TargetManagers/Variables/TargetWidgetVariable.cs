using System;

namespace HutongGames.PlayMaker.UI
{
    [Serializable]
    [DataType(typeof(TargetWidget))]
    public class TargetWidgetVariable : Variable<TargetWidget>
    {
        public TargetWidgetVariable()
        {
        }

        public TargetWidgetVariable(string name) : base(name)
        {
        }
    }

    [Serializable]
    [DataType(typeof(TargetWidget))]
    public class TargetWidgetVar : VariableVar<TargetWidget>
    {
    }

    [Serializable]
    [DataType(typeof(TargetWidget))]
    public class TargetWidgetRef : VariableRef<TargetWidget>
    {
    }
}