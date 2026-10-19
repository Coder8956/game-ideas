
using System;


namespace HutongGames.PlayMaker.Actions.Rendering
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.AmbientMode))]
	public sealed partial class AmbientModeVariable : Variable<UnityEngine.Rendering.AmbientMode>
	{
		
		public AmbientModeVariable()
		{
		}
		
		public AmbientModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.AmbientMode))]
	public sealed partial class AmbientModeListVariable : ListVariable<UnityEngine.Rendering.AmbientMode>
	{
		
		public AmbientModeListVariable()
		{
		}
		
		public AmbientModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.AmbientMode))]
	public sealed partial class AmbientModeRef : VariableRef<UnityEngine.Rendering.AmbientMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.AmbientMode))]
	public sealed partial class AmbientModeVar : VariableVar<UnityEngine.Rendering.AmbientMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.AmbientMode))]
	public sealed partial class AmbientModeListRef : ListVariableRef<UnityEngine.Rendering.AmbientMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.AmbientMode))]
	public sealed partial class AmbientModeListVar : ListVariableVar<UnityEngine.Rendering.AmbientMode>
	{
	}
}
