using System;
using UnityEngine;


namespace HutongGames.PlayMaker
{
	
	
    [Serializable]
    [DataType(typeof(UnityEngine.LineRenderer))]
    public sealed partial class LineRendererVariable : Variable<LineRenderer>
    {
		
        public LineRendererVariable()
        {
        }
		
        public LineRendererVariable(string name) : 
            base(name)
        {
        }
    }
	
    [Serializable]
    [DataType(typeof(UnityEngine.LineRenderer))]
    public sealed partial class LineRendererListVariable : ListVariable<LineRenderer>
    {
		
        public LineRendererListVariable()
        {
        }
		
        public LineRendererListVariable(string name) : 
            base(name)
        {
        }
    }
	
    [Serializable]
    [DataType(typeof(UnityEngine.LineRenderer))]
    public sealed partial class LineRendererRef : BaseComponentRef<LineRenderer>
    {
    }
	
    [Serializable]
    [DataType(typeof(UnityEngine.LineRenderer))]
    public sealed partial class LineRendererVar : BaseComponentVar<LineRenderer>
    {
    }
    
    
	
    [Serializable]
    [DataType(typeof(UnityEngine.LineRenderer))]
    public sealed partial class LineRendererListRef : ListVariableRef<LineRenderer>
    {
    }
	
    [Serializable]
    [DataType(typeof(UnityEngine.LineRenderer))]
    public sealed partial class LineRendererListVar : ListVariableVar<LineRenderer>
    {
    }
    
    [Serializable]
    [DataType(typeof(UnityEngine.LineRenderer))]
    public sealed partial class LineRendererOverride : VariableOverride<LineRenderer,LineRendererVariable,LineRendererVar>
    {
		
	    public LineRendererOverride(IVariable variable) : 
		    base(variable)
	    {
	    }
    }
	
    [Serializable]
    [DataType(typeof(UnityEngine.LineRenderer))]
    public sealed partial class LineRendererOutput : VariableOutput<LineRenderer,LineRendererVariable,LineRendererRef>
    {
		
	    public LineRendererOutput(IVariable variable) : 
		    base(variable)
	    {
	    }
    }
}