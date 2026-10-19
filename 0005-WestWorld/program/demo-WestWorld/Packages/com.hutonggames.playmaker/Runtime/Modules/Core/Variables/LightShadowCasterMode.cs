
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.LightShadowCasterMode))]
	public sealed partial class LightShadowCasterModeVariable : Variable<UnityEngine.LightShadowCasterMode>
	{
		
		public LightShadowCasterModeVariable()
		{
		}
		
		public LightShadowCasterModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LightShadowCasterMode))]
	public sealed partial class LightShadowCasterModeListVariable : ListVariable<UnityEngine.LightShadowCasterMode>
	{
		
		public LightShadowCasterModeListVariable()
		{
		}
		
		public LightShadowCasterModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LightShadowCasterMode))]
	public sealed partial class LightShadowCasterModeRef : VariableRef<UnityEngine.LightShadowCasterMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LightShadowCasterMode))]
	public sealed partial class LightShadowCasterModeVar : VariableVar<UnityEngine.LightShadowCasterMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LightShadowCasterMode))]
	public sealed partial class LightShadowCasterModeListRef : ListVariableRef<UnityEngine.LightShadowCasterMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LightShadowCasterMode))]
	public sealed partial class LightShadowCasterModeListVar : ListVariableVar<UnityEngine.LightShadowCasterMode>
	{
	}
}
