
using System;
using UnityEngine;


namespace HutongGames.PlayMaker
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Ray))]
	public sealed partial class RayVariable : Variable<Ray>
	{
		
		public RayVariable()
		{
		}
		
		public RayVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Ray))]
	public sealed partial class RayListVariable : ListVariable<Ray>
	{
		
		public RayListVariable()
		{
		}
		
		public RayListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Ray))]
	public sealed partial class RayRef : VariableRef<Ray>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Ray))]
	public sealed partial class RayVar : VariableVar<Ray>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Ray))]
	public sealed partial class RayListRef : ListVariableRef<Ray>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Ray))]
	public sealed partial class RayListVar : ListVariableVar<Ray>
	{
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Ray))]
	public sealed partial class RayOverride : VariableOverride<Ray, RayVariable, RayVar>
	{
		public RayOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Ray))]
	public sealed partial class RayOutput : VariableOutput<Ray, RayVariable, RayRef>
	{
		public RayOutput(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Ray))]
	public sealed partial class RayListOverride : VariableOverride<System.Collections.Generic.List<Ray>, RayListVariable, RayListVar>
	{
		public RayListOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Ray))]
	public sealed partial class RayListOutput : VariableOutput<System.Collections.Generic.List<Ray>, RayListVariable, RayListRef>
	{
		public RayListOutput(IVariable variable) : base(variable)
		{
		}
	}
}
