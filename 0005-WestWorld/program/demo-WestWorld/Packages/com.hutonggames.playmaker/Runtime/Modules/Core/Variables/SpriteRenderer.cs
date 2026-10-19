using System;
using UnityEngine;


namespace HutongGames.PlayMaker
{
	
	
    [Serializable]
    [DataType(typeof(UnityEngine.SpriteRenderer))]
    public sealed partial class SpriteRendererVariable : Variable<SpriteRenderer>
    {
		
        public SpriteRendererVariable()
        {
        }
		
        public SpriteRendererVariable(string name) : 
            base(name)
        {
        }
    }
	
    [Serializable]
    [DataType(typeof(UnityEngine.SpriteRenderer))]
    public sealed partial class SpriteRendererListVariable : ListVariable<SpriteRenderer>
    {
		
        public SpriteRendererListVariable()
        {
        }
		
        public SpriteRendererListVariable(string name) : 
            base(name)
        {
        }
    }
	
    [Serializable]
    [DataType(typeof(UnityEngine.SpriteRenderer))]
    public sealed partial class SpriteRendererRef : BaseComponentRef<SpriteRenderer>
    {
    }
	
    [Serializable]
    [DataType(typeof(UnityEngine.SpriteRenderer))]
    public sealed partial class SpriteRendererVar : BaseComponentVar<SpriteRenderer>
    {
    }
	
    [Serializable]
    [DataType(typeof(UnityEngine.SpriteRenderer))]
    public sealed partial class SpriteRendererListRef : ListVariableRef<SpriteRenderer>
    {
    }
	
    [Serializable]
    [DataType(typeof(UnityEngine.SpriteRenderer))]
    public sealed partial class SpriteRendererListVar : ListVariableVar<SpriteRenderer>
    {
    }

    [Serializable]
    [DataType(typeof(UnityEngine.SpriteRenderer))]
    public sealed partial class SpriteRendererOverride : VariableOverride<SpriteRenderer, SpriteRendererVariable, SpriteRendererVar>
    {
        public SpriteRendererOverride(IVariable variable) : base(variable)
        {
        }
    }

    [Serializable]
    [DataType(typeof(UnityEngine.SpriteRenderer))]
    public sealed partial class SpriteRendererOutput : VariableOutput<SpriteRenderer, SpriteRendererVariable, SpriteRendererRef>
    {
        public SpriteRendererOutput(IVariable variable) : base(variable)
        {
        }
    }

    [Serializable]
    [DataType(typeof(UnityEngine.SpriteRenderer))]
    public sealed partial class SpriteRendererListOverride : VariableOverride<System.Collections.Generic.List<SpriteRenderer>, SpriteRendererListVariable, SpriteRendererListVar>
    {
        public SpriteRendererListOverride(IVariable variable) : base(variable)
        {
        }
    }

    [Serializable]
    [DataType(typeof(UnityEngine.SpriteRenderer))]
    public sealed partial class SpriteRendererListOutput : VariableOutput<System.Collections.Generic.List<SpriteRenderer>, SpriteRendererListVariable, SpriteRendererListRef>
    {
        public SpriteRendererListOutput(IVariable variable) : base(variable)
        {
        }
    }
}
