
using System;
using UnityEngine;


namespace HutongGames.PlayMaker
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Bounds))]
	public sealed partial class BoundsVariable : Variable<Bounds>
	{
		
		public BoundsVariable()
		{
		}
		
		public BoundsVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Bounds))]
	public sealed partial class BoundsListVariable : ListVariable<Bounds>
	{
		
		public BoundsListVariable()
		{
		}
		
		public BoundsListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Bounds))]
	public sealed partial class BoundsRef : VariableRef<Bounds>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Bounds))]
	public sealed partial class BoundsVar : VariableVar<Bounds>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Bounds))]
	public sealed partial class BoundsListRef : ListVariableRef<Bounds>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Bounds))]
	public sealed partial class BoundsListVar : ListVariableVar<Bounds>
	{
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Bounds))]
	public sealed partial class BoundsOverride : VariableOverride<Bounds, BoundsVariable, BoundsVar>
	{
		public BoundsOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Bounds))]
	public sealed partial class BoundsOutput : VariableOutput<Bounds, BoundsVariable, BoundsRef>
	{
		public BoundsOutput(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Bounds))]
	public sealed partial class BoundsListOverride : VariableOverride<System.Collections.Generic.List<Bounds>, BoundsListVariable, BoundsListVar>
	{
		public BoundsListOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Bounds))]
	public sealed partial class BoundsListOutput : VariableOutput<System.Collections.Generic.List<Bounds>, BoundsListVariable, BoundsListRef>
	{
		public BoundsListOutput(IVariable variable) : base(variable)
		{
		}
	}
}
