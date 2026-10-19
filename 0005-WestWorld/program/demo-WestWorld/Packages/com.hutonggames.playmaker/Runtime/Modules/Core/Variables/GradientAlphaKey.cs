
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.GradientAlphaKey))]
	public sealed partial class GradientAlphaKeyVariable : Variable<UnityEngine.GradientAlphaKey>
	{
		
		public GradientAlphaKeyVariable()
		{
		}
		
		public GradientAlphaKeyVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.GradientAlphaKey))]
	public sealed partial class GradientAlphaKeyListVariable : ListVariable<UnityEngine.GradientAlphaKey>
	{
		
		public GradientAlphaKeyListVariable()
		{
		}
		
		public GradientAlphaKeyListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.GradientAlphaKey))]
	public sealed partial class GradientAlphaKeyRef : VariableRef<UnityEngine.GradientAlphaKey>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.GradientAlphaKey))]
	public sealed partial class GradientAlphaKeyVar : VariableVar<UnityEngine.GradientAlphaKey>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.GradientAlphaKey))]
	public sealed partial class GradientAlphaKeyListRef : ListVariableRef<UnityEngine.GradientAlphaKey>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.GradientAlphaKey))]
	public sealed partial class GradientAlphaKeyListVar : ListVariableVar<UnityEngine.GradientAlphaKey>
	{
	}
}
