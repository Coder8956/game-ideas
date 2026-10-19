using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
    [Serializable]
    [DataType(typeof(UnityEngine.BoundsInt))]
    public sealed partial class BoundsIntVariable : Variable<UnityEngine.BoundsInt>
    {
		
        public BoundsIntVariable()
        {
        }
		
        public BoundsIntVariable(string name) : 
            base(name)
        {
        }
    }
	
    [Serializable]
    [DataType(typeof(UnityEngine.BoundsInt))]
    public sealed partial class BoundsIntListVariable : ListVariable<UnityEngine.BoundsInt>
    {
		
        public BoundsIntListVariable()
        {
        }
		
        public BoundsIntListVariable(string name) : 
            base(name)
        {
        }
    }
	
    [Serializable]
    [DataType(typeof(UnityEngine.BoundsInt))]
    public sealed partial class BoundsIntRef : VariableRef<UnityEngine.BoundsInt>
    {
    }
	
    [Serializable]
    [DataType(typeof(UnityEngine.BoundsInt))]
    public sealed partial class BoundsIntVar : VariableVar<UnityEngine.BoundsInt>
    {
    }
	
    [Serializable]
    [DataType(typeof(UnityEngine.BoundsInt))]
    public sealed partial class BoundsIntListRef : ListVariableRef<UnityEngine.BoundsInt>
    {
    }
	
    [Serializable]
    [DataType(typeof(UnityEngine.BoundsInt))]
    public sealed partial class BoundsIntListVar : ListVariableVar<UnityEngine.BoundsInt>
    {
    }

    [Serializable]
    [DataType(typeof(UnityEngine.BoundsInt))]
    public sealed partial class BoundsIntOverride : VariableOverride<UnityEngine.BoundsInt, BoundsIntVariable, BoundsIntVar>
    {
        public BoundsIntOverride(IVariable variable) : base(variable)
        {
        }
    }

    [Serializable]
    [DataType(typeof(UnityEngine.BoundsInt))]
    public sealed partial class BoundsIntOutput : VariableOutput<UnityEngine.BoundsInt, BoundsIntVariable, BoundsIntRef>
    {
        public BoundsIntOutput(IVariable variable) : base(variable)
        {
        }
    }

    [Serializable]
    [DataType(typeof(UnityEngine.BoundsInt))]
    public sealed partial class BoundsIntListOverride : VariableOverride<System.Collections.Generic.List<UnityEngine.BoundsInt>, BoundsIntListVariable, BoundsIntListVar>
    {
        public BoundsIntListOverride(IVariable variable) : base(variable)
        {
        }
    }

    [Serializable]
    [DataType(typeof(UnityEngine.BoundsInt))]
    public sealed partial class BoundsIntListOutput : VariableOutput<System.Collections.Generic.List<UnityEngine.BoundsInt>, BoundsIntListVariable, BoundsIntListRef>
    {
        public BoundsIntListOutput(IVariable variable) : base(variable)
        {
        }
    }
}
