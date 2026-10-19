
using System;
using UnityEngine;


namespace HutongGames.PlayMaker
{
	
	
	[Serializable]
	[DataType(typeof(Light))]
	public sealed partial class LightVariable : Variable<Light>
	{
		
		public LightVariable()
		{
		}
		
		public LightVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(Light))]
	public sealed partial class LightListVariable : ListVariable<Light>
	{
		
		public LightListVariable()
		{
		}
		
		public LightListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(Light))]
	public sealed partial class LightRef : VariableRef<Light>
	{
	}
	
	[Serializable]
	[DataType(typeof(Light))]
	public sealed partial class LightVar : VariableVar<Light>
	{
	}
	
	[Serializable]
	[DataType(typeof(Light))]
	public sealed partial class LightListRef : ListVariableRef<Light>
	{
	}
	
	[Serializable]
	[DataType(typeof(Light))]
	public sealed partial class LightListVar : ListVariableVar<Light>
	{
	}
	
	[Serializable]
	[DataType(typeof(Light))]
	public sealed partial class LightOverride : VariableOverride<Light,LightVariable,LightVar>
	{
		
		public LightOverride(IVariable variable) : 
				base(variable)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(Light))]
	public sealed partial class LightOutput : VariableOutput<Light,LightVariable,LightRef>
	{
		
		public LightOutput(IVariable variable) : 
				base(variable)
		{
		}
	}
}
