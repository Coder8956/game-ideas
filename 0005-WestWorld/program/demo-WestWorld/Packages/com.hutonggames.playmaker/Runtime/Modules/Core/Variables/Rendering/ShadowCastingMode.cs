
using System;


namespace HutongGames.PlayMaker.Actions.Rendering
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.ShadowCastingMode))]
	public sealed partial class ShadowCastingModeVariable : Variable<UnityEngine.Rendering.ShadowCastingMode>
	{
		
		public ShadowCastingModeVariable()
		{
		}
		
		public ShadowCastingModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.ShadowCastingMode))]
	public sealed partial class ShadowCastingModeListVariable : ListVariable<UnityEngine.Rendering.ShadowCastingMode>
	{
		
		public ShadowCastingModeListVariable()
		{
		}
		
		public ShadowCastingModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.ShadowCastingMode))]
	public sealed partial class ShadowCastingModeRef : VariableRef<UnityEngine.Rendering.ShadowCastingMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.ShadowCastingMode))]
	public sealed partial class ShadowCastingModeVar : VariableVar<UnityEngine.Rendering.ShadowCastingMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.ShadowCastingMode))]
	public sealed partial class ShadowCastingModeListRef : ListVariableRef<UnityEngine.Rendering.ShadowCastingMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.ShadowCastingMode))]
	public sealed partial class ShadowCastingModeListVar : ListVariableVar<UnityEngine.Rendering.ShadowCastingMode>
	{
	}
}
