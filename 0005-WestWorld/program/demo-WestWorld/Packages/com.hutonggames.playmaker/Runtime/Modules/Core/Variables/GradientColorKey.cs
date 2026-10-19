
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.GradientColorKey))]
	public sealed partial class GradientColorKeyVariable : Variable<UnityEngine.GradientColorKey>
	{
		
		public GradientColorKeyVariable()
		{
		}
		
		public GradientColorKeyVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.GradientColorKey))]
	public sealed partial class GradientColorKeyListVariable : ListVariable<UnityEngine.GradientColorKey>
	{
		
		public GradientColorKeyListVariable()
		{
		}
		
		public GradientColorKeyListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.GradientColorKey))]
	public sealed partial class GradientColorKeyRef : VariableRef<UnityEngine.GradientColorKey>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.GradientColorKey))]
	public sealed partial class GradientColorKeyVar : VariableVar<UnityEngine.GradientColorKey>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.GradientColorKey))]
	public sealed partial class GradientColorKeyListRef : ListVariableRef<UnityEngine.GradientColorKey>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.GradientColorKey))]
	public sealed partial class GradientColorKeyListVar : ListVariableVar<UnityEngine.GradientColorKey>
	{
	}
}
