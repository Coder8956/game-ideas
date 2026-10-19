
using System;
using UnityEngine;


namespace HutongGames.PlayMaker
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.LayerMask))]
	public sealed partial class LayerMaskVariable : Variable<LayerMask>
	{
		
		public LayerMaskVariable()
		{
		}
		
		public LayerMaskVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LayerMask))]
	public sealed partial class LayerMaskListVariable : ListVariable<LayerMask>
	{
		
		public LayerMaskListVariable()
		{
		}
		
		public LayerMaskListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LayerMask))]
	public sealed partial class LayerMaskRef : VariableRef<LayerMask>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LayerMask))]
	public sealed partial class LayerMaskVar : VariableVar<LayerMask>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LayerMask))]
	public sealed partial class LayerMaskListRef : ListVariableRef<LayerMask>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LayerMask))]
	public sealed partial class LayerMaskListVar : ListVariableVar<LayerMask>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LayerMask))]
	public sealed partial class LayerMaskOverride : VariableOverride<LayerMask,LayerMaskVariable,LayerMaskVar>
	{
		
		public LayerMaskOverride(IVariable variable) : 
				base(variable)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LayerMask))]
	public sealed partial class LayerMaskOutput : VariableOutput<LayerMask,LayerMaskVariable,LayerMaskRef>
	{
		
		public LayerMaskOutput(IVariable variable) : 
				base(variable)
		{
		}
	}
}
