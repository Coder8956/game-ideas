
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.GradientMode))]
	public sealed partial class GradientModeVariable : Variable<UnityEngine.GradientMode>
	{
		
		public GradientModeVariable()
		{
		}
		
		public GradientModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.GradientMode))]
	public sealed partial class GradientModeListVariable : ListVariable<UnityEngine.GradientMode>
	{
		
		public GradientModeListVariable()
		{
		}
		
		public GradientModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.GradientMode))]
	public sealed partial class GradientModeRef : VariableRef<UnityEngine.GradientMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.GradientMode))]
	public sealed partial class GradientModeVar : VariableVar<UnityEngine.GradientMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.GradientMode))]
	public sealed partial class GradientModeListRef : ListVariableRef<UnityEngine.GradientMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.GradientMode))]
	public sealed partial class GradientModeListVar : ListVariableVar<UnityEngine.GradientMode>
	{
	}
}
