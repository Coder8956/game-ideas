
using System;


namespace HutongGames.PlayMaker.Actions.Rendering
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.DefaultReflectionMode))]
	public sealed partial class DefaultReflectionModeVariable : Variable<UnityEngine.Rendering.DefaultReflectionMode>
	{
		
		public DefaultReflectionModeVariable()
		{
		}
		
		public DefaultReflectionModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.DefaultReflectionMode))]
	public sealed partial class DefaultReflectionModeListVariable : ListVariable<UnityEngine.Rendering.DefaultReflectionMode>
	{
		
		public DefaultReflectionModeListVariable()
		{
		}
		
		public DefaultReflectionModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.DefaultReflectionMode))]
	public sealed partial class DefaultReflectionModeRef : VariableRef<UnityEngine.Rendering.DefaultReflectionMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.DefaultReflectionMode))]
	public sealed partial class DefaultReflectionModeVar : VariableVar<UnityEngine.Rendering.DefaultReflectionMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.DefaultReflectionMode))]
	public sealed partial class DefaultReflectionModeListRef : ListVariableRef<UnityEngine.Rendering.DefaultReflectionMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.DefaultReflectionMode))]
	public sealed partial class DefaultReflectionModeListVar : ListVariableVar<UnityEngine.Rendering.DefaultReflectionMode>
	{
	}
}
