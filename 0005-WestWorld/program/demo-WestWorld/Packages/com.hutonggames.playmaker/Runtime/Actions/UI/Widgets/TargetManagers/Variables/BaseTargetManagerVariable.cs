using System;

namespace HutongGames.PlayMaker.UI
{
    [Serializable]
    [DataType(typeof(BaseTargetManager))]
    public class BaseTargetManagerVariable : Variable<BaseTargetManager>
    {
        public BaseTargetManagerVariable()
        {
        }

        public BaseTargetManagerVariable(string name) : base(name)
        {
        }
    }

    [Serializable]
    [DataType(typeof(BaseTargetManager))]
    public class BaseTargetManagerVar : VariableVar<BaseTargetManager>
    {
    }

    [Serializable]
    [DataType(typeof(BaseTargetManager))]
    public class BaseTargetManagerRef : VariableRef<BaseTargetManager>
    {
    }
}